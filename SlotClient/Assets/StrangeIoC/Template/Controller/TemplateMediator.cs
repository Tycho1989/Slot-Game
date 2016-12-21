using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class TemplateMediator : Mediator
{

    [Inject]
    public TemplateView view { get; set; }

    [Inject]
    public DoManagementSignal doManagement { get; set; }
    //[Inject]
    //public IManager manager { get; set; }

    public override void OnRegister()
    {
        view.buttonClicked.AddListener(doManagement.Dispatch);
    }
}
