using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public abstract class UILayout : UIWidgetBehaviour
{
		
		public ContentSize contentSize = new ContentSize ();
		
		public Vector2 scrollPosition = Vector2.zero;
	
		public abstract void Layout ();
	
}
