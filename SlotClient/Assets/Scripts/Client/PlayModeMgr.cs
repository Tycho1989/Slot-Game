/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：PlayModeMgr.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-27
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;

/// <summary>
/// 文件名:规则管理器
/// 说明：子管理器，控制游戏玩法
/// </summary>
public class PlayModeMgr : Singleton<PlayModeMgr>
{

    public PlayMode CurrentMode;

    //正常组合
    public PlayMode DefaultMode;
    //免费旋转
    public PlayMode FreeSpinMode;
    //大奖
    public PlayMode BonusMode;

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void Init()
    {
        CurrentMode = DefaultMode;
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
