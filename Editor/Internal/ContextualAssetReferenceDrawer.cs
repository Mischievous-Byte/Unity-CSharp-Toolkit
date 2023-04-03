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
            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            SerializedProperty contextProperty = property.FindPropertyRelative("context");

            property.isExpanded = true;


            Rect modifierPosition = position;
            modifierPosition.height = EditorGUIUtility.singleLineHeight;

            //EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(modifierPosition, valueProperty, label);

            //if (EditorGUI.EndChangeCheck())
                //contextProperty.managedReferenceValue = Activator.CreateInstance((valueProperty.objectReferenceValue as IContextualAsset).ContextType);

            EditorGUI.PropertyField(position, contextProperty, new GUIContent(new string(' ', label.text.Length)), true);
        }
    }
}
