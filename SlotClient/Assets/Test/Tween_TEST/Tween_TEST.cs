using UnityEngine;
using DG.Tweening;

public class Tween_TEST : MonoBehaviour
{
	public Transform target;

	void Start()
	{
		// FIRST OF ALL, note this!
		// Sequences contain and animate other tweens,
		// but they DON'T need to be one after each other:
		// you can overlap them how you want :)

		// Let's create a Sequence which will first rotate AND move the target's Y at the same time,
		// then when the move + rotation is finished it will scale it.
		// Also, during all the tween, we will make sure that the target also moves on the X axis.

		// Create new Sequence object
		Sequence mySequence = DOTween.Sequence();
		// Add a 1 second move tween only on the Y axis
		mySequence.Append(target.DOMoveY(2, 1));
        mySequence.AppendCallback(() =>
        {
            Debug.Log("Call the function   111111111");
        });
        // Add a 1 second rotation tween, using Join so it will start when the previous one starts
        mySequence.Join(target.DORotate(new Vector3(0, 135, 0), 1));
		// Add a 1 second scale Y tween, using Append so it will start after the previously added tweens end
		mySequence.Append(target.DOScaleY(3f, 1));
		// Add an X axis relative move tween that will start from the beginning of the Sequence
		// and last for the whole Sequence duration
		mySequence.Insert(0, target.DOMoveX(4, mySequence.Duration()).SetRelative());

        mySequence.AppendCallback(()=>
        {
            Debug.Log("Call the function   2222222222");
        });
		// Oh, and let's also make the whole Sequence loop backward and forward 4 times
		mySequence.SetLoops(1, LoopType.Yoyo);
	}
}