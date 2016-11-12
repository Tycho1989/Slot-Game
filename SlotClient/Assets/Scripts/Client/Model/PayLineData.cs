using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System;

public class PayLineData
{
	public int ID;
	public string name;
    public Color32 color;
    public float width;
    public List<int> listPosIndex = new List<int>();
    public List<Vector2> listPos = new List<Vector2>();
}
