using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class UIGameObject : MonoBehaviour
{
		public List<GameObject> children = new List<GameObject> ();
		public Transform parent;
			
		protected void Update ()
		{
				if (transform.parent != parent) {
						if (parent != null) {
								parent.gameObject.SendMessage ("OnRemove", gameObject, SendMessageOptions.DontRequireReceiver);
						}
						parent = transform.parent;
						if (parent != null) {
								parent.gameObject.SendMessage ("OnAdd", gameObject, SendMessageOptions.DontRequireReceiver);
						}
				}
		}
		
		void OnRemove (GameObject gameObject)
		{
				children.Remove (gameObject);
		}
		
		void OnAdd (GameObject gameObject)
		{
				children.Add (gameObject);
		}
}
