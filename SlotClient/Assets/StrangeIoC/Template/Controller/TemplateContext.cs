using System;

using UnityEngine;

using strange.extensions.context.impl;
using strange.extensions.signal.impl;

public class TemplateContext : SignalContext
{

    public TemplateContext(MonoBehaviour contextView) : base(contextView)
    {
    }

    /// <summary>
    /// 绑定中心,所有绑定在这里实现
    /// </summary>
    protected override void mapBindings()
    {
        base.mapBindings();

        // we bind a command to StartSignal since it is invoked by SignalContext (the parent class) on Launch()
        commandBinder.Bind<StartSignal>().To<TemplateCommand>().Once();

        commandBinder.Bind<DoManagementSignal>().To<DoManagementCommand>().Pooled(); // THIS IS THE NEW MAPPING!!!
        // bind our view to its mediator
        mediationBinder.Bind<TemplateView>().To<TemplateMediator>();

        // bind our interface to a concrete implementation
        //injectionBinder.Bind<IManager>().To<TemplateManager>().ToSingleton();

        ManagerAsMonobehaviour manager = GameObject.Find("Manager").GetComponent<ManagerAsMonobehaviour>();
        injectionBinder.Bind<IManager>().ToValue(manager);
    }

    public override void Launch()
    {
        base.Launch();
        Signal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
    }

}
