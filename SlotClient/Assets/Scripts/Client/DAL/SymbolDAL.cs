using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using Slot.Utils;
using System.Collections.Generic;
using System;

public class SymbolDAL : MonoBehaviour {

	/// <summary>
	/// 获取应用设置
	/// </summary>
	/// <returns>应用设置</returns>
	public static List<Symbol> GetSymbol()
	{
		string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_SYMBOLCONFIG));
		List<Symbol> listSymbol = new List<Symbol>();
		XDocument xml = XDocument.Load(path);
		foreach (XElement ele in xml.Root.Elements())
		{
			try
			{
				Symbol symbol = new Symbol();
				symbol.symbolType = EnumUtils.Parse<ESymbolType>(ele.Element("symbolType").Value);
				symbol.payType = EnumUtils.Parse<EPayType>(ele.Element("payType").Value);
				listSymbol.Add(symbol);
				foreach (XElement payFold in ele.Element("payFold").Elements())
				{
					symbol.listPayFold.Add((int)payFold);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("Parse the config file [SymbolConfig.xml] error"));
			}
		}
		return listSymbol;
	}
}
