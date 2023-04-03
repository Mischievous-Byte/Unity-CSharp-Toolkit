using MischievousByte.CSharpToolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MischievousByte.CSharpToolkitEditor.Internal
{
    [CustomPropertyDrawer(typeof(DynamicContextualAssetReference<>))]
    public class DynamicContextualAssetReferenceDrawer : PropertyDrawer
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
            SerializedProperty typeNameProperty = property.FindPropertyRelative("typeName");

            property.isExpanded = true;


            Type type = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(typeNameProperty.stringValue)).Where(t => t != null).FirstOrDefault();

            Rect valuePosition = position;
            valuePosition.height = EditorGUIUtility.singleLineHeight;

            var obj = EditorGUI.ObjectField(valuePosition, label, valueProperty.objectReferenceValue, type, true);

            if(obj is ContextualAsset<>)
            EditorGUI.PropertyField(position, contextProperty, new GUIContent(new string(' ', label.text.Length)), true);
        }
    }
}
