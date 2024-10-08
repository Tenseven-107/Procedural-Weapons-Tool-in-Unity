using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tool.Logic.Collections
{
    [CreateAssetMenu(fileName = "New Part Collection", menuName = "Procedural Weapons/Collections/New Stat Collection")]
    public class WeaponStatCollection : ScriptableObject
    {
        [SerializeField] public List<ProcWeaponStat> stats = new List<ProcWeaponStat>();
    }
    
    // Stat struct
    [Serializable]
    public struct ProcWeaponStat
    {
        public string statName;
        public float statValue;
        public bool negativeStat;

        public ProcWeaponStat(string newName, float newValue, bool newNegative)
        {
            this.statName = newName;
            this.statValue = newValue;
            this.negativeStat = newNegative;
        }
    }
}
