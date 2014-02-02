using UnityEngine;
using System.Collections;

public static class RectUtils
{

		public static bool Contains (Rect self, Rect rect)
		{
				Vector2 pointTopLeft = new Vector2 (rect.x, rect.y);
				Vector2 pointBottomRight = new Vector2 (rect.x + rect.width, rect.y + rect.height);
				return self.Contains (pointTopLeft) || self.Contains (pointBottomRight);
		}
		
		public static bool Intersect (Rect a, Rect b)
		{
		
				FlipNegative (ref a);
		
				FlipNegative (ref b);
		
				bool c1 = a.xMin < b.xMax;
		
				bool c2 = a.xMax > b.xMin;
		
				bool c3 = a.yMin < b.yMax;
		
				bool c4 = a.yMax > b.yMin;
		
				return c1 && c2 && c3 && c4;
		
		
		}
	
		public static void FlipNegative (ref Rect r)
		{
		
				if (r.width < 0) 
			
						r.x -= (r.width *= -1);
		
				if (r.height < 0)
			
						r.y -= (r.height *= -1);
		
		}
}
