using UnityEngine;
using System.Collections;

/// <summary>
///
/// name:AnchorComponent
/// author:Lawliet
/// date:2016/10/22 13:09:41
/// versions:
/// introduce:锚点组件
/// note:
/// 
/// </summary>
namespace Waiting.Component
{
    public class AnchorComponent : MonoBehaviour
    {
        /// <summary>
        /// 线框颜色
        /// </summary>
        public Color color = new Color(0.3f, 0.9f, 0.3f);

        /// <summary>
        /// 是否使用全局缩放
        /// </summary>
        public bool isUserLossyScale = false;

        /// <summary>
        /// 是否使用Handles标准尺寸
        /// </summary>
        public bool isUserHandlesSize = false;
    }
}
