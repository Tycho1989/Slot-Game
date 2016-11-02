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

public abstract class Controller
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="active">生成view时是否是激活的</param>
	/// <param name="native">true:the asset is in Resource folder,false:the asset is in other folder </param>
	protected Controller(string viewName, bool active = false,bool native = false)
	{
		string viewPath = string.Format("{0}/{1}", StrDef.VIEWDIR, viewName);
		if (native)
		{
			AssetLoadMgr.Instance.LoadnNativeAsset<GameObject>(viewPath);
		}
		else
		{
			ModelMgr.Instance.LoadModel(viewPath, new ModelMgr.ModelCallback((string name, GameObject view, object callbackData)=>
			{
				InitView(view);
			}));
		}

	}

	~Controller()
	{

	}

	/// <summary>
	/// 初始化视图
	/// </summary>
	private void InitView(GameObject view)
	{

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
