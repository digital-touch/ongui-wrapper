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
				contentSize.Set (uiGameObject.width, uiGameObject.height);

				switch (type) {
				case ScaleUILayoutType.SCALE:
						contentSize.x = width * aspectRatio;
						contentSize.y = height * aspectRatio;
						break;
				case ScaleUILayoutType.SCALE_WIDTH:
						contentSize.x = contentSize.y * aspectRatio;
						break;
				case ScaleUILayoutType.SCALE_HEIGHT:
						contentSize.y = contentSize.x * aspectRatio;
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