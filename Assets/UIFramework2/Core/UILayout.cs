using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public abstract class UILayout : BindableObject
{

		protected UIGameObject uiGameObject;	
		
		protected virtual void Awake ()
		{				
				uiGameObject = GetComponent<UIGameObject> ();
		uiGameObject.invalidate ();
		}
		
		
		protected virtual void OnDestroy ()
		{
		uiGameObject.invalidate ();
				uiGameObject = null;
		}
				
		protected void change ()
		{
				uiGameObject.invalidate ();				
		}	
		
		[SerializeField]
		Vector2
				_contentSize = Vector2.zero;

		public virtual Vector2 contentSize {
				get {
						return _contentSize;
				}
				set {
						if (_contentSize == value) {
								return;
						}
						_contentSize = value;						
				}
		}

	
		public abstract void Layout ();
		
		public virtual void setContentSize (int width, int height)
		{			
				Vector2 newSize = contentSize;
		
				if (width < 0) {
						width = 0;
				}		
				if (height < 0) {
						height = 0;
				}		
				newSize.Set (width, height);
				contentSize = newSize;				
		}
		
		public virtual void setContentSize (float width, float height)
		{			
				setContentSize ((int)width, (int)height);				
		}
				
}
