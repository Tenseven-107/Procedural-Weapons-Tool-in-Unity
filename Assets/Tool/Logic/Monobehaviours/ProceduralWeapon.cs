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
        
        // Variables
        
        
        // Generate a model
        private void Assemble()
        {
            for (int part = 0; part < _usedParts.Count; part++)
            {
                var newPartObject = Instantiate(_usedParts[part].partModel, transform);
                newPartObject.name = _usedParts[part].name;
                
            }
        }
    }
}
