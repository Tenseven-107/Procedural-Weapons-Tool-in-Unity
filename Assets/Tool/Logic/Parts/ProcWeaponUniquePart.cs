using System;
using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Collections;
using Unity.Collections;
using UnityEngine;



namespace Tool.Logic.Parts
{
    [ExecuteAlways, CreateAssetMenu(fileName = "New Unique Part", menuName = "Procedural Weapons/New Unique Part")]
    public class ProcWeaponUniquePart : ScriptableObject
    {
        [HideInInspector] public ProcWeaponTypePart partType;
        [SerializeField] private ProcWeaponTypePart editorPartType;
        
        [HideInInspector] public WeaponStatCollection statCollection;
        [SerializeField] private WeaponStatCollection editorStatCollection;
        [SerializeField, NonReorderable] public List<ProcWeaponStat> stats = new List<ProcWeaponStat>();
        
        [Header("Model")]
        [SerializeField, Tooltip("Select a .blend or .fbx file (Any GameObject would work)")] public GameObject partModel;
        [SerializeField] public List<Vector3> connectionPoints = new List<Vector3>();
        

        
        // NOTE: This is for the editor to update values when others are changed
        // Called when any value is changed
        private void OnValidate()
        {
            // Set list of stats
            if (statCollection != editorStatCollection)
            {
                statCollection = editorStatCollection;
                
                stats.Clear();
                for (int stat = 0; stat < statCollection.stats.Count; stat++)
                {
                    var currentStat = statCollection.stats[stat];
                    stats.Add(currentStat);
                }
            }
            
            // Set list of connection points to how many points a part type has
            if (partType != editorPartType)
            {
                partType = editorPartType;

                connectionPoints.Clear();
                for (int point = 0; point < partType.weaponConnectionPoints; point++)
                {
                    connectionPoints.Add(Vector3.zero);
                }
            }
        }
    }
}
