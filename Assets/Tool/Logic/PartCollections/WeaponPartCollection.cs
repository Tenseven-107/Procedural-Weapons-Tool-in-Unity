using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Parts;
using UnityEngine;


namespace Tool.Logic.PartCollections
{
    [CreateAssetMenu(fileName = "New Part Collection", menuName = "Procedural Weapons/New Part Collection")]
    public class WeaponPartCollection : ScriptableObject
    {
        [SerializeField] public List<ProcWeaponUniquePart> parts = new List<ProcWeaponUniquePart>();
    }
}