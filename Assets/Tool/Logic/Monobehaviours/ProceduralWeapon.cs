using System;
using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Parts;
using UnityEngine;


namespace Tool.Logic.Monobehaviours
{
    public class ProceduralWeapon : MonoBehaviour
    {
        // Used Data
        private List<ProcWeaponUniquePart> _usedParts;
        public List<ProcWeaponUniquePart> UsedParts
        {
            get => _usedParts;
            set
            {
                _usedParts = value;
                Assemble();
            }
        }
        
        
        
        // Generate a model
        private void Assemble()
        {
            List<ProcWeaponUniquePart> currentlyUsedParts = _usedParts;
            ProcWeaponUniquePart lastPart = _usedParts[0];
            
            // Create a basepart
            for (int part = 0; part < _usedParts.Count; part++)
            {
                var currentPart = _usedParts[part];
                
                // Create basePart
                if (currentPart.usedPartType.basePart == true)
                {
                    lastPart = currentPart;
                    
                    var partObject = Instantiate(currentPart.partModel, transform);
                    partObject.name = _usedParts[part].name;
                    currentlyUsedParts.RemoveAt(part);
                    Debug.Log("Base part: " + currentPart); // TEST
                    break;
                }
            }
            
            // Make the rest
            var currentConnectionPoint = 0;
            for (int times = 0; times < currentlyUsedParts.Count; times++)
            {
                var nextPart = GetNextPart(currentlyUsedParts, lastPart.partType);
                var partObject = Instantiate(nextPart.partModel, transform);

                partObject.transform.position =
                    lastPart.connectionPoints[currentConnectionPoint] - nextPart.connectionPoints[0];
                partObject.name = nextPart.name;

                if (nextPart.partType.lastPart == lastPart.partType)
                {
                    if (nextPart.connectionPoints.Count > 1) { currentConnectionPoint++; } 
                }
                else { currentConnectionPoint = 0; }
                
                Debug.Log("Current part: " + nextPart); // TEST
                lastPart = nextPart;
            }
        }
        
        
        
        // Get next weapon part
        private ProcWeaponUniquePart GetNextPart(List<ProcWeaponUniquePart> partList,
            ProcWeaponTypePart currentPartType)
        {
            for (int part = 0; part < partList.Count; part++)
            {
                var nextPart = partList[part];
                if (nextPart.usedPartType == currentPartType.nextPart)
                {
                    return nextPart;
                }
            }

            return null;
        }
    }
}
