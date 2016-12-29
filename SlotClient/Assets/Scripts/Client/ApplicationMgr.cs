/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：ApplicationMgr.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-1
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.ComponentModel;

/// <summary>
/// 应用模式
/// </summary>
public enum ApplicationMode
{
    //开发版，面向内部人员，带有调试信息；测试版，提供测试指令，面向测试人员；正式版，面向终端用户，去掉一切调试、测试信息。
    //内测
    [Description("Internal")]
	Internal = 0,

	//公测
	[Description("Public")]
	Public = 1
}

/// <summary>
/// 文件名:应用管理器
/// 说明：总管理器，管理各个子管理器
/// </summary>
public class ApplicationMgr : SingletonWithComponent<ApplicationMgr>
{
    /// <summary>
    /// 版本模式
    /// </summary>
    public ApplicationMode appMode { get; private set; }

    /// <summary>
    /// 初始化
    /// </summary>
    protected override void InitPre()
	{
		this.InitializeAppMode();
        this.InitMgr();
    }

    /// <summary>
    /// 后初始化
    /// </summary>
    protected override void InitPost()
	{
        StateMgr.Instance.Enter(EState.NotStarted);
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
	/// 注册子管理器
	/// </summary>
	private void InitMgr()
	{
        StateMgr stateMgr = StateMgr.Instance;

        UIMgr uiMgr = UIMgr.Instance;
        AudioMgr audioMgr = AudioMgr.Instance;
        EffectMgr effectMgr = EffectMgr.Instance;

        PlayModeMgr playModeMgr = PlayModeMgr.Instance;

        
        //GameObject modelMgrObj = new GameObject(typeof(ModelMgr).Name);
        //modelMgrObj.AddComponent<ModelMgr>();

        //GameObject mouseEventMgrObj = new GameObject(typeof(MouseEventMgr).Name);
        //mouseEventMgrObj.AddComponent<MouseEventMgr>();

        //GameObject keyBoardEventMgrObj = new GameObject(typeof(KeyBoardEventMgr).Name);
        //keyBoardEventMgrObj.AddComponent<KeyBoardEventMgr>();

    }

	/// <summary>
	/// 得到版本模式
	/// </summary>
	public ApplicationMode GetAppMode()
	{
		return appMode;
	}

	/// <summary>
	/// 是否是内测版本
	/// </summary>
	/// <returns><c>true</c> if this instance is internal; otherwise, <c>false</c>.</returns>
	public bool IsInternal()
	{
		return (GetAppMode() == ApplicationMode.Internal);
	}

	/// <summary>
	/// 是否是公测版本
	/// </summary>
	/// <returns><c>true</c> if this instance is public; otherwise, <c>false</c>.</returns>
	public bool IsPublic()
	{
		return (GetAppMode() == ApplicationMode.Public);
	}

	/// <summary>
	/// 初始化模式
	/// </summary>
	private void InitializeAppMode()
	{
		appMode = ApplicationMode.Internal;
		//if (Vars.Key("Application.Mode").GetStr("Internal") == "Public")
		//{
		//	m_eMode = ApplicationMode.PUBLIC;
		//}
	}


}
