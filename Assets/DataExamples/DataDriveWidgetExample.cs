using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataDriveWidgetExample : MonoBehaviour
{
	
		void Start ()
		{
				List<object> cities = new List<object> ();
				
				cities.Add ("Poznań");
				cities.Add ("Warszawa");
				cities.Add ("Wrocław");
		
				UIDataProvider dataProvider = GetComponent<UIDataProvider> ();		
				dataProvider.source = cities;
		}	
}
