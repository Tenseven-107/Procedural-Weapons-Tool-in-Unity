using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Monobehaviours;
using Tool.Logic.Parts;
using UnityEngine;


namespace Tool.Logic.Processes
{
    [ExecuteAlways]
    public class ProcWeaponGenerator : ScriptableObject
    {
        // Generate a weapon
        public void Generate(List<ProcWeaponUniquePart> partList, int amount)
        {
            for (int number = 0; number < amount; number++)
            {
                var usedParts = GetParts(partList);
                
                // Checking if the used parts are okay to use
                for (int part = 0; part < usedParts.Count; part++)
                {
                    // Stop generating if there are no parts
                    if (usedParts.Count == 0)
                    {
                        return;
                    }
                        
                    // If there's a base part, all is fine
                    if (usedParts[part].partType.basePart == true) { break; }
                    
                    // Log warning if there is no base part detected and at end of the list
                    if (part == usedParts.Count - 1)
                    {
                        Debug.LogError(this.GetType().FullName + ": No base part detected in selected parts! Please add a base to your parttype " + usedParts[0].partType.weaponType + " for your given part collection.");
                        return;
                    }
                } 
                
                // Spawn a new weapon using picked parts
                SpawnNewWeapon(usedParts);
            }
        }
        
        
        
        // Get a random set of parts
        private List<ProcWeaponUniquePart> GetParts(List<ProcWeaponUniquePart> partList)
        {
            var selectedParts = new List<ProcWeaponUniquePart>();

            // Generating a randdom selection of parts
            var randomWeaponType = partList[Random.Range(0, partList.Count)].partType.weaponType;
            for (int part = 0; part < partList.Count; part++)
            {
                if (partList[part].partType.weaponType == randomWeaponType && CheckContainsPartType(selectedParts, partList[part].partType.weaponPartType) == false)
                {
                    var currentPartType = partList[part].partType.weaponPartType;
                    var partsOfThisType = GetPartsOfThisPartType(partList, randomWeaponType, currentPartType);
                    var randomPart = partsOfThisType[Random.Range(0, partsOfThisType.Count)];
                    selectedParts.Add(randomPart);
                }
            }
     
            // Return selected parts for use
            return selectedParts;
        }


        
        // Get parts in a list of a certain type of part
        private List<ProcWeaponUniquePart> GetPartsOfThisPartType(List<ProcWeaponUniquePart> partList, string weaponType, string partType)
        {
            List<ProcWeaponUniquePart> selectedParts = new List<ProcWeaponUniquePart>();
            
            for (int part = 0; part < partList.Count; part++)
            {
                if (partList[part].partType.weaponType == weaponType && partList[part].partType.weaponPartType == partType)
                {
                    selectedParts.Add(partList[part]);
                }
            }
            return selectedParts;
        }
        
        // Check if a part list already contains the given part type
        private bool CheckContainsPartType(List<ProcWeaponUniquePart> partList, string currentWeaponPartType)
        {
            for (int part = 0; part < partList.Count; part++)
            {
                if (partList[part].partType.weaponPartType == currentWeaponPartType)
                {
                    return true;
                }
            }

            return false;
        }
        
        
        
        // Spawn a weapon with said used parts
        public void SpawnNewWeapon(List<ProcWeaponUniquePart> usedParts)
        {
            var newGameObject = new GameObject();
            newGameObject.name = "Procedural Weapon";
            
            var newProceduralWeapon = newGameObject.AddComponent<ProceduralWeapon>();
            newProceduralWeapon.UsedParts = usedParts;
        }
    }
}
