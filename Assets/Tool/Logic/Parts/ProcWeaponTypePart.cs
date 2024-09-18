using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool.Logic
{
    [CreateAssetMenu(fileName = "New Weapontype Part", menuName = "Procedural Weapons/New Part Type")]
    public class ProcWeaponTypePart : ScriptableObject
    {
        public string weaponType = "sword";
        public string weaponPartType = "handle";
        public ProcWeaponTypePart nextPart;
        public ProcWeaponTypePart lastPart;
        [Range(0, 2)] public int weaponConnectionPoints = 1;
    }
}
