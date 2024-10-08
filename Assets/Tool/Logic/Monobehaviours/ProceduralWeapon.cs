using System;
using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Parts;
using UnityEngine;


namespace Tool.Logic.Monobehaviours
{
    [RequireComponent(typeof(ProceduralWeaponStatistics))]
    public class ProceduralWeapon : MonoBehaviour
    {
        // Stats
        private ProceduralWeaponStatistics _statComponnent;
        
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
            _statComponnent = GetComponent<ProceduralWeaponStatistics>();
            _statComponnent.LoadStats(_usedParts);
            
            List<ProcWeaponUniquePart> currentlyUsedParts = _usedParts;
            ProcWeaponUniquePart lastPart = _usedParts[0];
            var lastTransform = transform;
            
            // Create a basepart
            for (int part = 0; part < _usedParts.Count; part++)
            {
                var currentPart = _usedParts[part];
                
                // Create basePart
                if (currentPart.partType.basePart == true)
                {
                    lastPart = currentPart;
                    
                    var partObject = Instantiate(currentPart.partModel, transform);
                    partObject.name = _usedParts[part].name;

                    lastTransform = partObject.transform;
                    
                    currentlyUsedParts.RemoveAt(part);
                    Debug.Log("Base part: " + currentPart); // TEST
                    break;
                }
            }
            
            // Make the rest
            var currentConnectionPoint = 0;
            for (int times = 0; times < currentlyUsedParts.Count; times++)
            {
                currentConnectionPoint = Mathf.Clamp(currentConnectionPoint, 0, lastPart.connectionPoints.Count);
                
                var nextPart = GetNextPart(currentlyUsedParts, lastPart.partType);
                var partObject = Instantiate(nextPart.partModel, transform);
                var offset = lastTransform.position + lastPart.connectionPoints[currentConnectionPoint] - nextPart.connectionPoints[0];
                partObject.transform.position += offset;
                partObject.name = nextPart.name;

                Debug.Log("CurrentConnection point: " + currentConnectionPoint); // TEST
                Debug.Log("Current part: " + nextPart); // TEST
                
                currentConnectionPoint++;
                
                lastPart = nextPart;
                lastTransform = partObject.transform;
            }
        }
        
        
        
        // Get next weapon part
        private ProcWeaponUniquePart GetNextPart(List<ProcWeaponUniquePart> partList,
            ProcWeaponTypePart currentPartType)
        {
            for (int part = 0; part < partList.Count; part++)
            {
                var nextPart = partList[part];
                if (nextPart.partType == currentPartType.nextPart)
                {
                    return nextPart;
                }
            }

            return null;
        }
    }
}
