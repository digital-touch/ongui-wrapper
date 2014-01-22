using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BindProperty : MonoBehaviour
{
		public Object source;
		public string sourcePropertyName;
		
		public Object destination;
		public string destinationPropertyName;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{	
				if (source == null) {
						return;
				}
				BindableAttribute[] bindables = (BindableAttribute[])source.GetType ().GetCustomAttributes (typeof(BindableAttribute), true);
				for (int i = 0; i < bindables.Length; i++) {
						BindableAttribute bindable = bindables [i];
						bool value = bindable.twoWay;
						Debug.Log ("value: " + value);
				}
		}
}
