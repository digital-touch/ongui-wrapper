using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class AssetManager : MonoBehaviour
{
				
		List<Asset> assets = new List<Asset> ();
			
		public Asset Add (string id, string path)
		{
				Asset asset = new Asset (id, path);
				assets.Add (asset);
				return asset;
		}
		
		public void Load ()
		{		
				for (int i = 0; i < assets.Count; i++) {
						Asset asset = assets [i];
						if (!asset.isLoaded) {
								asset.resource = Resources.Load (asset.path);
								asset.isLoaded = true;
						}
				}				
		}
	
		public T Get<T> (string id)
		{
				Asset asset = GetAsset (id);		
				return (T)asset.resource;
		
		}
		public Asset GetAsset (string id)
		{
				for (int i = 0; i < assets.Count; i++) {
						Asset asset = assets [i];
						if (asset.id == id) {
								return asset;
						}
				}
				return default(Asset);
		}
	
}
public class Asset
{
		public string id;
		public string path;
		public object resource;
		public bool isLoaded;	
			
		public Asset (string id, string path)
		{
				this.isLoaded = false;
				this.id = id;
				this.path = path;
				resource = null;
		}
}