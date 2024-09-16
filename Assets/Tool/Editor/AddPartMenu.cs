using System;
using System.Collections;
using System.Collections.Generic;
using Tool.Logic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Tool.Editor
{
    public class AddPartMenu : EditorWindow
    {
        // New part data
        private ProcWeaponTypePart _usedPart;
        private Object _usedModel;
        private int[] _connectionPoints;
        
        // New stats
        // -
        
        // UI controls
        private bool _showConnectionPoints;
        private bool _showStats;
        
        
        // Showing the part window
        public static void ShowWindow()
        {
            GetWindow(typeof(AddPartMenu));
        }
        
        
        // UI
        private void OnGUI()
        {
            // Type
            GUILayout.Label("Part type:", EditorStyles.miniLabel);
            _usedPart = (ProcWeaponTypePart)EditorGUILayout.ObjectField(_usedPart, typeof(ProcWeaponTypePart), false);
            EditorGUILayout.Space();
            
            // Model
            GUILayout.Label("Used model:", EditorStyles.miniLabel);
            _usedModel = EditorGUILayout.ObjectField(_usedModel, typeof(Mesh), false);
            EditorGUILayout.Space();
            
            // Connection points
            _showConnectionPoints = EditorGUILayout.Foldout(_showConnectionPoints, "Connection Points");
            if (_showConnectionPoints)
            {
                for (int point = 0; point < _usedPart.weaponConnectionPoints; point++)
                {
                    var status = "Connection point " + point.ToString() + ":";
                    
                    EditorGUILayout.LabelField(status); // TESTING LOOP
                    
                    //_connectionPoints[point] = EditorGUILayout.IntField(status, _connectionPoints[point]);
                }
            }
            
            // Stats
            _showStats = EditorGUILayout.Foldout(_showStats, "Stats");
            if (_showStats)
            {
                EditorGUILayout.LabelField("stats here"); // TESTING
            }
        }
    }
}