using UnityEngine;
using System.Collections;

public class test_transform : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
		
				FloatTween tween = gameObject.AddComponent<FloatTween> ();
				tween.UpdatedEvent += OnUpdate;
				tween.CompletedEvent += OnComplete;
				tween.valueFrom = 0;
				tween.valueTo = 10;
				tween.duration = 2;
				tween.Play ();
								
		}
		
		void OnComplete (Tween tween)
		{
				tween.UpdatedEvent -= OnUpdate;
				tween.CompletedEvent -= OnComplete;
				Debug.Log ("OnComplete:" + tween.value);
				Destroy (tween);
		}
		
		void OnUpdate (Tween tween)
		{
				Debug.Log ("OnUpdate:" + tween.value);
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
}
