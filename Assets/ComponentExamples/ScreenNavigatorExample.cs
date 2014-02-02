using UnityEngine;
using System.Collections;
using TouchScript;

public class ScreenNavigatorExample : MonoBehaviour
{

		public UIScreenNavigator screenNavigator;
		
		void Start ()
		{		
				Invoke ("showStartScreen", 0.4f);
		}
		
		int screenIndex = -1;
		
		string[] screenIds = new string[] {"screen-a", "screen-b"};
		
		void showStartScreen ()
		{
				screenNavigator.transitionDuration = 1f;
				TouchManager touchManager = (TouchManager)GameObject.FindObjectOfType (typeof(TouchManager));
				
				touchManager.TouchesBegan += (object sender, TouchScript.Events.TouchEventArgs e) => {
						nextScreen ();
				};
		}

		void nextScreen ()
		{
				screenIndex++;
				if (screenIndex > screenIds.Length - 1) {
						screenIndex = 0;
				}
				screenNavigator.showNextScreen (screenIds [screenIndex], UIScreenTransitionType.RIGHT_TO_LEFT);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
