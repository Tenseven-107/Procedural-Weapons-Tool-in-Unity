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
    [ExecuteAlways, CreateAssetMenu(fileName = "New_Unique_Part", menuName = "Procedural Weapons/New Unique Part")]
    public class ProcWeaponUniquePart : ScriptableObject
    {
        [HideInInspector, ReadOnly] public ProcWeaponTypePart partType;
        [SerializeField] public ProcWeaponTypePart newPartType;
        
        [SerializeField, Tooltip("Select a .blend or .fbx file (Any object would work)")] public Object partModel;

        [SerializeField] public List<Vector3> connectionPoints = new List<Vector3>();


        // Called when any value is changed
        private void OnValidate()
        {
            // Set list of connection points to how many points a part type has
            if (partType != newPartType)
            {
                partType = newPartType;

                connectionPoints = new List<Vector3>(partType.weaponConnectionPoints);
                for (int point = 0; point < partType.weaponConnectionPoints; point++)
                {
                    connectionPoints.Add(Vector3.zero);
                }
            }
        }
    }
}
