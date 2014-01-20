using UnityEngine;
using System.Collections;

public class FadeTweenExample : MonoBehaviour
{

		public UIGameObject target;
		
		FadeInTween tween;
		
		void Start ()
		{
				target.alpha = 0;
				tween = target.gameObject.AddComponent<FadeInTween> ();
				tween.duration = 2;
				tween.UpdatedEvent += OnUpdate;
				tween.CompletedEvent += OnComplete;
				tween.Play ();
		}
		
		void OnUpdate (UITween tween)
		{
				Debug.Log ("OnUpdate" + tween);
		}
		
		void OnComplete (UITween tween)
		{
				Debug.Log ("OnComplete" + tween);
		}
}
