using UnityEngine;
using System.Collections;

public class AlphaTween : FloatTween
{

		public UIWidgetTransform widgetTransform;
	
		override protected void Awake ()
		{ 
				base.Awake ();
				widgetTransform = GetComponent<UIWidgetTransform> ();
		}
	
		protected override void UpdateValue (float time)
		{
				base.UpdateValue (time);
				widgetTransform.alpha = ((float)targetValue);
		}
	
}
