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


using DG.Tweening;
using Newtonsoft.Json;
using Slot.Utils;
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
        string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_DEFAULTMODECONFIG));
        var jsonData = FileUtils.ReadFile(path);
        DefaultMode = JsonConvert.DeserializeObject<PlayMode>(jsonData);

        path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_FREESPINMODECONFIG));
        jsonData = FileUtils.ReadFile(path);
        FreeSpinMode = JsonConvert.DeserializeObject<PlayMode>(jsonData);

        path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_BONUSMODECONFIG));
        jsonData = FileUtils.ReadFile(path);
        BonusMode = JsonConvert.DeserializeObject<PlayMode>(jsonData);

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

    private void SetConfig()
    {
        DefaultMode = new PlayMode()
        {
            spinMode = SpinMode.AutoStop,
            spinStopMode = SpinStopMode.StopOnebyone,
            betCountPerLine = 5f,

            autoStopTime = 1f,
            spinStartDelay = 0.3f,
            spinStopDelay = 0.6f,

            reelMaxSpeed = 2000f,
            reelAccelerateTime = 0.5f,
            reelAccelerateEase = Ease.InSine,

            reelStopTime = 0.5f,
            reelStopEase = Ease.OutBack
        };

        var jsonData = JsonConvert.SerializeObject(DefaultMode);
        string path = FileUtils.GetStreamingCFilePath(string.Format(StrDef.PATH_DEFAULTMODECONFIG));
        FileUtils.WriteFile(path, jsonData);
    }

    /// <summary>
    /// 切换玩法
    /// </summary>
    public void SwitchPlayMode(PlayMode mode)
    {
        if (null == mode)
        {
            return;
        }

        if (mode == CurrentMode)
        {
            return;
        }
        CurrentMode = mode;
    }

}
