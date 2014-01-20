using UnityEngine;
using System.Collections;

public class FitToScreenUILayout : UILayout
{
		
		public override void Layout ()
		{
				if (contentSize.width != Screen.width) {
						contentSize.width = Screen.width;
						widget.width = contentSize.width;
				}
				if (contentSize.height != Screen.height) {
						contentSize.height = Screen.height;
						widget.height = contentSize.height;
				}
				
		}
	
}
