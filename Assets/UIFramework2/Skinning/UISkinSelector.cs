using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class UISkinSelector : MonoBehaviour {


	///////////////////////////////////////////////////////////////////////////////////////////////////

	[SerializeField]
	public List<string> skinNames = new List<string>();

	///////////////////////////////////////////////////////////////////////////////////////////////////
	
	[SerializeField]

	UIGameObject
		_currentSkin;
	
	public UIGameObject currentSkin {
		get {
			return _currentSkin;
		}
		set {
			if (_currentSkin == value) {
				return;
			}
			_currentSkin = value;
			invalidate ();
		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	[SerializeField]
	int
		_skinIndex = -1;
	
	public int skinIndex {
		get {
			return _skinIndex;
		}
		set {
			if (skins == null || skins.Count == 0) {
				_skinIndex = value;
				invalidate ();
				return;
			}
			
			
			if (value < -1) {
				value = -1;
			}
			if (value > skins.Count - 1) {
				value = skins.Count - 1;
			}
			if (_skinIndex == value) {
				return;
			}
			_skinIndex = value;
			invalidate ();
		}
	}

	public void invalidate ()
	{
		}

	///////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void validate ()
	{
		//base.validate ();
		
//		if (skinIndex == -1) {
//			currentSkin = null;
//		} else {		
//			currentSkin = skins [skinIndex];
//		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////
	
	[SerializeField]

	public List<UIGameObject>
		skins = new List<UIGameObject>();

}