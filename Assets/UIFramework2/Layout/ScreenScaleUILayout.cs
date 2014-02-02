using UnityEngine;
using System.Collections;

public class ScreenScaleUILayout : UILayout
{
	
		public float designWidth = 640;
		public float designHeight = 960;
		public float designPPI = 320;

		public float scaleFactor = 1;
		
		public int unscaledWidth = 100;
		public int unscaledHeight = 100;

		public override void Layout ()
		{			
				setContentSize (0, 0);
		
				float screenWidth = Screen.width;
				float screenHeight = Screen.height;
				float screenPPI = Screen.dpi;
		
				#if UNITY_STANDALONE
				screenPPI = 72;
				#endif			
			
				float designSize = getSize (designWidth, designHeight, designPPI);
				float screenSize = getSize (screenWidth, screenHeight, screenPPI);
				float factor = screenSize / designSize;
		
				scaleFactor = (screenPPI / designPPI) * factor;

				setContentSize (unscaledWidth * scaleFactor, unscaledHeight * scaleFactor);

				uiGameObject.width = (int)contentSize.x;
				uiGameObject.height = (int)contentSize.y;

		}
	
		float getSize (float width, float height, float ppi)
		{
		
				float widthInInches = width / ppi;
				float heightInInches = height / ppi;
				float sizeInInches = Mathf.Sqrt (Mathf.Pow (widthInInches, 2) + Mathf.Pow (heightInInches, 2));
				return sizeInInches;
		
		}
}
