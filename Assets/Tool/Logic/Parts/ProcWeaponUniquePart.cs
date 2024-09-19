using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;


namespace Tool.Logic.Parts
{
    [ExecuteAlways, CreateAssetMenu(fileName = "New Unique Part", menuName = "Procedural Weapons/New Unique Part")]
    public class ProcWeaponUniquePart : ScriptableObject
    {
        [HideInInspector, ReadOnly] public ProcWeaponTypePart usedPartType;
        [SerializeField, WriteOnly] public ProcWeaponTypePart partType;
        
        [SerializeField, Tooltip("Select a .blend or .fbx file (Any GameObject would work)")] public GameObject partModel;

        [SerializeField] public List<Vector3> connectionPoints = new List<Vector3>();


        // Called when any value is changed
        private void OnValidate()
        {
            // Set list of connection points to how many points a part type has
            if (usedPartType != partType)
            {
                usedPartType = partType;

                connectionPoints = new List<Vector3>(usedPartType.weaponConnectionPoints);
                for (int point = 0; point < usedPartType.weaponConnectionPoints; point++)
                {
                    connectionPoints.Add(Vector3.zero);
                }
            }
        }
    }
}
