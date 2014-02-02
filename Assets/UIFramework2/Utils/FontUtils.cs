using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public static class FontUtils
{

		public static void GetFontMetrics (ref FontMetrics metrics, Font font, int fontSize)
		{
				//Get a string containing all characters
				StringBuilder stringBuilder = new StringBuilder ();
				for (int i = 32; i < 127; i++) {
						stringBuilder.Append ((char)i);
				}
				string allCharacters = stringBuilder.ToString ();
		
				//Make sure all characters are included in font texture
				font.RequestCharactersInTexture (allCharacters);
		
				//Dictionary keeps track of each different baseline, and how many characters use it
				Dictionary<float, int> baseLines = new Dictionary<float, int> ();
		
				//The height of the highest and lowest characters
				float highest = float.NegativeInfinity;
				float lowest = float.PositiveInfinity;
		
				//Loop through all characters
				for (int i = 0; i < allCharacters.Length; i++) {
						CharacterInfo info;
						bool exists = font.GetCharacterInfo (allCharacters [i], out info, fontSize);
			
						//Make sure character exists in font texture
						if (exists) {
								//Pixel values for top and bottom of character
								float bottom = info.vert.height + info.vert.y;
								float top = info.vert.y;
				
								//Add bottom of character to baselines
								if (baseLines.ContainsKey (bottom)) {
										baseLines [bottom]++;
								} else {
										baseLines [bottom] = 1;
								}
				
								//Is this the highest or lowest character so far?
								if (top > highest) {
										highest = top;
								}
								if (bottom < lowest) {
										lowest = bottom;
								}
						}
				}
				//Loop through all different baselines.
				//The one used the most is the baseline
				int highestBaseLineCount = 0;
				float baseLine = 0;
				foreach (KeyValuePair<float, int> pair in baseLines) {
						if (pair.Value > highestBaseLineCount) {
								highestBaseLineCount = pair.Value;
								baseLine = pair.Key;
						}
				}
		
				//Calculate metrics
				float ascend = (highest - baseLine) / (highest - lowest);
				float descend = (baseLine - lowest) / (highest - lowest);
						
				metrics.highestBaseLineCount = highestBaseLineCount;
				metrics.baseLine = baseLine;
				metrics.ascend = ascend;
				metrics.descend = descend;
		
				
		}
}
