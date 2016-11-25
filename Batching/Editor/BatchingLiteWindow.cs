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
            EditorWindow.GetWindow<BatchingLiteWindow>("Batching");
        }

        private Vector3 _position = Vector3.zero;

        private Vector3 _rotation = Vector3.zero;

        private Vector3 _scale = Vector3.zero;

        private int _number = 0;

        void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            _position = EditorGUILayout.Vector3Field("Position", _position);

            _rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);

            _scale = EditorGUILayout.Vector3Field("Scale", _scale);

            EditorGUILayout.Space();

            _number = Mathf.Max(EditorGUILayout.IntField("Number", _number), 0);

            EditorGUILayout.EndVertical();

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

        void OnEnabled()
        {
            
        }

        void OnDisabled()
        {
            
        }

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

                    Undo.RegisterCreatedObjectUndo(go, "Batching Create GameObject");
                }
            }
        }

        private void Cancel()
        {
            try
            {
                Undo.PerformUndo();
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }


        void OnDestroy()
        {
            
        } 
    }
}
