using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

[AddComponentMenu("Slot/Effects/Fade")]
public class ActionFade : ActionBase
{
    public Param param;
    public class Param : ParamBase
    {
        public Transform transform;
    }

    public ActionFade(Transform trans)
    {
        this.param.transform = trans;
    }

    public override void Invoke()
    {

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
    public ActionFade()
    {
        //RectTransform trans = this.GetComponent<RectTransform>();
        //Text text = this.GetComponent<Text>();
        //Sequence dtSequence = DOTween.Sequence();
        //dtSequence.Append(trans.DOLocalMove(new Vector3(0, 100, 0), 1).SetRelative());
        ////dtSequence.Append(text.material.DOFade(0, 1).SetRelative());
        //dtSequence.OnComplete(OnTweenComplete);

    }

	private void OnTweenComplete()
	{
		//Destroy(gameObject);
	}
}
