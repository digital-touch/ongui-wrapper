using UnityEngine;
using System.Collections;

public class FadeTweenExample : MonoBehaviour
{

		public UIWidget widgetTransform;
		
		FadeInTween tween;
		
		void Awake ()
		{
				widgetTransform.alpha = 0;
				tween = widgetTransform.gameObject.AddComponent<FadeInTween> ();
				tween.duration = 2;
				tween.UpdatedEvent += OnUpdate;
				tween.CompletedEvent += OnComplete;
				tween.Play ();
		}
		
		void OnUpdate (Tween tween)
		{
				Debug.Log ("OnUpdate" + tween);
		}
		
		void OnComplete (Tween tween)
		{
				Debug.Log ("OnComplete" + tween);
		}
}
