using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tool.Logic.Parts;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;


namespace Tool.Logic.Singletons
{
    [ExecuteAlways]
    public abstract class ProcWeaponGenerator : SubsystemWithProvider
    {
        // Generate a weapon
        public void Generate(List<ProcWeaponUniquePart> partList, int amount)
        {
            for (int number = 0; number < amount; number++)
            {
                List<ProcWeaponUniquePart> usedParts = GetParts();
                SpawnWeapon(usedParts);
            }
        }
        
        
        // Get a random set of parts
        private List<ProcWeaponUniquePart> GetParts()
        {
            var selectedParts = new List<ProcWeaponUniquePart>();
            return selectedParts;
        }
        
        
        // Spawn a weapon with said used parts
        public void SpawnWeapon(List<ProcWeaponUniquePart> usedParts)
        {
            var newGameObject = 
        }
    }
}
