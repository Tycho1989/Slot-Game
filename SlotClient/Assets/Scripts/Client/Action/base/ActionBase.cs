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
using UnityEngine;

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

    private DelegateVoid EnterNotStarted;
    private DelegateVoid EnterIdle;
    private DelegateVoid EnterStart;
    private DelegateVoid EnterInvoking;
    private DelegateVoid EnterFinish;
    private DelegateVoid EnterBreak;

    private Dictionary<EActionState, DelegateVoid> dicEvent = new Dictionary<EActionState, DelegateVoid>();
    public ActionBase()
    {
        CurState = EActionState.NotStarted;
        this.AddEvent();
    }

    public void AddEvent()
    {
        this.AddEvent(EActionState.NotStarted, EnterNotStarted);
        this.AddEvent(EActionState.Idle, EnterIdle);
        this.AddEvent(EActionState.Start, EnterStart);
        this.AddEvent(EActionState.Invoking, EnterInvoking);
        this.AddEvent(EActionState.Finish, EnterFinish);
        this.AddEvent(EActionState.Break, EnterBreak);
    }
    public abstract void Invoke();

    //中断当前正在执行的行为
    public virtual void Stop()
    {

    }

    //回滚当前行为所执行的操作
    public virtual void Revert()
    {

    }

    private void AddEvent(EActionState state, DelegateVoid eventHandler)
    {

        if (dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is  duplicate", state));
            return;
        }
        else
        {
            dicEvent.Add(state, eventHandler);
        }
    }

    public void AddListener(EActionState state, DelegateVoid listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        dicEvent[state] += listener;
    }

    public void RemoveListener(EActionState state, DelegateVoid listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        dicEvent[state] -= listener;
    }

    private void Invoke(EActionState state)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        DelegateVoid eventHandler;
        dicEvent.TryGetValue(state, out eventHandler);
        if (null == eventHandler)
        {
            Debug.Log(string.Format("The event [{0}] is null", state));
            return;
        }
        eventHandler.Invoke();
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
                if (CurState == EActionState.Idle)
                {
                    CurState = EActionState.Start;
                    Invoke(state);
                }
                break;
            case EActionState.Invoking:
                if (CurState == EActionState.Start || CurState == EActionState.Break)
                {
                    CurState = EActionState.Invoking;
                    Invoke(state);
                }
                break;
            case EActionState.Finish:
                if (CurState == EActionState.Invoking)
                {
                    CurState = EActionState.Finish;
                    Invoke(state);
                }
                break;
            case EActionState.Break:
                if (CurState == EActionState.Invoking)
                {
                    CurState = EActionState.Break;
                    Invoke(state);
                }
                break;
        }
    }
}
