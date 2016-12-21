/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：TemplateBootstrap.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Justin
* 创建日期：2016-12-8
* 修 改 人：
* 修改日期：
* 描	述：模块启动入口,需要挂载在一个游戏物体上
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using UnityEngine;

using strange.extensions.context.impl;

/// <summary>
/// 模块视图模板
/// </summary>
public class TemplateBootstrap : ContextView
{

    void Awake()
    {
        this.context = new TemplateContext(this);
    }

}

