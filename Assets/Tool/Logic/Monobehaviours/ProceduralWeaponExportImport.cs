using System;
using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Collections;
using Tool.Logic.Parts;
using UnityEditor;
using UnityEngine;


namespace Tool.Logic.Monobehaviours
{
    public class ProceduralWeaponExportImport : MonoBehaviour
    {
        private ProceduralWeapon _body;
        private ProceduralWeaponStatistics _statContainer;

        public ProcWeaponPacked Export()
        {
            if (_body == null) { _body = GetComponent<ProceduralWeapon>(); }
            if (_statContainer == null) { _statContainer = GetComponent<ProceduralWeaponStatistics>(); }
            
            var newExport = new ProcWeaponPacked(_statContainer.WeaponName, _statContainer.Description, _body.UsedParts, _statContainer.WeaponStats);
            
            return newExport;
        }

        public void Load(ProcWeaponPacked packedWeapon)
        {
            if (_body == null) { _body = GetComponent<ProceduralWeapon>(); }
            if (_statContainer == null) { _statContainer = GetComponent<ProceduralWeaponStatistics>(); }
            
            var partList = new List<ProcWeaponUniquePart>();
            foreach (var path in packedWeapon.partPaths)
            {
                var part = (ProcWeaponUniquePart)AssetDatabase.LoadAssetAtPath(path, typeof(ProcWeaponUniquePart));
                partList.Add(part);
            }

            _body.Assemble(partList, false);
            _statContainer.LoadRawStats(packedWeapon.stats);
        }
    }


    
    // Exported weapon data
    [Serializable]
    public struct ProcWeaponPacked
    {
        public string weaponName;
        public string description;
        public List<string> partPaths;
        public List<ProcWeaponStat> stats;

        public ProcWeaponPacked(string newName, string newDescription, List<ProcWeaponUniquePart> newParts, List<ProcWeaponStat> newStats)
        {
            this.weaponName = newName;
            this.description = newDescription;

            this.partPaths = new List<string>();
            foreach (var part in newParts)
            {
                this.partPaths.Add(AssetDatabase.GetAssetPath(part));
            }
            
            this.stats = newStats;
        }
    }
}
    
