using UnityEngine;
using System.Collections;

public class FitToScreenUILayout : UILayout
{
		
		public override ContentSize Layout ()
		{
				contentSize.Set (0, 0);
				if (contentSize.width != Screen.width) {
						contentSize.width = Screen.width;
				}
				if (contentSize.height != Screen.height) {
						contentSize.height = Screen.height;
				}
				return contentSize;
		}
	
}
