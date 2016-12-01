/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：AudioMgr.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016/11/1
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 文件名:音频管理器
/// 说明：子管理器
/// </summary>
public class AudioMgr : SingletonWithComponent<AudioMgr>
{
    private AudioSource audioSource;
    private Dictionary<string, AudioClip> dicAudioClip = new Dictionary<string,AudioClip>();

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void InitPre()
	{
	    if (this.gameObject.GetComponent<AudioSource>())
	    {
	        audioSource = this.gameObject.AddComponent<AudioSource>();
	    }
	    else
	    {
	        {
                audioSource = this.gameObject.GetComponent<AudioSource>();
            }
        }

        AudioClip Beep = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Beep (UI_Electric_01)");
        dicAudioClip.Add(Beep.name, Beep);

        AudioClip Bet = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Bet (Collect_Point_00)");
        dicAudioClip.Add(Bet.name, Bet);

        AudioClip BGM = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("BGM (Colorful_Vacation)");
        dicAudioClip.Add(BGM.name, BGM);

        AudioClip Bonus = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Bonus (Jingle_Win_00)");
        dicAudioClip.Add(Bonus.name, Bonus);

        AudioClip Click = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Click (Click_Standard_02)");
        dicAudioClip.Add(Click.name, Click);

        AudioClip EarnBig = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Earn Big (Coins_Pouring_10)");
        dicAudioClip.Add(EarnBig.name, EarnBig);

        AudioClip EarnSmall = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Earn Small (Coins_Several_10)");
        dicAudioClip.Add(EarnSmall.name, EarnSmall);

        AudioClip Impact = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Impact (Click_Heavy_00)");
        dicAudioClip.Add(Impact.name, Impact);

        AudioClip Intro = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Intro (320887__rhodesmas__win-04)");
        dicAudioClip.Add(Intro.name, Intro);

        AudioClip Lose = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Lose (42113__wildweasel__ksmarch-chairsqueakright)");
        dicAudioClip.Add(Lose.name, Lose);

        AudioClip Pay = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Pay (209578__zott820__cash-register-purchase)");
        dicAudioClip.Add(Pay.name, Pay);

        AudioClip ReelStop = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Reel Stop (332629__treasuresounds__item-pickup)");
        dicAudioClip.Add(ReelStop.name, ReelStop);

        AudioClip Spin = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Spin (178416__motion-s__toaster-pop)");
        dicAudioClip.Add(Spin.name, Spin);

        AudioClip SpinBonus = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Spin Bonus (Climb_Rope_Loop_00)");
        dicAudioClip.Add(SpinBonus.name, SpinBonus);

        AudioClip SpinLoop = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Spin Loop (16031__hookhead__toycarwheels)");
        dicAudioClip.Add(SpinLoop.name, SpinLoop);

        AudioClip WinBig = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Win Big (Jingle_Win_00)");
        dicAudioClip.Add(WinBig.name, WinBig);

        AudioClip WinMedium = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Win Medium (Jingle_Win_Synth_00)");
        dicAudioClip.Add(WinMedium.name, WinMedium);

        AudioClip Winsmall = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Win small (UI_Synth_01)");
        dicAudioClip.Add(Winsmall.name, Winsmall);

        AudioClip WinSpecial = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>("Win Special (Jingle_Achievement_00)");
        dicAudioClip.Add(WinSpecial.name, WinSpecial);

    }

    /// <summary>
    /// 后初始化
    /// </summary>
    protected override void InitPost()
	{

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
