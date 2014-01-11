using UnityEngine;
using System.Collections;

public class MoveTween : Vector2Tween
{	
		public UIWidget widgetTransform;
	
		override protected void Awake ()
		{ 
				base.Awake ();
				widgetTransform = GetComponent<UIWidget> ();
		}
	
		protected override void UpdateValue (float time)
		{
				base.UpdateValue (time);
				widgetTransform.x = (int)targetValue.x;
				widgetTransform.y = (int)targetValue.y;
		}
	
	
}
