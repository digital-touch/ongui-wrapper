using UnityEngine;
using System.Collections;

public class AlphaTween : FloatTween
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
				widgetTransform.alpha = ((float)targetValue);
		}
	
}
