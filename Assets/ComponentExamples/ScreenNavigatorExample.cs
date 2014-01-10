using UnityEngine;
using System.Collections;

public class ScreenNavigatorExample : MonoBehaviour
{

		public UIScreenNavigator screenNavigator;
		
		void Start ()
		{
				screenNavigator.showScreen ("screen0", UIScreenTransitionType.LEFT_TO_RIGHT);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
