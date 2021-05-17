using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// ������������ ���� � ���� ������������������ ���� (��������, #FFFFFFFF)
        /// </summary>
        public static string ToHexadecimal(this Color color)
        {
            string code = "#";
            code += ToInt(color.r).ToString("X2");
            code += ToInt(color.g).ToString("X2");
            code += ToInt(color.b).ToString("X2");
            code += ToInt(color.a).ToString("X2");

            return code;

            int ToInt(float from)
            {
                return (int) (from * 255);
            }
        }

        /// <summary>
        /// ���������� ��� �� ���� � ��������� � ��������� ��������� ������������.
        /// </summary>
        public static Color SetAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}
