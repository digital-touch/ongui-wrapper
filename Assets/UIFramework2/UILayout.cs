using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public abstract class UILayout : MonoBehaviour
{

		public Action ChangedEvent;
		
		protected void FireChangedEvent ()
		{
				if (ChangedEvent != null) {
						ChangedEvent ();
				}
		}
		
		protected virtual void Awake ()
		{
				addToUIGameObject ();
		}
		
		Transform parent;	
			
		protected virtual void Update ()
		{		
				if (parent == transform.parent) {
						return;
				}
				removeFromUIGameObject ();						
				addToUIGameObject ();				
		}		
		
		protected virtual void OnDestroy ()
		{
				removeFromUIGameObject ();
		}
				
		protected UIGameObject uiGameObject;
		
		void addToUIGameObject ()
		{
				parent = transform.parent;
				UIGameObject newUIGameObject = transform.GetComponent<UIGameObject> ();
				if (newUIGameObject == null) {
						return;
				}
				uiGameObject = newUIGameObject;
				uiGameObject.addLayout (this);				
		}
		
		void removeFromUIGameObject ()
		{
				if (uiGameObject != null) {						
						uiGameObject.removeLayout (this);
				}
				uiGameObject = null;	
				parent = null;			
		}
		
		public Vector2 contentSize = Vector2.zero;
	
		public Vector2 scrollPosition = Vector2.zero;
	
		public abstract void Layout ();
}
