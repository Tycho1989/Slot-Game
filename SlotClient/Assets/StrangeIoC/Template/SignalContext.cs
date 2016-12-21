/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：SignalContext.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Justin
* 创建日期：2016-12-8
* 修 改 人：
* 修改日期：
* 描	述：模块的内部各层的处理中心,实现和绑定M层、C层、V层的关系。
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using UnityEngine;

using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using strange.extensions.context.api;

/// <summary>
/// 文件名:
/// 说明：解除原来的event(事件)机制，绑定新的signal(信号)机制
/// </summary>
public class SignalContext : MVCSContext
{

    public SignalContext(MonoBehaviour contextView) : base(contextView)
    {
    }

    /// <summary>
    /// 模块初次启动会执行该方法
    /// </summary>
    public override IContext Start()
    {
        base.Start();
        return this;
    }


    /// <summary>
    /// 解除原来的事件机制，绑定新的信号机制(IOC有两套消息通讯机制，只能选择一个使用，如果添加了下列代码，则使用Signal方式的机制)
    /// </summary>
    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        // bind signal command binder
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    public override void Launch()
    {
        base.Launch();
    }

}