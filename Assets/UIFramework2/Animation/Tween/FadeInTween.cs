using UnityEngine;
using System.Collections;

public class FadeInTween : AlphaTween
{

		override protected void Awake ()
		{ 
				valueFrom = 0;
				valueTo = 1;
				base.Awake ();
		}
	
}
