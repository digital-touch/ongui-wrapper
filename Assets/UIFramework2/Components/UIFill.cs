using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class UIFill : UIImage
{
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		public override void Awake ()
		{	
				base.Awake ();
				validateTexture ();
		}	
	
		override protected void OnDestroy ()
		{
				destroyTexture ();
				base.OnDestroy ();
		}
				
		void destroyTexture ()
		{
				if (image != null) {
						#if UNITY_EDITOR
						Texture2D.DestroyImmediate (image);
						#else  
			Texture2D.Destroy (texture);
#endif
						image = null;
				}
		}
		
	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void validate ()
		{
				validateTexture ();
				base.validate ();
		}
	
		void validateTexture ()
		{   						
		
				createTexture ();
				fillTexture ();			
		}
						
		void createTexture ()
		{
				if (image != null) {			
						if (image.width != 1 || image.height != 1) {
								image.Resize (1, 1);										
						}										
				} else {
						image = new Texture2D (1, 1);					
				}				
		}
		
		void fillTexture ()
		{
				
				Color[] pixels = image.GetPixels ();
				pixels [0] = Color.white;		
			
				image.SetPixels (pixels);	
				image.Apply ();
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
