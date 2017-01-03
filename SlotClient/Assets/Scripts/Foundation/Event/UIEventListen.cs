/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：UIEventListen.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-11-5
* 修 改 人：
* 修改日期：
* 描	述：业务逻辑类
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// UI事件类型
/// </summary>
public enum EUIEventType
{
    [Description("点击")]
    Click,
    [Description("按下")]
    Down,
    [Description("进入物体")]
    Enter,
    [Description("退出")]
    Exit,
    [Description("抬起")]
    Up,
    [Description("选中")]
    Select,
    [Description("取消选中")]
    Deselect,
    [Description("选中更新")]
    UpdateSelect,
    [Description("拖动开始")]
    DragBegin,
    [Description("拖动")]
    Drag,
    [Description("拖动结束")]
    DragEnd,
    [Description("拖动释放")]
    Drop,
    [Description("提交")]
    Submit,
    [Description("取消按钮")]
    Cancel,
    [Description("滚动")]
    Scroll,
}
/// <summary>
/// 文件名:事件监听组件
/// 说明:
/// </summary>
public class UIEventListen : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,  IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
{
    #region  带参 System.Object
    public System.Object parm0;
    public System.Object parm1;
    public System.Object parm2;
    public System.Object parm3;

    private Dictionary<EUIEventType, List<System.Delegate>> dicEvent = new Dictionary<EUIEventType, List<System.Delegate>>();

    //public Callback<T0> onClickInt;                      //点击事件代理;   
    //public Callback onDownInt;                       //按下事件代理;
    //public Callback onEnterInt;                      //点击进入物体事件代理;
    //public Callback onExitInt;                       //点击退出事件代理;
    //public Callback onUpInt;                         //点击抬起事件代理;
    //public Callback onSelectInt;                     //选中事件代理;
    //public Callback onDeSelectInt;                   //取消选中事件代理;
    //public Callback onUpdateSelectInt;               //选中更新便件代理;
    //public Callback onDragBeginInt;                  //拖动开始事件代理;
    //public Callback onDragInt;                       //拖动事件代理;
    //public Callback onDragEndInt;                    //拖动结束事件代理;
    //public Callback onDropInt;                       //拖动释放事件代理;
    //public Callback onSubmitInt;                     //提交事件代理;
    //public Callback onCancelInt;                     //取消按钮事件代理;
    //public Callback onScrollInt;                     //滚动事件代理;

    #endregion

    #region 添加回调

    public void AddEvent(EUIEventType eventType, System.Delegate listener)
    {
        List<System.Delegate> listDlg = new List<System.Delegate>();
        if (!dicEvent.ContainsKey(eventType) || null == dicEvent[eventType] || dicEvent[eventType].Count == 0)
        {
            listDlg.Add(listener);
            dicEvent[eventType] = listDlg;
            return;
        }

        listDlg = dicEvent[eventType];

        System.Delegate dlg = listDlg.Where(m => m.Equals(listener)).FirstOrDefault();
        System.Delegate.Combine(dlg, listener);
    }
    public void AddListener(EUIEventType eventType, Callback listener)
    {
        this.AddEvent(eventType, listener);
    }

    public void AddListener<T>(EUIEventType eventType, Callback<T> listener)
    {
        this.AddEvent(eventType, listener);
    }

    public void AddListener<T0, T1>(EUIEventType eventType, Callback<T0, T1> listener)
    {
        this.AddEvent(eventType, listener);
    }

    public void AddListener<T0, T1, T2>(EUIEventType eventType, Callback<T0, T1, T2> listener)
    {
        this.AddEvent(eventType, listener);
    }
    #endregion

