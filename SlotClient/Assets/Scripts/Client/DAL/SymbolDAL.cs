/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：SymbolDAL.cs
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
/// 文件名:符号数据访问层
/// 说明:
/// </summary>
public class SymbolDAL
{
	/// <summary>
	/// 获取应用设置
	/// </summary>
	/// <returns>应用设置</returns>
	public static List<SymbolData> GetConfig()
	{
		string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_SYMBOLCONFIG));
		List<SymbolData> listSymbol = new List<SymbolData>();
		XDocument xml = XDocument.Load(path);
		foreach (XElement ele in xml.Root.Elements())
		{
			try
			{
				SymbolData symbol = new SymbolData();
				Int32.TryParse(ele.Element("ID").Value, out symbol.ID);
				Int32.TryParse(ele.Element("instID").Value, out symbol.instID);
				symbol.name = ele.Element("name").Value;
				symbol.symbolType = EnumUtils.Parse<ESymbolType>(ele.Element("symbolType").Value);
				symbol.payType = EnumUtils.Parse<EPayType>(ele.Element("payType").Value);
				symbol.description = ele.Element("description").Value;
                listSymbol.Add(symbol);
				foreach (XElement payFold in ele.Element("payFold").Elements())
				{
					symbol.listPayFold.Add((int)payFold);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("Parse the config file [SymbolConfig.ini] error"));
			}
		}
		return listSymbol;
	}
}
