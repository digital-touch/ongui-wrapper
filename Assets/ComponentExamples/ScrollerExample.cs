using UnityEngine;
using System.Collections;

public class ScrollerExample : MonoBehaviour
{

		public UIScroller scroller;
		
		int contentHeight = 0;
		
		UILinearLayout layout;
		// Use this for initialization
		
		bool firstFrame = false;
		
		public float duration = 2;
		
		public virtual void Update ()
		{
				if (!firstFrame) {
						layout = scroller.GetComponent<UILinearLayout> ();
						layout.Layout ();
						contentHeight = (int)layout.contentSize.y;		
						tweenDown ();
						firstFrame = true;
				} else {
						contentHeight = 0;
				}
		}
		
		FloatTween tween;
		
		void tweenDown ()
		{
				tween = (FloatTween)scroller.gameObject.AddComponent<FloatTween> ();
				tween.duration = duration;
				tween.valueFrom = 0;
				tween.valueTo = layout.maxScrollPosition.y;
				tween.UpdatedEvent += onTweenUpdate;
				tween.CompletedEvent += onTweenDownCompleted;
				tween.easingFunction = Cubic.EaseOut;
				tween.Play ();
		}
		void onTweenUpdate (UITween tween)
		{
				Vector2 scrollPosition = layout.scrollPosition;				
				scrollPosition.y = (float)tween.value;
				layout.scrollPosition = scrollPosition;				
		}
		void onTweenDownCompleted (UITween tween)
		{
				tween.UpdatedEvent -= onTweenUpdate;
				tween.CompletedEvent -= onTweenDownCompleted;				
				
				Destroy (tween);
				tween = null;
		
				tweenUp ();
		}
		
		void onTweenUpCompleted (UITween tween)
		{
				tween.UpdatedEvent -= onTweenUpdate;
				tween.CompletedEvent -= onTweenUpCompleted;
				
				Destroy (tween);
				tween = null;
		
				tweenDown ();
		}
		
		void tweenUp ()
		{
				tween = (FloatTween)scroller.gameObject.AddComponent<FloatTween> ();
		
				tween.valueFrom = layout.maxScrollPosition.y;
				tween.valueTo = 0;
				tween.duration = duration;
				tween.UpdatedEvent += onTweenUpdate;
				tween.CompletedEvent += onTweenUpCompleted;
				tween.easingFunction = Cubic.EaseOut;
				tween.Play ();
		}
	
	
}
