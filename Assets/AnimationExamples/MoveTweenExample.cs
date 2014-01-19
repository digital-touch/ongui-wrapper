using UnityEngine;
using System.Collections;

public class MoveTweenExample : MonoBehaviour
{
		public UIRoot root;
		public UIWidget widget;
		
		// Use this for initialization
		void Start ()
		{
		
				
				root.TouchBeganEvent += OnTouchBegan;
		}
		
		MoveTween tween;
	
		void OnTouchBegan (UIWidget root, UITouch touch)
		{
		
				UIWidget widgetTransform = widget.GetComponent<UIWidget> ();
		
				if (tween != null) {
						tween.Stop ();
						Destroy (tween);
						tween = null;
				}
				
				tween = widget.gameObject.AddComponent<MoveTween> ();
				
				tween.valueFrom = new Vector2 (widgetTransform.x, widgetTransform.y);
				tween.valueTo = new Vector2 (touch.position.x - widgetTransform.width / 2, touch.position.y - widgetTransform.height / 2);
				
				tween.duration = 2;
				tween.easingFunction = Elastic.EaseOut;
				tween.Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
