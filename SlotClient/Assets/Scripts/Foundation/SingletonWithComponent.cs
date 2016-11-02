/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
* 文件名：SingletonWithComponent.cs
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

/// <summary>
/// 文件名:线程不安全组件单例
/// 说明：组件单例基类
/// </summary>
public abstract class SingletonWithComponent<T> : MonoBehaviour where T : Component
{
	private static T instance = null;
	public static T Instance
	{
		get
		{
			if (null == instance)
			{
				instance = FindObjectOfType<T>();
				if(null == instance)
				{
					GameObject obj = new GameObject();
					instance = obj.AddComponent<T>();
				}
			}
			return instance;
		}
	}

	/// <summary>
	/// 初始化成员
	/// </summary>
	private void Awake()
	{
		if(null == instance)
		{
			instance = this as T;
		}
		else
		{
			Debug.LogWarning(string.Format("the singleton {0} has already been existed", typeof(T).Name));
			//Destroy(base.gameObject);//销毁后Start()还会执行？？
			DestroyImmediate(base.gameObject);
			return;
		}

		base.gameObject.name = string.Format("{0}{1}", StrDef.PRESINGLETON, typeof(T).Name);
		//避免场景切换时单例被销毁
		DontDestroyOnLoad(base.gameObject);

		InitPre();
	}

	/// <summary>
	/// 开始
	/// </summary>
	private void Start ()
	{
		InitPost();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	private void Update ()
	{
	
	}

	/// <summary>
	/// 销毁
	/// </summary>
	private void OnDestroy()
	{
		Debug.Log(string.Format("the singleton {0} will be destroyed", typeof(T).Name));
		Finish();
	}

	/// <summary>
	/// 初始化
	/// </summary>
	protected abstract void InitPre();

	/// <summary>
	/// 后初始化
	/// </summary>
	protected abstract void InitPost();

	/// <summary>
	/// 结束
	/// </summary>
	protected abstract void Finish();

}
