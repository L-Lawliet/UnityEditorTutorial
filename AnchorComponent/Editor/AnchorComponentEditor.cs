using UnityEngine;
using UnityEditor;
using System.Collections;
using Waiting.Component;

/// <summary>
///
/// name:AnchorComponentEditor
/// author:Lawliet
/// date:2016/10/22 13:04:11
/// versions:
/// introduce:AnchorComponent编辑类
/// note:
/// 
/// </summary>
namespace Waiting.Plugin.Anchor
{
    [CustomEditor(typeof(AnchorComponent))]
    public class AnchorComponentEditor : Editor
    {
        
        void OnSceneGUI()
        {
            AnchorComponent compontent = target as AnchorComponent;

            Handles.color = compontent.color;

            //绘制实心正方体
            //Handles.CubeCap(compontent.GetInstanceID(), compontent.transform.position, compontent.transform.rotation, 1.0f);

            //绘制线框正方体
            DrawWireframeBox(compontent.transform, compontent.isUserLossyScale, compontent.isUserHandlesSize);
        }

        /// <summary>
        /// 绘制线框正方体
        /// </summary>
        /// <param name="transform">描点Transform</param>
        /// <param name="isUserLossyScale">是否使用全局缩放</param>
        /// <param name="isUserHandlesSize">是否使用Handles尺寸</param>
        public void DrawWireframeBox(Transform transform, bool isUserLossyScale = false, bool isUserHandlesSize = false)
        {
            Matrix4x4 matrix = Handles.matrix;

            Vector3 size;
            
            if (isUserHandlesSize)
            {
                float handleSize = HandleUtility.GetHandleSize(transform.position);

                size = Vector3.one * handleSize;
            }
            else
            {
                size = transform.localScale;
            }

            if (isUserLossyScale)
            {
                size.Scale(transform.lossyScale);
            }

            //创建一个无缩放影响的矩阵
            Matrix4x4 tempMatrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);

            //把矩阵赋予给Handles
            Handles.matrix = tempMatrix;

            Vector3 vector = size * 0.5f;

            Vector3[] points = new Vector3[8];

            //设置正方体八个顶点
            points[0] = new Vector3(vector.x, vector.y, vector.z);
            points[1] = new Vector3(vector.x, -vector.y, vector.z);
            points[2] = new Vector3(vector.x, -vector.y, -vector.z);
            points[3] = new Vector3(vector.x, vector.y, -vector.z);
            points[4] = new Vector3(-vector.x, vector.y, vector.z);
            points[5] = new Vector3(-vector.x, -vector.y, vector.z);
            points[6] = new Vector3(-vector.x, -vector.y, -vector.z);
            points[7] = new Vector3(-vector.x, vector.y, -vector.z);

            //绘制正方体12条线
            Handles.DrawLine(points[0], points[1]);
            Handles.DrawLine(points[1], points[2]);
            Handles.DrawLine(points[2], points[3]);
            Handles.DrawLine(points[3], points[0]);

            Handles.DrawLine(points[4], points[5]);
            Handles.DrawLine(points[5], points[6]);
            Handles.DrawLine(points[6], points[7]);
            Handles.DrawLine(points[7], points[4]);

            Handles.DrawLine(points[0], points[4]);
            Handles.DrawLine(points[1], points[5]);
            Handles.DrawLine(points[2], points[6]);
            Handles.DrawLine(points[3], points[7]);

            //用与显示顶点位置与索引
            /*for (int i = 0; i < 8; i++)
            {
                Handles.Label(points[i], i.ToString());
            }*/

            Handles.matrix = matrix;
        }
    }
}
