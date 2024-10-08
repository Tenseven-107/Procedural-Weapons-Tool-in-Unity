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
        private const string Connectionproperty = "connectionPoints";
        private const string Connectiontooltip = "Input coördinates of the model other parts will connect to";
        
        // Updating inspector
        public override void OnInspectorGUI()
        {
            UpdateGUI();
        }

        // Drawing the UI
        private void UpdateGUI()
        {
            ProcWeaponUniquePart currentPart = (ProcWeaponUniquePart)target;

            SerializedObject thisSerializedObject = new SerializedObject(currentPart);
            thisSerializedObject.Update();

            var ignoredParams = new [] {"m_Script", Connectionproperty};
            DrawPropertiesExcluding(thisSerializedObject, ignoredParams);
            
            // Drawing the connection point list
            _isOpen = EditorGUILayout.Foldout(_isOpen, new GUIContent("Connection Points", Connectiontooltip));

            if (_isOpen == true)
            {
                SerializedProperty propertyList = thisSerializedObject.FindProperty(Connectionproperty);
            
                for (int element = 0; element < propertyList.arraySize; element++)
                {
                    SerializedProperty property = propertyList.GetArrayElementAtIndex(element);
                    var elementName = ("ConnectionPoint " + element.ToString());
                    EditorGUILayout.PropertyField(property, new GUIContent(elementName));
                }
            }
            
            // Applying changes
            this.Repaint();
            thisSerializedObject.ApplyModifiedProperties();
        }
    }
}
