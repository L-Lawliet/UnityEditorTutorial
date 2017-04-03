using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

/// <summary>
///
/// name:GUIExtendWindow
/// author:Administrator
/// date:2017/3/30 10:08:31
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Assets.Lab.GUIExtend.Editor
{
    public class GUIExtendWindow : EditorWindow
    {
        [MenuItem("Tools/GUIExtend")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<GUIExtendWindow>("GUIExtend");
        }

        private string _folderPath;
        private string _filePath;

        void OnGUI()
        {
            _folderPath = OpenFolderPanelField(_folderPath, "Select Folder", "please select Folder");
            _filePath = OpenFilePanelField(_filePath, "Select File", "please select file", "unity");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">选择的路径</param>
        /// <param name="buttonLabel">按钮上的文字</param>
        /// <param name="tips">提示</param>
        /// <returns></returns>
        private string OpenFolderPanelField(string path, string buttonLabel, string tips)
        {
            bool disabled;

            string content;

            if (string.IsNullOrEmpty(path))
            {
                disabled = true;

                content = tips;
            }
            else
            {
                disabled = false;

                content = path;
            }

            EditorGUILayout.BeginHorizontal();
            
            EditorGUI.BeginDisabledGroup(disabled);
            EditorGUILayout.TextArea(content, EditorStyles.label);
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button(buttonLabel, GUILayout.Width(100)))
            {
                string currentDirectory;

                if (string.IsNullOrEmpty(path))
                {
                    currentDirectory = Directory.GetCurrentDirectory();
                }
                else
                {
                    currentDirectory = path;
                }

                path = EditorUtility.OpenFolderPanel(tips, currentDirectory, "");
            }

            EditorGUILayout.EndHorizontal();

            return path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">选择的文件路径</param>
        /// <param name="buttonLabel">按钮上的文字</param>
        /// <param name="tips">提示</param>
        /// <param name="extension">选择的文件后缀</param>
        /// <returns></returns>
        private string OpenFilePanelField(string path, string buttonLabel, string tips, string extension)
        {
            bool disabled;

            string content;

            if (string.IsNullOrEmpty(path))
            {
                disabled = true;

                content = tips;
            }
            else
            {
                disabled = false;

                content = path;
            }

            EditorGUILayout.BeginHorizontal();

            EditorGUI.BeginDisabledGroup(disabled);
            EditorGUILayout.TextArea(content, EditorStyles.label);
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button(buttonLabel, GUILayout.Width(100)))
            {
                string currentDirectory;

                if (string.IsNullOrEmpty(path))
                {
                    currentDirectory = Directory.GetCurrentDirectory();
                }
                else
                {
                    currentDirectory = path;
                }

                path = EditorUtility.OpenFilePanel(tips, currentDirectory, extension);
            }

            EditorGUILayout.EndHorizontal();

            return path;
        }
    }
}
