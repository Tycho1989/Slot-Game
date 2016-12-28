/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：PayLineData.cs
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
using Vectrosity;

public class PayLineData
{
	public int ID;
	public string name;
    public Color32 color;
    public float width;
    public List<int> listPosIndex = new List<int>();
    public List<Vector2> listPosIndexArr = new List<Vector2>();
    public List<Vector2> listPos = new List<Vector2>();
    public GameObject icon;
    public Color32 defaultIconColor;
    public VectorLine vectorLine;

    public PayLineData()
    {
        defaultIconColor = Color.white;
    }

}
