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

/// <summary>
/// 文件名：视图层基类
/// 说明:
/// </summary>
public class ViewPresenters : MonoBehaviour
{
	private UIRectTransform viewPanel;
	public UIRectTransform ViewPanel
	{
		get { return viewPanel; }
		set { viewPanel = value; }
	}

	private EViewID viewID;
	public EViewID ViewID
	{
		get { return viewID; }
		set { viewID = value; }
	}

	protected int viewInstID = 0;
	public int ViewInstID
	{
		get { return viewInstID; }
		set { viewInstID = value; }
	}

	#region Unity3D messages
	void Awake()
	{
		viewPanel.SetUI(this.transform as RectTransform);
		this.SetViewCanvas(UIMgr.Instance.viewCanvas);
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

	public T FindUI<T>(string strChildName, bool includeInactive = false) where T : class, IUIType, new()
	{
		return viewPanel.FindUI<T>(strChildName);
	}

	/// <summary>
	/// 显示
	/// </summary>
	public virtual void ShowDialog(bool active)
	{
		base.gameObject.SetActive(active);
		if (active)
		{
			if (ViewDidShow != null)
			{
				ViewDidShow(this, EventArgs.Empty);
			}
		}
		else
		{
			if (ViewDidHide != null)
			{
				ViewDidHide(this, EventArgs.Empty);
			}
		}
	}

	/// <summary>
	/// 设置视图父节点
	/// </summary>
	private void SetViewCanvas(GameObject viewCanvas)
	{
		if (viewCanvas != null)
		{
			viewPanel.transform.SetParent(viewCanvas.transform, false);
		}
		else
		{
			Debug.LogError(string.Format("The [ViewCanvas] is not exist"));
		}
	}

}
