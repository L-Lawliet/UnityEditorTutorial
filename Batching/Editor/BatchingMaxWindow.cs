using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;
using Assets.Batching.Editor;

/// <summary>
///
/// name:ComponentBatchingWindow
/// author:Administrator
/// date:2016/8/25 14:06:19
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Waiting.Plugin.Batching
{

    public class BatchingMaxWindow : EditorWindow
    {
        [MenuItem("Tools/BatchingMax")]
        public static void ShowWindow()
        {
            //调用GetWindow创建一个面板
            EditorWindow.GetWindow<BatchingMaxWindow>("BatchingMax");
        }

        /// <summary>
        /// 移动增量
        /// </summary>
        private RandomVector3 _position;

        /// <summary>
        /// 旋转增量
        /// </summary>
        private Vector3 _rotation = Vector3.zero;

        /// <summary>
        /// 缩放增量
        /// </summary>
        private Vector3 _scale = Vector3.zero;

        /// <summary>
        /// 复制数量
        /// </summary>
        private int _number = 0;

        /// <summary>
        /// 绘制UI
        /// </summary>
        void OnGUI()
        {
            RandomVector3Field("Position", _position);

            //EditorGUILayout.FloatField("asd", 1);

            /*EditorGUILayout.LabelField("Position");

            EditorGUILayout.BeginHorizontal();

            EditorGUI.indentLevel++;
            
            EditorGUILayout.TextField("X", "0");

            EditorGUILayout.TextField("Y", "0");

            EditorGUILayout.TextField("Z", "0");

            EditorGUI.indentLevel--;

            EditorGUILayout.EndHorizontal();*/

            //_position = EditorGUILayout.Vector3Field("Position", _position);

            _rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);

            /*_scale = EditorGUILayout.Vector3Field("Scale", _scale);

            EditorGUILayout.Space();

            _number = Mathf.Max(EditorGUILayout.IntField("Number", _number), 0);

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Generate"))
            {
                Generate();
            }

            bool isCancel = GUILayout.Button("Cancel");

            EditorGUILayout.EndHorizontal();

            if (isCancel)
            {
                Cancel();
            }*/

            if (GUILayout.Button("Generate"))
            {
                GameObject go = GameObject.Find("Target");

                Debug.Log(go.transform.localPosition);
            }
        }

        private RandomVector3 RandomVector3Field(string label, RandomVector3 value)
        {
            EditorGUILayout.LabelField(label);

            EditorGUILayout.BeginHorizontal();

            EditorGUI.indentLevel++;

            RandomField("X", value.x);

            RandomField("Y", value.x);

            RandomField("Z", value.x);

            EditorGUI.indentLevel--;

            EditorGUILayout.EndHorizontal();

            return value;
        }

        private Vector3 RandomField(string label, Vector3 value)
        {
            //GUIStyle style = new GUIStyle();

            EditorGUIUtility.labelWidth = 13f;

            string str = String.Format("{0}, {1}, {2}", value.x, value.y, value.z);

            EditorGUILayout.TextField(label, str);

            return value;
        }

        /// <summary>
        /// 生成复制对象
        /// </summary>
        private void Generate()
        {
            
        }

        /// <summary>
        /// 取消步骤
        /// </summary>
        private void Cancel()
        {
            Undo.PerformUndo();
        }

    }
}
