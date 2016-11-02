/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
* 文件名：ApplicationMgr.cs
* 版权所有(C)：
* 文件编号：
* 创建人：Tycho
* 创建日期：2016-11-1
* 最后修改人：
* 最后修改日期：
* 描述：业务逻辑类
* 版本号：1.0
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 文件名:应用管理器
/// 说明：总管理器，管理各个子管理器
/// </summary>
public class ApplicationMgr : SingletonWithComponent<ApplicationMgr>
{
	/// <summary>
	/// 初始化
	/// </summary>
	protected override void InitPre()
	{
		this.InitMgr();
	}

	/// <summary>
	/// 后初始化
	/// </summary>
	protected override void InitPost()
	{

	}

	/// <summary>
	/// 结束
	/// </summary>
	protected override void Finish()
	{

	}

	/// <summary>
	/// 注册子管理器
	/// </summary>
	private void InitMgr()
	{
		GameObject audioMgrObj = new GameObject(typeof(AudioMgr).Name);
		audioMgrObj.AddComponent<AudioMgr>();


	}

}
