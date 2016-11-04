/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：Controller.cs
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

/// <summary>
/// 文件名:控制器基类
/// 说明:
/// </summary>
public abstract class Controller
{

	/// <summary>
	/// 得到视图层
	/// </summary>
	/// <value>The view.</value>
	protected ViewPresenters View { get; set; }

	/// <summary>
	/// 得到模型层
	/// </summary>
	/// <value>The model.</value>
	protected Model Model { get; set; }

	/// <summary>
	///显示标记.
	/// </summary>
	private bool active = false;

	/// <summary>
	/// 加载完标记
	/// </summary>
	private bool loaded = false;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="active">生成view时是否是激活的</param>
	/// <param name="native">true:the asset is in Resource folder,false:the asset is in other folder </param>
	protected Controller(GameObject view,bool active = true,bool native = false)
	{
		this.active = active;
		Init(view);
		/*
		string viewPath = string.Format("{0}/{1}", StrDef.VIEWDIR, viewName);
		if (native)
		{
			GameObject view = AssetLoadMgr.Instance.LoadnNativeAsset<GameObject>(viewPath);
			if (null != view)
			{
				Init(view);
			}
			else
			{
				Debug.LogError(string.Format("The view [{0}] is not exists", view.name));
			}
		}
		else
		{
			ModelMgr.Instance.LoadModel(viewPath, new ModelMgr.ModelCallback((string name, GameObject view, object callbackData)=>
			{
				if(null != view)
				{
					Init(view);
				}
				else
				{
					Debug.LogError(string.Format("The view [{0}] is not exists", name));
				}
			}));
		}
		*/
	}

	~Controller()
	{

	}

	/// <summary>
	/// 初始化视图
	/// </summary>
	public void Init(GameObject view)
	{
		this.Model = CreateModel();
		this.View = CreateView(view);
		UIMgr.Instance.SetViewCanvas(view);
		this.AddListener();
		this.InitPost();
		this.loaded = true;
		this.ShowView(this.active);
	}

	/// <summary>
	/// 显示
	/// </summary>
	public void ShowView(bool active)
	{

		this.active = active;
		if (this.loaded)
		{
			View.ShowDialog(this.active);
		}
	}

	/// <summary>
	///创建View
	/// </summary>
	/// <returns>The view.</returns>
	protected abstract ViewPresenters CreateView(GameObject go);

	/// <summary>
	///创建Model
	/// </summary>
	/// <returns>The model.</returns>
	protected abstract Model CreateModel();

	/// <summary>
	/// Adds the listener.
	/// </summary>
	protected abstract void AddListener();

	/// <summary>
	///更新View,初始化逻辑相关数据
	/// </summary>
	protected abstract void InitPost();


}
