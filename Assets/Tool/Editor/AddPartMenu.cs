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
        private ProcWeaponTypePart _usedPart;
        private Object _usedModel;
        
        
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
            _usedModel = EditorGUILayout.ObjectField(_usedModel, typeof(ProcWeaponTypePart), false);
            EditorGUILayout.Space();
            
            // Model
            GUILayout.Label("Used model:", EditorStyles.miniLabel);
            _usedModel = EditorGUILayout.ObjectField(_usedModel, typeof(Mesh), false);
            EditorGUILayout.Space();
        }
    }
}