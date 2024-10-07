using System;
using System.Collections.Generic;
using System.IO;
using Tool.Logic.Monobehaviours;
using Tool.Logic.Collections;
using Tool.Logic.Parts;
using Tool.Logic.Processes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using Object = UnityEngine.Object;


namespace Tool.Editor
{
    public class ProcWeaponMenu : EditorWindow
    {
        // Logic variables
        private int _generationAmount = 1;
        public int GenerationAmount => _generationAmount;
        
        // References
        private WeaponPartCollection _partCollection;
        private ProcWeaponGenerator _procWeaponGenerator;
        
        
        // Showing the main window
        [MenuItem("Window/Procedural Weapon Generator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(ProcWeaponMenu));
        }

        // UI
        private void OnGUI()
        {
            // Generate new weapons
            GUILayout.Label("Generate weapon", EditorStyles.boldLabel);

            _partCollection = EditorGUILayout.ObjectField(new GUIContent("Part Collection"), _partCollection, typeof(WeaponPartCollection), false) as WeaponPartCollection;
            _generationAmount = EditorGUILayout.IntField("Weapons to generate", _generationAmount);
            
            if (GUILayout.Button("Generate") == true)
            {
                // Start an instance of out part generator
                if (_procWeaponGenerator == null) { _procWeaponGenerator = ScriptableObject.CreateInstance<ProcWeaponGenerator>(); }
                
                // Generate a weapon
                if (_partCollection != null)
                {
                    _procWeaponGenerator.Generate(_partCollection.parts, _generationAmount);
                }
                else { Debug.LogError( this.GetType().FullName + ": No PartCollection given!"); }
            }
            
            EditorGUILayout.Space();
        }
        
        
        // Exit Tool Menu
        private void OnDestroy()
        {
            if (_procWeaponGenerator != null) { DestroyImmediate(_procWeaponGenerator); }
        }
    }
}
