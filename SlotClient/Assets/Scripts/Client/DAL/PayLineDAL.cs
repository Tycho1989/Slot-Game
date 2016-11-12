using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using Slot.Utils;
using System.Collections.Generic;
using System;

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
                if(ele.Name!= "lineCount")
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
				Debug.LogWarning(string.Format("Parse the config file [PayLineConfig.xml] error"));
			}
		}
		return listLine;
	}


    /// <summary>
    /// 获取设置
    /// </summary>
    public static int GetLineCount()
    {
        string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_PAYLINECONFIG));
        XDocument xml = XDocument.Load(path);
        int lineCount = 0;
        foreach (XElement ele in xml.Root.Elements())
        {
            try
            {
                if (ele.Name == "lineCount")
                {
                    Int32.TryParse(ele.Value, out lineCount);
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning(string.Format("Parse the config file [PayLineConfig.xml] error"));
            }
        }
        return lineCount;
    }

}
