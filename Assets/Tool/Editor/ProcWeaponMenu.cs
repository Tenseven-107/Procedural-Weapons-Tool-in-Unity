using System;
using System.Collections.Generic;
using System.IO;
using Tool.Logic.Monobehaviours;
using Tool.Logic.Parts;
using Tool.Logic.Singletons;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;


namespace Tool.Editor
{
    public class ProcWeaponMenu : EditorWindow
    {
        // Menu handling variables
        private bool _isShowingCurrenWeapon = true;
        private string _currentWeaponStatus;
        
        // Logic variables
        private int _generationAmount;
        public int GenerationAmount => _generationAmount;
        
        // References
        private List<ProcWeaponUniquePart> _partList;
        private ProcWeaponGenerator _procWeaponGenerator;
        

        // Showing the main window
        [MenuItem("Window/Procedural Weapon Generator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(ProcWeaponMenu));
            
            // Start an instance of out part generator
            //_procWeaponGenerator = 
        }

        // UI
        private void OnGUI()
        {
            // Generate new weapons
            GUILayout.Label("Generate weapon", EditorStyles.boldLabel);

            _generationAmount = EditorGUILayout.IntField("Weapons to generate", _generationAmount);
            if (GUILayout.Button("Generate") == true)
            {
                _procWeaponGenerator.Generate(_partList, _generationAmount);
            }
            
            EditorGUILayout.Space();
            
            
            // Edit selected weapon
            GUILayout.Label("Current weapon", EditorStyles.boldLabel);

            _isShowingCurrenWeapon = EditorGUILayout.Foldout(_isShowingCurrenWeapon, _currentWeaponStatus);
            if (Selection.activeGameObject.TryGetComponent<ProceduralWeapon>(out ProceduralWeapon selectedWeapon))
            {
                _currentWeaponStatus = "Selected " + Selection.activeObject;
                
                if (_isShowingCurrenWeapon == true)
                {
                    
                }
            }
            else { _currentWeaponStatus = "Select a procedural weapon."; }
        }
    }
}
