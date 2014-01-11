using UnityEngine;
using System.Collections;

public class FadeOutTween : AlphaTween
{
		override protected void Awake ()
		{ 
				valueFrom = 1;
				valueTo = 0;
				base.Awake ();
		}
}
