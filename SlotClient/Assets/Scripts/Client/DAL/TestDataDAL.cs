/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：TestDataDAL.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-28
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
/// 文件名:测试数据访问层
/// 说明:
/// </summary>
public class TestDataDAL
{
	/// <summary>
	/// 获取测试数据
	/// </summary>
	public static List<TestData> GetTestData()
	{
		string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_TESTDATA));
		List<TestData> listTestData = new List<TestData>();
		XDocument xml = XDocument.Load(path);
		foreach (XElement ele in xml.Root.Elements())
		{
			try
			{
                TestData testData = new TestData();
			    string[] arrayRow1 = StringUtils.SplitMulti(ele.Element("row1").Value, ",");
			    string[] arrayRow2 = StringUtils.SplitMulti(ele.Element("row2").Value, ",");
			    string[] arrayRow3 = StringUtils.SplitMulti(ele.Element("row3").Value, ",");

			    for (int i = 0; i < testData.ArraySymbol.GetLength(0); i++)
			    {
                    for (int j = 0; j < testData.ArraySymbol.GetLength(1); j++)
                    {
                        if (i == 0)
                        {
                            testData.ArraySymbol[i, j] = arrayRow1[j];
                        }
                        if (i == 1)
                        {
                            testData.ArraySymbol[i, j] = arrayRow2[j];
                        }
                        if (i == 2)
                        {
                            testData.ArraySymbol[i, j] = arrayRow3[j];
                        }
                    }
                }
                
                listTestData.Add(testData);
			}
			catch (Exception ex)
			{
				Debug.LogWarning(string.Format("Parse the Test file [TestData.dat] error"));
			}
		}
		return listTestData;
	}
}
