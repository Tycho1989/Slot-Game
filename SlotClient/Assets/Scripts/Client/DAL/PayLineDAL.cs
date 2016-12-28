/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：PayLineDAL.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-5
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using Slot.Utils;
using System.Collections.Generic;
using System;

/// <summary>
/// 文件名:赔付线数据访问层
/// 说明:
/// </summary>
public class PayLineDAL 
{
	/// <summary>
	/// 获取设置
	/// </summary>
	public static List<PayLineData> GetConfig()
	{
		string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_PAYLINECONFIG));
		List<PayLineData> listLine = new List<PayLineData>();
		XDocument xml = XDocument.Load(path);
		foreach (XElement ele in xml.Root.Elements())
		{
			try
			{
                if(ele.Name.ToString().StartsWith("Item"))
                {
                    PayLineData payLine = new PayLineData();
                    Int32.TryParse(ele.Element("ID").Value, out payLine.ID);
                    payLine.name = ele.Element("name").Value;
                    payLine.color = ColorUtils.GetColor32FromStr(ele.Element("color").Value);
                    float.TryParse(ele.Element("width").Value, out payLine.width);
                    foreach (XElement linePos in ele.Element("linePos").Elements())
                    {
                        int pos;
                        Int32.TryParse(linePos.Value, out pos);
                        payLine.listPosIndex.Add(pos);
                    }
                    listLine.Add(payLine);
                }

			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("Parse the config file [PayLineConfig.ini] error"));
			}
		}
		return listLine;
	}


    /// <summary>
    /// 获取设置
    /// </summary>
    public static void GetConfig(out int lineCount, out float durationTime)
    {
        lineCount = 0;
        durationTime = 0;
        string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_PAYLINECONFIG));
        XDocument xml = XDocument.Load(path);
        foreach (XElement ele in xml.Root.Elements())
        {
            try
            {
                if (ele.Name == "lineCount")
                {
                    Int32.TryParse(ele.Value, out lineCount);
                }
                else if (ele.Name == "durationTime")
                {
                    float.TryParse(ele.Value, out durationTime);
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning(string.Format("Parse the config file [PayLineConfig.xml] error"));
            }
        }
    }

}
