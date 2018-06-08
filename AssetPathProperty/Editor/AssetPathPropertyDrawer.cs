using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using Waiting.UnityEngineExtend;

/// <summary>
///
/// name:AssetPathPropertyDrawer
/// author:Administrator
/// date:2018/1/20 15:23:02
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Waiting.UnityEditorExtend
{
    [CustomPropertyDrawer(typeof(AssetPathAttribute))]
    public class AssetPathPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            AssetPathAttribute attribute = (AssetPathAttribute)base.attribute;

            if (!attribute.type.IsSubclassOf(typeof(Object)))
            {
                //显示文件类型错误提示
                EditorGUI.HelpBox(position, string.Format("{0} : AssetPathAttribute.type is not subclass of UnityEngine.GameObject", property.displayName), MessageType.Error);
            }
            else
            {
                if (property.propertyType == SerializedPropertyType.String)
                {
                    //绘制属性框
                    property.stringValue = FileField(position, property.displayName, property.stringValue, attribute.type);
                }
                else
                {
                    //显示非字符串错误提示
                    EditorGUI.HelpBox(position, string.Format("{0} : property type is not System.String", property.displayName), MessageType.Error);
                }
            }
        }

        private string FileField(Rect position, string label, string path, System.Type type)
        {
            Object file = AssetDatabase.LoadAssetAtPath(path, type);

            EditorGUI.BeginChangeCheck();
            {
                file = EditorGUI.ObjectField(position, label, file, type, false);
            }

            if (EditorGUI.EndChangeCheck())
            {
                path = AssetDatabase.GetAssetPath(file);
            }

            return path;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            AssetPathAttribute attribute = (AssetPathAttribute)base.attribute;

            float baseHeight = base.GetPropertyHeight(property, label);

            if (!attribute.type.IsSubclassOf(typeof(Object)))
            {
                return baseHeight + 20.0f;
            }
            else if (property.propertyType == SerializedPropertyType.String)
            {
                return baseHeight;
            }
            else
            {
                return baseHeight + 20.0f;
            }
        }
    }
}
