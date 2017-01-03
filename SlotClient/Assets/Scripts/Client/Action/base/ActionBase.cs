/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：ActionBase.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-30
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 文件名:行为状态划分
/// 说明:
/// </summary>
public enum EActionState
{
    [Description("准备")]
    NotStarted,
    [Description("准备完成")]
    Idle,
    [Description("开始")]
    Start,
    [Description("进行")]
    Invoking,
    [Description("完成")]
    Finish,
    [Description("中断")]
    Break,
}
/// <summary>
/// 文件名:行为基类
/// 说明:
/// </summary>
public abstract class ActionBase
{
    /// <summary>
    /// 当前状态
    /// </summary>
    private EActionState curState;
    public EActionState CurState
    {
        get { return curState; }
        private set { curState = value; }
    }    

    //准备完成标志
    private bool isInitialized = false;

    private Dictionary<EActionState, List<System.Delegate>> dicEvent = new Dictionary<EActionState, List<System.Delegate>>();
    public ActionBase()
    {
        CurState = EActionState.NotStarted;
    }

    protected abstract void Invoke();

    //中断当前正在执行的行为
    public virtual void Stop()
    {

    }

    //回滚当前行为所执行的操作
    public virtual void Revert()
    {

    }

    #region 添加回调

    public void AddEvent(EActionState state, System.Delegate listener)
    {
        List<System.Delegate> listDlg = new List<System.Delegate>();
        if (!dicEvent.ContainsKey(state) || null == dicEvent[state] || dicEvent[state].Count == 0)
        {
            listDlg.Add(listener);
            dicEvent[state] = listDlg;
            return;
        }

        listDlg = dicEvent[state];

        System.Delegate dlg = listDlg.Where(m => m.Equals(listener)).FirstOrDefault();
        System.Delegate.Combine(dlg, listener);
    }
    public void AddListener(EActionState state, Callback listener)
    {
        this.AddEvent(state,listener);
    }

    public void AddListener<T>(EActionState state, Callback<T> listener)
    {
        this.AddEvent(state, listener);
    }

    public void AddListener<T0,T1>(EActionState state, Callback<T0, T1> listener)
    {
        this.AddEvent(state, listener);
    }

    public void AddListener<T0,T1,T2>(EActionState state, Callback<T0, T1, T2> listener)
    {
        this.AddEvent(state, listener);
    }
    #endregion

    #region  去除回调
    public void RemoveAllListener(EActionState state)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", state));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[state];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", state));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (null != listDlg[i])
            {
                System.Delegate.RemoveAll(listDlg[i], listDlg[i]);
            }
        }
    }
    public void RemoveListener(EActionState state, Callback listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", state));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[state];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", state));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback callback = listDlg[i] as Callback;
                    callback -= listener;
                }
            }
        }
    }

    public void RemoveListener<T>(EActionState state, Callback<T> listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", state));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[state];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", state));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback<T> callback = listDlg[i] as Callback<T>;
                    callback -= listener;
                }
            }
        }
    }

    public void RemoveListener<T0, T1>(EActionState state, Callback<T0, T1> listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", state));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[state];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", state));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback<T0,T1> callback = listDlg[i] as Callback<T0,T1>;
                    callback -= listener;
                }
            }
        }
    }

    public void RemoveListener<T0, T1, T2>(EActionState state, Callback<T0, T1, T2> listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", state));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[state];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", state));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback<T0, T1, T2> callback = listDlg[i] as Callback<T0, T1, T2>;
                    callback -= listener;
                }
            }
        }
    }
    #endregion

    private void Invoke(EActionState state)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        List<System.Delegate> listdDlg = dicEvent[state];
        if (null == listdDlg)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", state));
            return;
        }

        foreach (System.Delegate dlg in listdDlg)
        {
            if (null != dlg)
            {
                dlg.DynamicInvoke();
            }
        }
    }

    public void Enter(EActionState state)
    {
        switch (state)
        {
            case EActionState.NotStarted:
                if (!isInitialized)
                {
                    CurState = EActionState.NotStarted;
                    Invoke(state);
                    isInitialized = true;
                }
                break;
            case EActionState.Idle:
                {
                    CurState = EActionState.Idle;
                    Invoke(state);
                }
                break;
            case EActionState.Start:
                if(true)// (CurState == EActionState.Idle)
                {
                    CurState = EActionState.Start;
                    Invoke(state);
                }
                break;
            case EActionState.Invoking:
                if(true)// (CurState == EActionState.Start || CurState == EActionState.Break)
                {
                    CurState = EActionState.Invoking;
                    Invoke(state);
                }
                break;
            case EActionState.Finish:
                if(true)// (CurState == EActionState.Invoking)
                {
                    CurState = EActionState.Finish;
                    Invoke(state);
                }
                break;
            case EActionState.Break:
                if(true)// (CurState == EActionState.Invoking)
                {
                    CurState = EActionState.Break;
                    Invoke(state);
                }
                break;
        }
    }
}
