using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tool.Logic.Collections
{
    [CreateAssetMenu(fileName = "New Part Collection", menuName = "Procedural Weapons/Collections/New Stat Collection")]
    public class WeaponStatCollection : ScriptableObject
    {
        [SerializeField] public List<Stat> stats = new List<Stat>();
    }
    
    [System.Serializable]
    public struct Stat
    {
        public string statName;
        public float value;
        public bool singularStat;
    }
}
