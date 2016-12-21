using UnityEngine;
using System.Collections;

public class TemplateManager : IManager
{

    public TemplateManager()
    {
    }

    #region IManager implementation
    public void DoManagement()
    {
        Debug.Log("Manager implemented as a normal class");
    }
    #endregion

}

