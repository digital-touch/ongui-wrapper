using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AssetManagerExample1 : MonoBehaviour
{
		public AssetManager assetManager;
		// Use this for initialization
		void Start ()
		{		
		
				string BUTTON_SELECTED_DISABLED_SKIN = "button-selected-disabled-skin";		
				
				Asset asset = assetManager.Add (BUTTON_SELECTED_DISABLED_SKIN, BUTTON_SELECTED_DISABLED_SKIN);
				
				assetManager.Load ();
				
				texture = assetManager.Get<Texture2D> (BUTTON_SELECTED_DISABLED_SKIN);
			
		}
		
		Texture2D texture;
		
		void OnGUI ()
		{
				if (texture == null) {
						return;
				}
				GUI.BeginGroup (new Rect (0, 0, 160, 150));
				GUI.DrawTexture (new Rect (0, 0, 100, 100), texture);
				GUI.DrawTexture (new Rect (100, 0, 100, 100), texture);
				GUI.DrawTexture (new Rect (0, 100, 100, 100), texture);
				GUI.DrawTexture (new Rect (100, 100, 100, 100), texture);
				GUI.EndGroup ();
		}
	
}
