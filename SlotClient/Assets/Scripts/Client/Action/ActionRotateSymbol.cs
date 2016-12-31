/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* 文 件 名：ActionRotateSymbol.cs
* 版权所有：	
* 文件编号：
* 创 建 人：Tycho
* 创建日期：2016-12-30
* 修 改 人：
* 修改日期：
* 描	述：
* 版 本 号：1.0
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using UnityEngine;
using System.Collections;
using DG.Tweening;

/// <summary>
/// 文件名:符号旋转效果
/// 说明:
/// </summary>
public class ActionRotateSymbol : ActionBase
{
    public Param param;
    public Transform transform;
    public class Param : ParamBase
    {
    }

    public ActionRotateSymbol(Transform trans)
    {
        this.transform = trans;
        this.AddListener(EActionState.Finish, Finish);
    }

    public override void Invoke()
    {
        Tweener RotateDotween = this.transform.DORotate(new Vector3(0f, 180f, 0), this.param.duration, RotateMode.Fast)
            .SetLoops(this.param.loops, this.param.loopType);
        RotateDotween.OnComplete(new TweenCallback(() =>
        {
            this.transform.localRotation = Quaternion.Euler(Vector3.zero);
            PayLineController payLineController = UIMgr.Instance.GetView(EViewID.PayLine) as PayLineController;

            payLineController.ClearPayLine(UIEventListen.Get(this.transform).intParm);

            this.Enter(EActionState.Finish);
        }));
    }

    //中断当前正在执行的行为
    public override void Stop()
    {

    }

    //回滚当前行为所执行的操作
    public override void Revert()
    {

    }

    public void RotateAction(float playEffectTime)
    {

    }

    //完成当前正在执行的行为
    public void Finish()
    {

    }

}
