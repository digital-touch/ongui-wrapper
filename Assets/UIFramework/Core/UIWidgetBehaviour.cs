using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public abstract class UIWidgetBehaviour : MonoBehaviour
{
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
