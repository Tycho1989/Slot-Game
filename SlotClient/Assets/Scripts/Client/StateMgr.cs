/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：StateMgr.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-1
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/// <summary>
/// 应用状态
/// </summary>
public enum EState
{
    [Description("准备")]
    NotStarted,
    [Description("准备完成")]
    Idle,
    [Description("旋转开始")]
    SpinStarting,
    [Description("旋转进行")]
    Spinning,
    [Description("旋转结束")]
    SpinStopping,
    [Description("统计")]
    Result,
}

/// <summary>
/// 文件名:线程安全单例模板
/// 说明：
/// </summary>
public class StateMgr : Singleton<StateMgr>
{
    /// <summary>
    /// 当前状态
    /// </summary>
    private EState curState;
    public EState CurState
    {
        get { return curState; }
        private set { curState = value; }
    }

    //应用初始化标志
    private bool isInitialized = false;

    private Callback EnterNotStarted;
    private Callback EnterIdle;
    private Callback EnterSpinStarting;
    private Callback EnterSpinning;
    private Callback EnterSpinStopping;
    private Callback EnterResult;

    private Dictionary<EState, Callback> dicEvent = new Dictionary<EState,Callback>();
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init()
    {
        CurState = EState.NotStarted;
        this.AddEvent();
    }

    public void AddEvent()
    {
        this.AddEvent(EState.NotStarted, EnterNotStarted);
        this.AddEvent(EState.Idle, EnterIdle);
        this.AddEvent(EState.SpinStarting, EnterSpinStarting);
        this.AddEvent(EState.Spinning, EnterSpinning);
        this.AddEvent(EState.SpinStopping, EnterSpinStopping);
        this.AddEvent(EState.Result, EnterResult);
    }


    /// <summary>
    /// 清理（多次）
    /// </summary>
    protected override void Clear()
    {

    }

    /// <summary>
    /// 结束（一次）
    /// </summary>
    protected override void Finish()
    {

    }

    private void AddEvent(EState state, Callback eventHandler)
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

    public void AddListener(EState state, Callback listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        dicEvent[state]+= listener;
    }

    public void RemoveListener(EState state, Callback listener)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        dicEvent[state] -= listener;
    }

    private void Invoke(EState state)
    {
        if (!dicEvent.ContainsKey(state))
        {
            Debug.Log(string.Format("The event [{0}] is not exist", state));
            return;
        }

        Callback eventHandler;
        dicEvent.TryGetValue(state, out eventHandler);
        if(null == eventHandler)
        {
            Debug.Log(string.Format("The event [{0}] is null", state));
            return;
        }
        eventHandler.Invoke();
    }


    public void Enter(EState state)
    {
        switch(state)
        {
            case EState.NotStarted:
                if (!isInitialized)
                {
                    CurState = EState.NotStarted;
                    Invoke(state);
                    isInitialized = true;
                }
                break;
            case EState.Idle:
                {
                    CurState = EState.Idle;
                    Invoke(state);
                }
                break;
            case EState.SpinStarting:
                if (CurState == EState.Idle)
                {
                    CurState = EState.SpinStarting;
                    Invoke(state);
                }
                break;
            case EState.Spinning:
                if (CurState == EState.SpinStarting|| CurState == EState.SpinStopping)
                {
                    CurState = EState.Spinning;
                    Invoke(state);
                }
                break;
            case EState.SpinStopping:
                if (CurState == EState.Spinning)
                {
                    CurState = EState.SpinStopping;
                    Invoke(state);
                }
                break;
            case EState.Result:
                if (CurState == EState.Spinning)
                {
                    CurState = EState.Result;
                    Invoke(state);
                }
                break;
        }
    }

}
