using System.Collections;
using UnityEditor;
using UnityEngine;
using Waiting.Component;

/// <summary>
///
/// name:AnchorComponentMenu
/// author:Administrator
/// date:2016/10/28 18:45:27
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Waiting.Plugin.Anchor
{
    public class AnchorComponentMenu
    {
        [MenuItem("GameObject/3D Object/AnchorComponent", false, 10000)]
        public static void CreateAnchorComponent()
        {
            GameObject anchorObject = new GameObject("AnchorObject");

            anchorObject.AddComponent<AnchorComponent>();

            if (Selection.activeObject != null) 
            {
                GameObject parent = Selection.activeObject as GameObject;
                anchorObject.transform.SetParent(parent.transform);
            }
            
        }

    }
}
