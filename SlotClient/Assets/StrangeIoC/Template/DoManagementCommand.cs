using System;
 
using UnityEngine;
 
using strange.extensions.context.api;
using strange.extensions.command.impl;
 

public class DoManagementCommand : Command
{

    [Inject]
    public IManager manager { get; set; }

    public override void Execute()
    {
        manager.DoManagement();
    }

}


