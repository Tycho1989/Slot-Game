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
using DarkTonic.MasterAudio;

/// <summary>
/// 文件名:音频管理器
/// 说明：子管理器
/// </summary>
public class AudioMgr : SingletonWithComponent<AudioMgr>
{
    private MasterAudio masterAudio;
    private Dictionary<string, AudioClip> dicAudioClip = new Dictionary<string, AudioClip>();

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void InitPre()
    {

        var BGM = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOBGM, "BGM (Colorful_Vacation)"));
        BGM.name = "BGM";
        dicAudioClip.Add(BGM.name, BGM);

        var Beep = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Beep (UI_Electric_01)"));
        Beep.name = "Beep";
        dicAudioClip.Add(Beep.name, Beep);

        var Bet = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Bet (Collect_Point_00)"));
        Bet.name = "Bet";
        dicAudioClip.Add(Bet.name, Bet);

        var Bonus = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Bonus (Jingle_Win_00)"));
        Bonus.name = "Bonus";
        dicAudioClip.Add(Bonus.name, Bonus);

        var Click = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Click (Click_Standard_02)"));
        Click.name = "Click";
        dicAudioClip.Add(Click.name, Click);

        var EarnBig = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Earn Big (Coins_Pouring_10)"));
        EarnBig.name = "EarnBig";
        dicAudioClip.Add(EarnBig.name, EarnBig);

        var EarnSmall = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Earn Small (Coins_Several_10)"));
        EarnSmall.name = "EarnSmall";
        dicAudioClip.Add(EarnSmall.name, EarnSmall);

        var Impact = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Impact (Click_Heavy_00)"));
        Impact.name = "Impact";
        dicAudioClip.Add(Impact.name, Impact);

        var Intro = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Intro (320887__rhodesmas__win-04)"));
        Intro.name = "Intro";
        dicAudioClip.Add(Intro.name, Intro);

        var Lose = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Lose (42113__wildweasel__ksmarch-chairsqueakright)"));
        Lose.name = "Lose";
        dicAudioClip.Add(Lose.name, Lose);

        var Pay = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Pay (209578__zott820__cash-register-purchase)"));
        Pay.name = "Pay";
        dicAudioClip.Add(Pay.name, Pay);

        var ReelStop = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Reel Stop (332629__treasuresounds__item-pickup)"));
        ReelStop.name = "ReelStop";
        dicAudioClip.Add(ReelStop.name, ReelStop);

        var Spin = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Spin (178416__motion-s__toaster-pop)"));
        Spin.name = "Spin";
        dicAudioClip.Add(Spin.name, Spin);

        var SpinBonus = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Spin Bonus (Climb_Rope_Loop_00)"));
        SpinBonus.name = "SpinBonus";
        dicAudioClip.Add(SpinBonus.name, SpinBonus);

        var SpinLoop = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Spin Loop (16031__hookhead__toycarwheels)"));
        SpinLoop.name = "SpinLoop";
        dicAudioClip.Add(SpinLoop.name, SpinLoop);

        var WinBig = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win Big (Jingle_Win_00)"));
        WinBig.name = "WinBig";
        dicAudioClip.Add(WinBig.name, WinBig);

        var WinMedium = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win Medium (Jingle_Win_Synth_00)"));
        WinMedium.name = "WinMedium";
        dicAudioClip.Add(WinMedium.name, WinMedium);

        var Winsmall = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win small (UI_Synth_01)"));
        Winsmall.name = "Winsmall";
        dicAudioClip.Add(Winsmall.name, Winsmall);

        var WinSpecial = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win Special (Jingle_Achievement_00)"));
        WinSpecial.name = "WinSpecial";
        dicAudioClip.Add(WinSpecial.name, WinSpecial);

        InitMasterAudio();

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

    /// <summary>
    /// 初始化MasterAudio组件
    /// </summary>
    private void InitMasterAudio()
    {
        GameObject audioListener = new GameObject("AudioListener");
        audioListener.AddComponent<AudioListener>();
        audioListener.transform.SetParent(this.gameObject.transform);

        GameObject masterAudioObj =
            AssetLoadMgr.Instance.LoadNativeAssetInst<GameObject>(string.Format("{0}/{1}", "MasterAudio", "MasterAudio"));
        masterAudioObj.name = "MasterAudio";
        //避免场景切换时被销毁
        DontDestroyOnLoad(masterAudioObj);

        if (null == masterAudioObj.GetComponent<MasterAudio>())
        {
            masterAudio = masterAudioObj.AddComponent<MasterAudio>();
        }
        else
        {
            {
                masterAudio = masterAudioObj.GetComponent<MasterAudio>();
            }
        }

        this.CreatePlaylistController("BMG", true);
        if (dicAudioClip.ContainsKey("BGM"))
        {
            this.AddSongToPlaylist("BMG", dicAudioClip["BGM"],true);
        }

        this.CreatePlaylistController("CLICK",false, false, false, false);
        if (dicAudioClip.ContainsKey("Bet"))
        {
            this.AddSongToPlaylist("CLICK", dicAudioClip["Bet"],false);
        }
    }

    /// <summary>
    /// 播放控制器
    /// </summary>
    private void CreatePlaylistController(string playlistName, bool startPlaylistOnAwake = false, bool isShuffle = false, bool isAutoAdvance = true, bool loopPlaylist = true)
    {
        MasterAudio.Playlist playlist = new MasterAudio.Playlist();
        masterAudio.musicPlaylists.Add(playlist);
        playlist.playlistName = playlistName;

        GameObject playlistControllerPfb = AssetLoadMgr.Instance.LoadNativeAsset<GameObject>(string.Format("{0}/{1}", "MasterAudio", "PlaylistController"));
        playlistControllerPfb.name = string.Format("{0}_{1}", StrDef.PLAYLISTCONTROLLER, playlistName);
        GameObject playlistControllerObj = Instantiate(playlistControllerPfb);

        if (playlistControllerObj == null)
        {
            Debug.LogWarning(string.Format("Could not find PlaylistController prefab."));
            return;
        }
        playlistControllerObj.name = string.Format("{0}_{1}{2}", StrDef.PLAYLISTCONTROLLER, playlistName, "(Clone)");
        //playlistControllerObj.transform.SetParent(masterAudio.gameObject.transform);
        PlaylistController playlistController = playlistControllerObj.GetComponent<PlaylistController>();
        playlistControllerObj.name = string.Format("{0}_{1}", StrDef.PLAYLISTCONTROLLER, playlistName);
        DontDestroyOnLoad(playlistControllerObj);
        playlistController.startPlaylistName = playlistName;
        playlistController.startPlaylistOnAwake = startPlaylistOnAwake;
        playlistController.isShuffle = isShuffle;
        playlistController.isAutoAdvance = isAutoAdvance;
        playlistController.loopPlaylist = loopPlaylist;
    }

    private void AddSongToPlaylist(string playlistName, AudioClip song, bool loopSong = false,
            float songPitch = 1f, float songVolume = 1f)
    {
        MasterAudio.AddSongToPlaylist(playlistName, song, false, songPitch, songVolume);
    }

    public void PlaySong(string playlistName, string clipName)
    {
        //foreach (var playlistController in PlaylistController.Instances)
        //{
        //    playlistController
        //}
        //MasterAudio.StartPlaylist(name, name); QueuePlaylistClip

        string name = string.Format("{0}_{1}{2}", StrDef.PLAYLISTCONTROLLER, playlistName, "(Clone)");
        //MasterAudio.QueuePlaylistClip(name, clipName);
        MasterAudio.TriggerPlaylistClip(name, clipName);


    }

    

}