    #region  去除回调
    public void RemoveAllListener(EUIEventType eventType)
    {
        if (!dicEvent.ContainsKey(eventType))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", eventType));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[eventType];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", eventType));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (null != listDlg[i])
            {
                System.Delegate.RemoveAll(listDlg[i], listDlg[i]);
            }
        }
    }
    public void RemoveListener(EUIEventType eventType, Callback listener)
    {
        if (!dicEvent.ContainsKey(eventType))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", eventType));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[eventType];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", eventType));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback callback = listDlg[i] as Callback;
                    callback -= listener;
                }
            }
        }
    }

    public void RemoveListener<T>(EUIEventType eventType, Callback<T> listener)
    {
        if (!dicEvent.ContainsKey(eventType))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", eventType));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[eventType];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", eventType));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback<T> callback = listDlg[i] as Callback<T>;
                    callback -= listener;
                }
            }
        }
    }

    public void RemoveListener<T0, T1>(EUIEventType eventType, Callback<T0, T1> listener)
    {
        if (!dicEvent.ContainsKey(eventType))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", eventType));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[eventType];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", eventType));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback<T0, T1> callback = listDlg[i] as Callback<T0, T1>;
                    callback -= listener;
                }
            }
        }
    }

    public void RemoveListener<T0, T1, T2>(EUIEventType eventType, Callback<T0, T1, T2> listener)
    {
        if (!dicEvent.ContainsKey(eventType))
        {
            Debug.Log(string.Format("The delegate [{0}] is not exist", eventType));
            return;
        }

        List<System.Delegate> listDlg = dicEvent[eventType];
        if (null == listDlg || listDlg.Count == 0)
        {
            Debug.Log(string.Format("The delegate [{0}] is null", eventType));
            return;
        }

        for (int i = 0; i < listDlg.Count; i++)
        {
            if (listDlg[i].Equals(listener))
            {
                if (null != listDlg[i])
                {
                    Callback<T0, T1, T2> callback = listDlg[i] as Callback<T0, T1, T2>;
                    callback -= listener;
                }
            }
        }
    }
    #endregion

    private void Dispatch(EUIEventType eventType)
    {
        //parm0;
        List<System.Delegate> listDlg = dicEvent[eventType];

        if (null == listDlg || listDlg.Count == 0)
        {
            return;
        }
        else
        {
            foreach (var dlg in listDlg)
            {
                if (dlg.Equals(typeof(Callback)))
                {
                    Callback callback = dlg as Callback;
                    callback();
                }
                //if (dlg.Equals(typeof(new Callback<>(parm0))
                //{
                    
                //}
            }
        }
    }

    /// 添加事件监听
    /// </summary>
    /// <param name="go">被监听对象</param>
    public static UIEventListen Get(GameObject go)
    {
        UIEventListen listener = go.GetComponent<UIEventListen>();
        if (listener == null) listener = go.AddComponent<UIEventListen>();
        return listener;
    }

	/// 添加事件监听
	/// </summary>
	/// <param name="go">被监听对象</param>
	public static UIEventListen Get(UnityEngine.Component Comp)
	{
		UIEventListen listener = Comp.gameObject.GetComponent<UIEventListen>();
		if (listener == null) listener = Comp.gameObject.AddComponent<UIEventListen>();
		return listener;
	}

	/// <summary>
	/// 拖动开始
	/// </summary>
	public void OnBeginDrag(PointerEventData eventData)
	{
        this.Dispatch(EUIEventType.DragBegin);
    }

	/// <summary>
	/// 取消按钮
	/// </summary>
	public void OnCancel(BaseEventData eventData)
    {
        this.Dispatch(EUIEventType.Cancel);
    }

    /// <summary>
    /// 取消选中
    /// </summary>
    public void OnDeselect(BaseEventData eventData)
    {
        this.Dispatch(EUIEventType.Deselect);
    }

    /// <summary>
    ///拖动
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Drag);
    }

    /// <summary>
    /// 拖动释放
    /// </summary>
    public void OnDrop(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Drop);
    }

    /// <summary>
    /// 拖动结束
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.DragEnd);
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {

    }

    public void OnMove(AxisEventData eventData)
    {

    }

	/// <summary>
	/// 点击事件操作
	/// </summary>
	public void OnPointerClick(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Click);
    }

    /// <summary>
    /// 点击按下
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Down);
    }

    /// <summary>
    /// 点击进入
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Enter);
    }

    /// <summary>
    /// 点击退出
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Exit);
    }

    /// <summary>
    /// 点击抬起
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Up);
    }

    public void OnScroll(PointerEventData eventData)
    {
        this.Dispatch(EUIEventType.Scroll);
    }

    /// <summary>
    /// 选中状态
    /// </summary>
    public void OnSelect(BaseEventData eventData)
    {
        this.Dispatch(EUIEventType.Select);
    }

    /// <summary>
    /// 提交按钮
    /// </summary>
    public void OnSubmit(BaseEventData eventData)
    {
        this.Dispatch(EUIEventType.Submit);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnUpdateSelected(BaseEventData eventData)
    {
        this.Dispatch(EUIEventType.UpdateSelect);
    }

}
