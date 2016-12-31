/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：PlayMode.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-1
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;
using System.Collections;
using System.ComponentModel;
using DG.Tweening;

//旋转模式
public enum SpinMode
{
    [Description("自动停止")]
    AutoStop,
    [Description("手动停止")]
    ManualStop
}
//停止模式
public enum SpinStopMode
{
    [Description("同时停止")]
    StopAll,
    [Description("按顺序停止")]
    StopOnebyone,
    [Description("单独停止")]
    StopOne
}

/// <summary>
/// 文件名:规则设定
/// 说明：
/// </summary>
public class PlayMode
{
    public SpinMode spinMode;
    public SpinStopMode spinStopMode;
    //每条赔付线赌注
    public float betCountPerLine;

    //自动旋转模式最高速旋转时间到执行减速过程花费时间
    public float autoStopTime;
    //点击"Spin"按钮到卷轴开始旋转的延迟时间
    public float spinStartDelay;
    //点击"Finish"按钮或者自动停止到卷轴停止旋转的延迟时间
    public float spinStopDelay;

    //卷轴旋转的最大速度
    public float reelMaxSpeed;
    //卷轴从开始旋转到最大速度花费时间
    public float reelAccelerateTime;
    //加速方式
    public Ease reelAccelerateEase;

    //卷轴从最大速度到停止旋转花费时间
    public float reelStopTime;
    //停止方式
    public Ease reelStopEase;

    public PlayMode()
    {
        spinMode = SpinMode.AutoStop;
        spinStopMode = SpinStopMode.StopOnebyone;
        betCountPerLine = 5f;

        autoStopTime = 1f;
        spinStartDelay = 0.3f;
        spinStopDelay = 0.6f;

        reelMaxSpeed = 2000f;
        reelAccelerateTime = 0.5f;
        reelAccelerateEase = Ease.InSine;

        reelStopTime = 0.5f;
        reelStopEase = Ease.OutBack;
    }

}
