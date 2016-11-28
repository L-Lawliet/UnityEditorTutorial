using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;

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

    public class BatchingLiteWindow : EditorWindow
    {
        [MenuItem("Tools/BatchingLite")]
        public static void ShowWindow()
        {
            //调用GetWindow创建一个面板
            EditorWindow.GetWindow<BatchingLiteWindow>("Batching");
        }

        /// <summary>
        /// 移动增量
        /// </summary>
        private Vector3 _position = Vector3.zero;

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
            _position = EditorGUILayout.Vector3Field("Position", _position);

            _rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);

            _scale = EditorGUILayout.Vector3Field("Scale", _scale);

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
            }
        }

        /// <summary>
        /// 生成复制对象
        /// </summary>
        private void Generate()
        {
            GameObject[] selectGameObjects = Selection.gameObjects;

            int len = selectGameObjects.Length;

            for (int i = 0; i < len; i++)
            {
                GameObject selectGameObject = selectGameObjects[i];

                for (int j = 0; j < _number; j++)
                {
                    GameObject go = GameObject.Instantiate<GameObject>(selectGameObject);

                    go.name = selectGameObject.name;

                    go.transform.SetParent(selectGameObject.transform.parent);

                    go.transform.localPosition = selectGameObject.transform.localPosition + _position * j;

                    go.transform.localRotation = selectGameObject.transform.localRotation * Quaternion.Euler(_rotation * j);

                    go.transform.localScale = selectGameObject.transform.localScale + _scale * j;

                    //添加Undo步骤
                    Undo.RegisterCreatedObjectUndo(go, "Batching Create GameObject");
                }
            }
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
