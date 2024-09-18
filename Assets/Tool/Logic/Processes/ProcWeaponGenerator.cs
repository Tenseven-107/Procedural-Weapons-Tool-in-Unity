using System.Collections;
using System.Collections.Generic;
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
                List<ProcWeaponUniquePart> usedParts = GetParts(partList);
                
                Debug.Log("Total parts: " + partList.Count); // TEST
                Debug.Log("Used parts: " + usedParts.Count); // TEST
                for (int i =0; i < usedParts.Count; i++) {Debug.Log("Used part " + i + ": " + usedParts[i]);} // TEST
                //SpawnWeapon(usedParts);
            }
        }
        
        
        
        // Get a random set of parts
        private List<ProcWeaponUniquePart> GetParts(List<ProcWeaponUniquePart> partList)
        {
            var selectedParts = new List<ProcWeaponUniquePart>();

            var randomWeaponType = partList[Random.Range(0, partList.Count)].usedPartType.weaponType;
            for (int part = 0; part < partList.Count; part++)
            {
                if (partList[part].usedPartType.weaponType == randomWeaponType && CheckContainsPartType(selectedParts, partList[part].usedPartType.weaponPartType) == false)
                {
                    var currentPartType = partList[part].usedPartType.weaponPartType;
                    var partsOfThisType = GetPartsOfThisPartType(partList, randomWeaponType, currentPartType);
                    var randomPart = partsOfThisType[Random.Range(0, partsOfThisType.Count)];
                    Debug.Log("Selected type: " + currentPartType); // TEST
                    selectedParts.Add(randomPart);
                    Debug.Log(selectedParts); // TEST
                    Debug.Log("Current Selected part-amount: " + selectedParts.Count); // TEST
                }
                Debug.Log("Time: " + part); // TEST
            }
            Debug.Log("FINAL Selected part-amount: " + selectedParts.Count); // TEST
            return selectedParts;
        }


        
        // Get parts in a list of a certain type of part
        private List<ProcWeaponUniquePart> GetPartsOfThisPartType(List<ProcWeaponUniquePart> partList, string weaponType, string usedPartType)
        {
            List<ProcWeaponUniquePart> selectedParts = new List<ProcWeaponUniquePart>();
            
            for (int part = 0; part < partList.Count; part++)
            {
                if (partList[part].usedPartType.weaponType == weaponType && partList[part].usedPartType.weaponPartType == usedPartType)
                {
                    Debug.Log("Item of " + usedPartType + ": " + partList[part]); // TEST
                    selectedParts.Add(partList[part]);
                }
            }
            return selectedParts;
        }
        
        
        // Check if a part list already contains a the given part type
        private bool CheckContainsPartType(List<ProcWeaponUniquePart> partList, string currentWeaponPartType)
        {
            for (int part = 0; part < partList.Count; part++)
            {
                if (partList[part].usedPartType.weaponPartType == currentWeaponPartType)
                {
                    return true;
                }
            }

            return false;
        }
        
        
        
        // Spawn a weapon with said used parts
        public void SpawnWeapon(List<ProcWeaponUniquePart> usedParts)
        {
            //var newGameObject = 
        }
    }
}
