using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tool.Logic
{
    [CreateAssetMenu(fileName = "New Weapon-type Part", menuName = "Procedural Weapons")]
    public class ProcWeaponTypePart : ScriptableObject
    {
        public string weaponType = "sword";
        public string partType = "handle";
        public ProcWeaponTypePart nextPart;
        public ProcWeaponTypePart lastPart;
        [Range(0, 2)] public int weaponConnectionPoints = 1;
    }
}
