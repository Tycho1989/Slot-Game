/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：StrDef.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-1
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using System.Collections;

/// <summary>
/// 文件名:字符定义
/// 说明：
/// </summary>
public static class StrDef
{
	public const string PRESINGLETON = "_SINGLETON_";//单例管理器前缀
	public const string VIEWDIR = "UI";              //视图资源文件目录
	public const string VIEWCANVAS = "ViewCanvas";   //视图面板

    public const string PATH_DEFAULTMODECONFIG = "Config/PlayMode/DefaultMode.ini";
    public const string PATH_FREESPINMODECONFIG = "Config/PlayMode/FreeSpinMode.ini";
    public const string PATH_BONUSMODECONFIG = "Config/PlayMode/BonusMode.ini";
    public const string PATH_VIEWCONFIG = "Config/ViewConfig.ini";
	public const string PATH_DEFAULT_UI_Material = "DefaultUIMaterial";

	public const string PATH_SYMBOLCONFIG = "Config/SymbolConfig.ini";
    public const string PATH_PAYLINECONFIG = "Config/PayLineConfig.ini";
    public const string PATH_SYMBOLTEXTURE = "UI/SymbolView/Symbol";
    public const string PATH_PAYLINETEXTURE = "UI/PayLineView/PayLineImage";
    public const string PATH_PAYLINEMATERIAL = "UI/PayLineView/PayLineMaterial";
    
    public const string PATH_AUDIOBGM = "Audio/BGM";//背景音乐
    public const string PATH_AUDIOSFX = "Audio/SFX";//特效音乐
    public const string PLAYLISTCONTROLLER = "PlaylistController";//音乐播放器

    public const string PATH_TESTDATA = "Test/TestData.dat";

}
