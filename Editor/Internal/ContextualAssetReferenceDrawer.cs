using MischievousByte.CSharpToolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MischievousByte.CSharpToolkitEditor.Internal
{
    [CustomPropertyDrawer(typeof(ContextualAssetReference<,>))]
    public class ContextualAssetReferenceDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty contextProperty = property.FindPropertyRelative("context");

            return EditorGUI.GetPropertyHeight(contextProperty);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty assetProperty = property.FindPropertyRelative("asset");
            SerializedProperty contextProperty = property.FindPropertyRelative("context");

            property.isExpanded = true;


            Rect assetPosition = position;
            assetPosition.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(assetPosition, assetProperty, label);

            EditorGUI.PropertyField(position, contextProperty, new GUIContent(new string(' ', label.text.Length)), true);
        }
    }
}
