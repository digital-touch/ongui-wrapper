using UnityEngine;
using System.Collections;

public class ScaleUILayout : UILayout
{

		public float aspectRatio = 1f;

		public ScaleUILayoutType type = ScaleUILayoutType.SCALE;

		public int width = 0;
		public int height = 0;

		public override void Layout ()
		{
				setContentSize (uiGameObject.width, uiGameObject.height);

				switch (type) {
				case ScaleUILayoutType.SCALE:
						setContentSize (width * aspectRatio, height * aspectRatio);						
						break;
				case ScaleUILayoutType.SCALE_WIDTH:
						setContentSize (contentSize.y * aspectRatio, contentSize.y);												
						break;
				case ScaleUILayoutType.SCALE_HEIGHT:
						setContentSize (contentSize.x, contentSize.x * aspectRatio);																		
						break;
				}
					
				uiGameObject.width = (int)contentSize.x;
				uiGameObject.height = (int)contentSize.y;
		}
}
public enum ScaleUILayoutType
{
		SCALE_WIDTH,
		SCALE_HEIGHT,
		SCALE
}