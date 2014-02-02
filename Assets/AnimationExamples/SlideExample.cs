using UnityEngine;
using System.Collections;

public class SlideExample : MonoBehaviour
{

		public UIGameObject panelA;
		public UIGameObject panelB;

		public float duration = 1;
		EaseDelegate easingFunction = Linear.EaseOut;
		
		bool started = false;
		
		void Update ()
		{
				if (!started) {
		
						panelA.x = Screen.width;
						panelB.x = Screen.width;
				
						showPanelA ();				
						started = true;
				}
		}
		
		void showPanelA ()
		{
				MoveTween tween = panelA.gameObject.AddComponent<MoveTween> ();
				tween.valueFrom = new Vector2 (Screen.width, 0);
				tween.valueTo = new Vector2 (0, 0);
				tween.CompletedEvent += OnShowPanelAComplete;
				tween.easingFunction = easingFunction;				
				tween.duration = duration;
		
				tween.Play ();
		}
	
		void OnShowPanelAComplete (UITween tween)
		{
				tween.CompletedEvent -= OnShowPanelAComplete;
				Destroy (tween);
				
				hidePanelA ();
				showPanelB ();
		}
		
		void hidePanelA ()
		{
				MoveTween tween = panelA.gameObject.AddComponent<MoveTween> ();
				tween.valueFrom = new Vector2 (0, 0);
				tween.valueTo = new Vector2 (-Screen.width, 0);
				tween.CompletedEvent += OnHidePanelAComplete;
				tween.easingFunction = easingFunction;
				tween.duration = duration;
		
				tween.Play ();
		}
		
		void OnHidePanelAComplete (UITween tween)
		{
				tween.CompletedEvent -= OnHidePanelAComplete;
				Destroy (tween);				
		}
	
		void showPanelB ()
		{
				MoveTween tween = panelB.gameObject.AddComponent<MoveTween> ();
				tween.valueFrom = new Vector2 (Screen.width, 0);
				tween.valueTo = new Vector2 (0, 0);
				tween.CompletedEvent += OnShowPanelBComplete;
				tween.easingFunction = easingFunction;
				tween.duration = duration;
		
				tween.Play ();
		}
	
		void OnShowPanelBComplete (UITween tween)
		{
				tween.CompletedEvent -= OnShowPanelBComplete;
				Destroy (tween);
		
				hidePanelB ();
				showPanelA ();
		}
		
		void hidePanelB ()
		{
				MoveTween tween = panelB.gameObject.AddComponent<MoveTween> ();
				tween.valueFrom = new Vector2 (0, 0);
				tween.valueTo = new Vector2 (-Screen.width, 0);
				tween.CompletedEvent += OnHidePanelBComplete;
				tween.easingFunction = easingFunction;
				tween.duration = duration;
		
				tween.Play ();
		}
	
		void OnHidePanelBComplete (UITween tween)
		{
				tween.CompletedEvent -= OnHidePanelBComplete;
				Destroy (tween);				
		}
}
