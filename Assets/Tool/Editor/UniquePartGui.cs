using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Parts;
using Unity.Collections;
using UnityEngine;


namespace Tool.Editor
{
    using UnityEditor;
    
    [CustomEditor(typeof(ProcWeaponUniquePart))]
    public class UniquePartGui : Editor
    {
        private bool _isOpen = true;
        [ReadOnly] private string _connectionPointsProperty = "connectionPoints";
        [ReadOnly] private string _connectionPointsTooltip = "Input coördinates of the model other parts will connect to";
        
        // Updating inspector
        public override void OnInspectorGUI()
        {
            UpdateGUI();
        }

        // Drawing the UI
        private void UpdateGUI()
        {
            ProcWeaponUniquePart currentPart = (ProcWeaponUniquePart)target;

            SerializedObject serializedObject = new SerializedObject(currentPart);
            serializedObject.Update();

            var ignoredParams = new [] {"m_Script", _connectionPointsProperty};
            DrawPropertiesExcluding(serializedObject, ignoredParams);
            
            // Drawing the connection point list
            _isOpen = EditorGUILayout.Foldout(_isOpen, new GUIContent("Connection Points", _connectionPointsTooltip));

            if (_isOpen == true)
            {
                SerializedProperty propertyList = serializedObject.FindProperty(_connectionPointsProperty);
            
                for (int element = 0; element < propertyList.arraySize; element++)
                {
                    SerializedProperty property = propertyList.GetArrayElementAtIndex(element);
                    var elementName = ("ConnectionPoint " + element.ToString());
                    EditorGUILayout.PropertyField(property, new GUIContent(elementName));
                }
            }
            
            // Applying changes
            this.Repaint();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
