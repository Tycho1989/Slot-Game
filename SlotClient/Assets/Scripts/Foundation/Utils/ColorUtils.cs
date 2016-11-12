using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Globalization;

public class ColorUtils
{
    /// <summary>
    /// 十六进制转Color32
    /// </summary>
    public static Color32 GetColor32FromStr(string str)
    {
        string[] color = StringUtils.GetArrayFromString(str, 2);
        byte R, G, B, A;
        byte.TryParse(color[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out R);
        byte.TryParse(color[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out G);
        byte.TryParse(color[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out B);
        byte.TryParse(color[3], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out A);
        return new Color32(R,G,B,A);
    }
}
