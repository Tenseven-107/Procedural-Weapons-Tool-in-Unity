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
            // Selected weapon
            GUILayout.Label("Current weapon", EditorStyles.boldLabel);

            // Generate new weapons
            GUILayout.Label("Generate weapon", EditorStyles.boldLabel);
        }
    }
}
