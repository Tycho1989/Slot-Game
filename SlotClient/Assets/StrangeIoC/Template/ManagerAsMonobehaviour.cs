using UnityEngine;
using System.Collections;

public class ManagerAsMonobehaviour : MonoBehaviour,IManager
{
    #region IManager implementation
    public void DoManagement()
    {
        Debug.Log("Manager implemented as MonoBehaviour");
    }
    #endregion

}
