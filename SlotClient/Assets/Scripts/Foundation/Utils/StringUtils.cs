using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class StringUtils
{
    /// <summary>
    /// 将字符串按指定长度分割
    /// </summary>
    public static string[] GetArrayFromString(string val,int length)
    {
        var count = val.Length % length == 0 ? val.Length / length : val.Length / length + 1;
        string[] result = new string[count];
        for (var i = 0; i < count; i++)
        {
            string str = val.Substring(length*i, length);
            result[i] = str;
        }
        return result;
    }
}
