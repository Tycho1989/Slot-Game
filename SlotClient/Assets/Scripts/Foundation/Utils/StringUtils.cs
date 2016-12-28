using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

    /// <summary>
    /// 把字符串按照分隔符转换成 List
    /// </summary>
    /// <param name="str">源字符串</param>
    /// <param name="speater">分隔符</param>
    /// <param name="toLower">是否转换为小写</param>
    /// <returns></returns>
    public static List<string> GetStrArray(string str, char speater, bool toLower)
    {
        List<string> list = new List<string>();
        string[] ss = str.Split(speater);
        foreach (string s in ss)
        {
            if (!string.IsNullOrEmpty(s) && s != speater.ToString())
            {
                string strVal = s;
                if (toLower)
                {
                    strVal = s.ToLower();
                }
                list.Add(strVal);
            }
        }
        return list;
    }

    /// <summary>
    /// 分割字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="splitstr"></param>
    /// <returns></returns>
    public static string[] SplitMulti(string str, string splitstr)
    {
        string[] strArray = null;
        if ((str != null) && (str != ""))
        {
            strArray = new Regex(splitstr).Split(str);
        }
        return strArray;
    }
}
