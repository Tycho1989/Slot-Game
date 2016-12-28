/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：SymbolData.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System;

public enum ESymbolType
{
	[Description("普通符号")]
	Normal,
	[Description("百搭符号")]
	Wild,
	[Description("分散符号")]
	Scatter
}

public enum EPayType
{
	[Description("正常组合")]
	Normal,
	[Description("免费旋转")]
	FreeSpin,
	[Description("大奖")]
	Bonus
}

[Serializable]
public class SymbolData 
{
	public int ID;
	public int instID;
	public string name;
    public ESymbolType symbolType;
	public EPayType payType;
    public string description;//说明
    public List<int> listPayFold = new List<int>();
}
