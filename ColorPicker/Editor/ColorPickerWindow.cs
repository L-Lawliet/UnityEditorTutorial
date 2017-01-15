using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

/// <summary>
///
/// name:ColorPickerWindow
/// author:Administrator
/// date:2016/12/7 10:59:34
/// versions:
/// introduce:
/// note:
/// 
/// </summary>
namespace Assets.ColorPicker.Editor
{
    public class ColorPickerWindow : EditorWindow
    {
        [MenuItem("Tools/ColorPicker")]
        public static void ShowWindow()
        {
            //调用GetWindow创建一个面板
            EditorWindow.GetWindow<ColorPickerWindow>("ColorPicker");
        }

        /// <summary>
        /// 16进制颜色
        /// </summary>
        private string _hexColor = "FFFFFFFF";

        /// <summary>
        /// 归一化颜色值
        /// </summary>
        private string _normalColor = "1f, 1f, 1f, 1f";

        /// <summary>
        /// 32位颜色值显示
        /// </summary>
        private string _color32 = "255, 255, 255, 255";

        /// <summary>
        /// unity颜色值
        /// </summary>
        private Color _color = new Color(1, 1, 1, 1);

        void OnGUI()
        {
            string tempHexColor = EditorGUILayout.TextField("HexColor:", _hexColor);

            string tempNormalColor = EditorGUILayout.TextField("NormalColor:", _normalColor);

            string tempColor32 = EditorGUILayout.TextField("Color32:", _color32);

            Color tempColorValue = EditorGUILayout.ColorField(_color);

            if (tempHexColor != _hexColor)
            {
                _hexColor = tempHexColor;
                _color = HexToColor(_hexColor);
                UpdateColor();

                this.Repaint();
            }
            else if (tempNormalColor != _normalColor)
            {
                _normalColor = tempNormalColor;
                _color = NormalToColor(_normalColor);
                UpdateColor();

                this.Repaint();
            }
            else if (tempColor32 != _color32)
            {
                _color32 = tempColor32;
                _color = Color32ToColor(_color32);
                UpdateColor();

                this.Repaint();
            }
            else if(tempColorValue != _color)
            {
                _color = tempColorValue;
                UpdateColor();

                this.Repaint();
            }
        }

        /// <summary>
        /// 16进制转Color类
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Color HexToColor(string value)
        {
            Color color;

            value = value.Replace("0x", "");

            value = value.Replace("0X", "");

            if (value.IndexOf("#") != 0)
            {
                value = "#" + value;
            }

            ColorUtility.TryParseHtmlString(value, out color);

            return color;
        }

        /// <summary>
        /// 归一化转Color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Color NormalToColor(string value)
        {
            Color color = new Color();

            value = value.Replace(" ","");

            value = value.Replace("f", "");

            string[] values = value.Split(',');

            float[] numbers = new float[4];

            for (int i = 0; i < 4; i++)
            {
                if (i < values.Length)
                {
                    float.TryParse(values[i], out numbers[i]);

                    numbers[i] = Mathf.Clamp(numbers[i], 0.0f, 1.0f);
                }
                else
                {
                    numbers[i] = 1.0f;
                }
            }

            color.r = numbers[0];
            color.g = numbers[1];
            color.b = numbers[2];
            color.a = numbers[3];

            return color;
        }

        /// <summary>
        /// Color32转Color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private Color Color32ToColor(string value)
        {
            Color32 color = new Color32();

            value = value.Replace(" ", "");

            string[] values = value.Split(',');

            byte[] numbers = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                if (i < values.Length)
                {
                    byte.TryParse(values[i], out numbers[i]);
                }
                else
                {
                    numbers[i] = 255;
                }
            }

            color.r = numbers[0];
            color.g = numbers[1];
            color.b = numbers[2];
            color.a = numbers[3];
            
            return color;
        }

        /// <summary>
        /// 更新颜色值
        /// 把color转成各种颜色表示方式
        /// </summary>
        private void UpdateColor()
        {
            _hexColor = ColorUtility.ToHtmlStringRGBA(_color);

            _normalColor = string.Format("{0}f, {1}f, {2}f, {3}f", _color.r, _color.g, _color.b, _color.a);

            Color32 color32 = _color;

            _color32 = string.Format("{0}, {1}, {2}, {3}", color32.r, color32.g, color32.b, color32.a);
        }

        
    }
}
