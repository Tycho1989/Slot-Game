/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：TestData.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System;

/// <summary>
/// 文件名:测试数据
/// 说明：在文本文件配置符号组合，测试各个玩法及算法正确性
/// </summary>
[Serializable]
public class TestData
{
    public string[,] ArraySymbol = new string[3,5];
}
