using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tool.Editor
{
    public class ProcWeaponMenu : EditorWindow
    {
        private string _partDatabasePath; // NOTE: need to make a custom file extension for these special part databases
        private StreamReader _partDatabase;


        // Showing the main window
        [MenuItem("Window/Procedural Weapon Generator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(ProcWeaponMenu));
        }

        // UI
        private void OnGUI()
        {
            // Adding parts
            GUILayout.Label("Adding parts", EditorStyles.boldLabel);
            
            EditorGUILayout.Space();
            
            GUILayout.Label("Selected part database:", EditorStyles.miniLabel);
            GUILayout.TextField(_partDatabasePath);
            if (GUILayout.Button("Select part database"))
            {
                _partDatabasePath = EditorUtility.OpenFilePanel("Select used database", _partDatabasePath, "wpd");
                // NOTE: selecting your used database with the custom filetype .pwd (Weapon Part Database)

                if (_partDatabasePath.Length != 0)
                {
                    _partDatabase = new StreamReader(_partDatabasePath);
                }
            }
            if (GUILayout.Button("Add new part"))
            {
                AddPartMenu partMenu = CreateWindow<AddPartMenu>();
            }
            EditorGUILayout.Space();

            // Selected weapon
            GUILayout.Label("Current weapon", EditorStyles.boldLabel);

            // Generate new weapons
            GUILayout.Label("Generate weapon", EditorStyles.boldLabel);
        }
    }
}
