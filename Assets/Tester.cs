using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Tester : MonoBehaviour
{

		void Awake ()
		{
				Debug.Log (this + " Awake");
		}
	
		void OnEnable ()
		{
				Debug.Log (this + " OnEnable");
		}
	
		void OnDisable ()
		{
				Debug.Log (this + " OnDisable");
		}
	
		void Start ()
		{
				Debug.Log (this + " Start");
		}
	
		void OnDestroy ()
		{
				Debug.Log (this + " OnDestroy");
		}

		// Update is called once per frame
		void Update ()
		{
	
		}
}
