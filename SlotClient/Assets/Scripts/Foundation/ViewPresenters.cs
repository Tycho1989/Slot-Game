/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：ViewPresenters.cs
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
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 文件名：视图层基类
/// 说明:
/// </summary>
public class ViewPresenters : MonoBehaviour
{
	//视图的UI面板
	public RectTransform viewPanel;

	#region Unity3D messages
	void Awake()
	{
		viewPanel = this.transform as RectTransform;
		this.SetParentObj(UIMgr.Instance.viewCanvas.gameObject);
		this.InitUI();
		AwakeUnityMsg();
	}

	void Start()
	{
		StartUnityMsg();
	}

	void OnValidate()
	{
		OnValidateUnityMsg();
	}

	void OnDestroy()
	{
		OnDestroyUnityMsg();
	}
	#endregion

	#region Unity3D Messages propagation
	protected virtual void AwakeUnityMsg()
	{
	}

	protected virtual void StartUnityMsg()
	{
	}

	protected virtual void OnValidateUnityMsg()
	{
	}

	protected virtual void OnDestroyUnityMsg()
	{
	}
	#endregion

	protected virtual void InitUI()
	{
	}
	/// <summary>
	/// 设置父节点
	/// </summary>
	private void SetParentObj(GameObject target)
	{
		if (target != null)
		{
			viewPanel.SetParent(target.transform, false);
		}
		else
		{
			Debug.LogError(string.Format("The [{0}] is not exist", target.name));
		}
	}

	/// <summary>
	/// 查找窗口下的UI组件
	/// </summary>
	/// <returns></returns>
	public T FindUI<T>(string strChildName, GameObject parentObj = null, bool includeInactive = true)where T: UnityEngine.Object
	{
		if (string.IsNullOrEmpty(strChildName))
		{
			Debug.LogError(string.Format("Please set the UI name first"));
			return default(T);
		}
		if(parentObj == null)
		{
			parentObj = this.viewPanel.gameObject;
		}
		T childComp = default(T);
		if (typeof(T).IsSubclassOf(typeof(Component)))   //说明是自定义的类型，无需另外再封装
		{
			childComp = this.FindDeepChildComp<T>(strChildName, parentObj, includeInactive);
		}
		else if (typeof(T) == typeof(GameObject))
		{
			childComp = this.FindDeepChildObj(strChildName, parentObj, includeInactive) as T;
		}
		else
		{
			Debug.LogWarning(string.Format("This type [{0}] is not supported",typeof(T)));
		}
		return childComp;
	}

	/// <summary>
	/// 查找子节点组件
	/// </summary>
	private T FindDeepChildComp<T>(string strChildName, GameObject target, bool includeInactive = true) where T : UnityEngine.Object
	{
		if ((target == null) || string.IsNullOrEmpty(strChildName))
		{
			return default(T);
		}

		T[] arrayAllComponent = target.transform.GetComponentsInChildren<T>(includeInactive);
		List<T> listComponent = new List<T>(arrayAllComponent).Where(m => m.name.Equals(strChildName)).ToList();
		if (listComponent.Count == 0)
		{
			Debug.LogError(string.Format("The component [{0}] is not exist ", strChildName));
		}
		if (listComponent.Count > 1)
		{
			Debug.LogError(string.Format("The component [{0}] has more than one ", strChildName));
		}
		return listComponent[0];
	}

	/// <summary>
	/// 查找子节点物体
	/// </summary>
	private GameObject FindDeepChildObj(string strChildName, GameObject target, bool includeInactive = true)
	{
		if ((target == null) || string.IsNullOrEmpty(strChildName))
		{
			return null;
		}
		Transform[] arrayAllObj = target.transform.GetComponentsInChildren<Transform>(includeInactive);
		List<Transform> listObj = new List<Transform>(arrayAllObj).Where(m => m.name.Equals(strChildName)).ToList();
		if (listObj.Count == 0)
		{
			Debug.LogError(string.Format("The gameObject [{0}] is not exist ", strChildName));
		}
		if (listObj.Count >= 1)
		{
			Debug.LogError(string.Format("The gameObject [{0}] has more than one ", strChildName));
		}
		return listObj[0].gameObject;
	}

	/// <summary>
	/// 查找子节点物体
	/// </summary>
	public void ResetTransform(GameObject target)
	{
		target.transform.localScale = Vector3.one;
	}
		

}
