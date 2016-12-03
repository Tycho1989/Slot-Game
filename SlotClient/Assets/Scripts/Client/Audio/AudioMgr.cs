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
using System.Diagnostics;
using UnityEngine.Audio;

public enum AudioType
{
    BGM,//背景音乐
    SFX //特效音乐
}
/// <summary>
/// 文件名:音频管理器
/// 说明：子管理器
/// </summary>
public class AudioMgr : SingletonWithComponent<AudioMgr>
{
    private AudioSource AudioSourceBGM;
    private AudioSource AudioSourceSFX;
    private Dictionary<string, AudioData> dicAudioClip = new Dictionary<string, AudioData>();


    class AudioData
    {
        public AudioClip audioClip;
        public AudioType audioType;

        public AudioData(AudioClip audioClip, AudioType audioType)
        {
            this.audioClip = audioClip;
            this.audioType = audioType;
        }
    }
    /// <summary>
    /// 初始化
    /// </summary>
    protected override void InitPre()
    {

        var BGM = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOBGM, "BGM (Colorful_Vacation)"));
        BGM.name = "BGM";
        dicAudioClip.Add(BGM.name,new AudioData(BGM, AudioType.BGM));

        var Beep = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Beep (UI_Electric_01)"));
        Beep.name = "Beep";
        dicAudioClip.Add(Beep.name, new AudioData(Beep, AudioType.SFX));

        var Bet = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Bet (Collect_Point_00)"));
        Bet.name = "Bet";
        dicAudioClip.Add(Bet.name, new AudioData(Bet, AudioType.SFX));

        var Bonus = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Bonus (Jingle_Win_00)"));
        Bonus.name = "Bonus";
        dicAudioClip.Add(Bonus.name, new AudioData(Bonus, AudioType.SFX));

        var Click = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Click (Click_Standard_02)"));
        Click.name = "Click";
        dicAudioClip.Add(Click.name, new AudioData(Click, AudioType.SFX));

        var EarnBig = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Earn Big (Coins_Pouring_10)"));
        EarnBig.name = "EarnBig";
        dicAudioClip.Add(EarnBig.name, new AudioData(EarnBig, AudioType.SFX));

        var EarnSmall = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Earn Small (Coins_Several_10)"));
        EarnSmall.name = "EarnSmall";
        dicAudioClip.Add(EarnSmall.name, new AudioData(EarnSmall, AudioType.SFX));

        var Impact = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Impact (Click_Heavy_00)"));
        Impact.name = "Impact";
        dicAudioClip.Add(Impact.name, new AudioData(Impact, AudioType.SFX));

        var Intro = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Intro (320887__rhodesmas__win-04)"));
        Intro.name = "Intro";
        dicAudioClip.Add(Intro.name, new AudioData(Intro, AudioType.SFX));

        var Lose = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Lose (42113__wildweasel__ksmarch-chairsqueakright)"));
        Lose.name = "Lose";
        dicAudioClip.Add(Lose.name, new AudioData(Lose, AudioType.SFX));

        var Pay = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Pay (209578__zott820__cash-register-purchase)"));
        Pay.name = "Pay";
        dicAudioClip.Add(Pay.name, new AudioData(Pay, AudioType.SFX));

        var ReelStop = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Reel Stop (332629__treasuresounds__item-pickup)"));
        ReelStop.name = "ReelStop";
        dicAudioClip.Add(ReelStop.name, new AudioData(ReelStop, AudioType.SFX));

        var Spin = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Spin (178416__motion-s__toaster-pop)"));
        Spin.name = "Spin";
        dicAudioClip.Add(Spin.name, new AudioData(Spin, AudioType.SFX));

        var SpinBonus = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Spin Bonus (Climb_Rope_Loop_00)"));
        SpinBonus.name = "SpinBonus";
        dicAudioClip.Add(SpinBonus.name, new AudioData(SpinBonus, AudioType.SFX));

        var SpinLoop = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Spin Loop (16031__hookhead__toycarwheels)"));
        SpinLoop.name = "SpinLoop";
        dicAudioClip.Add(SpinLoop.name, new AudioData(SpinLoop, AudioType.SFX));

        var WinBig = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win Big (Jingle_Win_00)"));
        WinBig.name = "WinBig";
        dicAudioClip.Add(WinBig.name, new AudioData(WinBig, AudioType.SFX));

        var WinMedium = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win Medium (Jingle_Win_Synth_00)"));
        WinMedium.name = "WinMedium";
        dicAudioClip.Add(WinMedium.name, new AudioData(WinMedium, AudioType.SFX));

        var Winsmall = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win small (UI_Synth_01)"));
        Winsmall.name = "Winsmall";
        dicAudioClip.Add(Winsmall.name, new AudioData(Winsmall, AudioType.SFX));

        var WinSpecial = AssetLoadMgr.Instance.LoadNativeAsset<AudioClip>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX,"Win Special (Jingle_Achievement_00)"));
        WinSpecial.name = "WinSpecial";
        dicAudioClip.Add(WinSpecial.name, new AudioData(WinSpecial, AudioType.SFX));

        InitAudio();
        this.PlaySong("BGM");
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
    private void InitAudio()
    {
        GameObject audioListener = new GameObject("AudioListener");
        audioListener.AddComponent<AudioListener>();
        audioListener.transform.SetParent(this.gameObject.transform);

        GameObject BGMObj = new GameObject("AudioSourceBGM", typeof(AudioSource));
        BGMObj.transform.SetParent(this.gameObject.transform);
        AudioSourceBGM = BGMObj.GetComponent<AudioSource>();
        AudioMixerGroup audioMixerBGM = AssetLoadMgr.Instance.LoadNativeAsset<AudioMixerGroup>(string.Format("{0}/{1}", StrDef.PATH_AUDIOBGM, "BGM AudioMixer"));
        AudioSourceBGM.outputAudioMixerGroup = audioMixerBGM;
        AudioSourceBGM.playOnAwake = false;

        GameObject SFXObj = new GameObject("AudioSourceSFX", typeof(AudioSource));
        SFXObj.transform.SetParent(this.gameObject.transform);
        AudioSourceSFX = SFXObj.GetComponent<AudioSource>();
        AudioMixerGroup audioMixerSFX = AssetLoadMgr.Instance.LoadNativeAsset<AudioMixerGroup>(string.Format("{0}/{1}", StrDef.PATH_AUDIOSFX, "BGM SFX AudioMixer"));
        AudioSourceSFX.outputAudioMixerGroup = audioMixerSFX;
        AudioSourceSFX.playOnAwake = false;

    }

    /// <summary>
    /// 播放控制器
    /// </summary>
    private void CreatePlaylistController(string playlistName, bool startPlaylistOnAwake = false, bool isShuffle = false, bool isAutoAdvance = true, bool loopPlaylist = true)
    {
        //MasterAudio.Playlist playlist = new MasterAudio.Playlist();
        //masterAudio.musicPlaylists.Add(playlist);
        //playlist.playlistName = playlistName;

        //GameObject playlistControllerPfb = AssetLoadMgr.Instance.LoadNativeAsset<GameObject>(string.Format("{0}/{1}", "MasterAudio", "PlaylistController"));
        //playlistControllerPfb.name = string.Format("{0}_{1}", StrDef.PLAYLISTCONTROLLER, playlistName);
        //GameObject playlistControllerObj = Instantiate(playlistControllerPfb);

        //if (playlistControllerObj == null)
        //{
        //    Debug.LogWarning(string.Format("Could not find PlaylistController prefab."));
        //    return;
        //}
        //playlistControllerObj.name = string.Format("{0}_{1}{2}", StrDef.PLAYLISTCONTROLLER, playlistName, "(Clone)");
        ////playlistControllerObj.transform.SetParent(masterAudio.gameObject.transform);
        //PlaylistController playlistController = playlistControllerObj.GetComponent<PlaylistController>();
        //playlistControllerObj.name = string.Format("{0}_{1}", StrDef.PLAYLISTCONTROLLER, playlistName);
        //DontDestroyOnLoad(playlistControllerObj);
        //playlistController.startPlaylistName = playlistName;
        //playlistController.startPlaylistOnAwake = startPlaylistOnAwake;
        //playlistController.isShuffle = isShuffle;
        //playlistController.isAutoAdvance = isAutoAdvance;
        //playlistController.loopPlaylist = loopPlaylist;
    }

    //private void AddSongToPlaylist(string playlistName, AudioClip song, bool loopSong = false,
    //        float songPitch = 1f, float songVolume = 1f)
    //{
    //    MasterAudio.AddSongToPlaylist(playlistName, song, false, songPitch, songVolume);
    //}

    public void PlaySong(string clipName)
    {
        AudioSource audioSource = new AudioSource();
        if (dicAudioClip.ContainsKey(clipName))
        {
            switch (dicAudioClip[clipName].audioType)
            {
                case AudioType.BGM:
                    audioSource = AudioSourceBGM;
                    break;
                case AudioType.SFX:
                    audioSource = AudioSourceSFX;
                    break;
                default:
                    break;
            }
            audioSource.clip = dicAudioClip[clipName].audioClip;
            audioSource.Play();
        }
    }



}
