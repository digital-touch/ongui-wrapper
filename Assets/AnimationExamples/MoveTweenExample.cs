using UnityEngine;
using System.Collections;

public class MoveTweenExample : MonoBehaviour
{
		public UIRoot root;
		public UIGameObject widget;
		
		// Use this for initialization
		void Start ()
		{
		
				
				root.TouchBeganEvent += OnTouchBegan;
		}
		
		MoveTween tween;
	
		void OnTouchBegan (UIGameObject root, UITouch touch)
		{
		
				
		
				if (tween != null) {
						tween.Stop ();
						Destroy (tween);
						tween = null;
				}
				
				tween = widget.gameObject.AddComponent<MoveTween> ();
				
				tween.valueFrom = new Vector2 (widget.x, widget.y);
				tween.valueTo = new Vector2 (touch.position.x - widget.width / 2, touch.position.y - widget.height / 2);
				
				tween.duration = 2;
				tween.easingFunction = Elastic.EaseOut;
				tween.Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
