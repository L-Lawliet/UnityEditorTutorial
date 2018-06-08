using System;
using System.Collections;
using UnityEngine;

/// <summary>
///
/// name:AssetPath
/// author:Administrator
/// date:2018/1/20 15:19:55
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Waiting.UnityEngineExtend
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class AssetPathAttribute : PropertyAttribute 
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public System.Type type { get; set; }

        public AssetPathAttribute(System.Type type)
        {
            this.type = type;
        }
    }
}
