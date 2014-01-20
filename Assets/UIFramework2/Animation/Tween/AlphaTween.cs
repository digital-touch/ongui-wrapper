using UnityEngine;
using System.Collections;

public class AlphaTween : FloatTween
{

		protected override void UpdateValue (float time)
		{
				base.UpdateValue (time);
				target.alpha = ((float)targetValue);
		}
	
}
