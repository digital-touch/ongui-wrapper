using UnityEngine;
using System.Collections;

public class UIHorizontalLayout : UILayout
{

		
		public override ContentSize Layout ()
		{	
				contentSize.Set (0, 0);
				return contentSize;
		}
		
}
