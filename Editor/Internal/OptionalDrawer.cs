using MischievousByte.CSharpToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MischievousByte.CSharpToolkitEditor.Internal
{
    [CustomPropertyDrawer(typeof(Optional<>))]
    public class OptionalDrawer : PropertyDrawer
    {
        private const float checkboxWidth = 14f;
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = property.FindPropertyRelative("value");

            return EditorGUI.GetPropertyHeight(valueProperty);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUIContent content = new GUIContent(label);
            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            SerializedProperty enabledProperty = property.FindPropertyRelative("enabled");

            float error = 20f;
            Rect r = position;
            r.width = error;
            r.x = EditorGUIUtility.labelWidth;
            r.height = EditorGUIUtility.singleLineHeight;

            enabledProperty.boolValue = EditorGUI.Toggle(r, enabledProperty.boolValue);

            EditorGUI.PropertyField(position, valueProperty, content, true);
        }
    }
}
