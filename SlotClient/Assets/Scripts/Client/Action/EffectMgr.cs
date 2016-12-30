/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：EffectMgr.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-27
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using DG.Tweening;
using UnityEngine;

/// <summary>
/// 文件名:动画特效管理器
/// 说明：子管理器
/// </summary>
public class EffectMgr : Singleton<EffectMgr>
{
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
        DOTween.defaultAutoKill = true;
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

}
