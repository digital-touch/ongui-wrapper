using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public abstract class UILayout : MonoBehaviour
{
		
		public ContentSize contentSize = new ContentSize ();
		
		public Vector2 scrollPosition = Vector2.zero;
	
		public abstract void Layout ();
	
		protected UIWidget widget;
		
		protected virtual void Awake ()
		{
				widget = GetComponent<UIWidget> ();
		}
	
		protected virtual void OnDestroy ()
		{
				widget = null;
		}
}
