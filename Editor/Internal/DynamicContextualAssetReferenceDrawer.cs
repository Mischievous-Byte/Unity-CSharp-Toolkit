using MischievousByte.CSharpToolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            SerializedProperty assetProperty = property.FindPropertyRelative("asset");
            SerializedProperty contextProperty = property.FindPropertyRelative("context");
            SerializedProperty typeNameProperty = property.FindPropertyRelative("typeName");

            property.isExpanded = true;

            bool hasAsset = assetProperty.objectReferenceValue != null;

            Type type = AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(typeNameProperty.stringValue)).Where(t => t != null).FirstOrDefault();

            Rect valuePosition = position;
            valuePosition.height = EditorGUIUtility.singleLineHeight;

            var obj = EditorGUI.ObjectField(valuePosition, label, assetProperty.objectReferenceValue, type, true);

            if (obj == null)
            {
                assetProperty.objectReferenceValue = null;
                return;
            }


            if (!IsContextualAsset(obj.GetType()))
                return;

            assetProperty.objectReferenceValue = obj;

            if (contextProperty.managedReferenceValue == null)
                return;

            EditorGUI.PropertyField(position, contextProperty, new GUIContent(new string(' ', label.text.Length)), true);
        }


        private bool IsContextualAsset(Type type)
        {
            while(!(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ContextualAsset<>)))
            {
                type = type.BaseType;

                if (type == null)
                    return false;
            }

            return true;
        }
    }
}
