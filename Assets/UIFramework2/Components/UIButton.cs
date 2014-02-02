using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIButton : UIGameObject
{
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

	public override void Awake ()
	{
		base.Awake ();

		TouchBeganEvent += OnTouchBegan;
		TouchEndedEvent += OnTouchEnded;
	}
	
	protected virtual void OnTouchBegan (UIGameObject target, UITouch touch)
	{
		isDown = true;
	}
	
	protected virtual void OnTouchEnded (UIGameObject target, UITouch touch)
	{
		isDown = false;
	}
	
	protected override void OnDestroy ()
	{
		base.OnDestroy ();
		TouchBeganEvent -= OnTouchBegan;
		TouchEndedEvent -= OnTouchEnded;
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////
	
	public override void validate ()
	{																		
		base.validate ();
		validateSkinIndex ();
	}

	void validateSkinIndex ()
	{
		_labelStyle = isDown ? skin.labelDownStyle != null ? skin.labelDownStyle:skin.labelNormalStyle:skin.labelNormalStyle;
		_background = isDown ? skin.downBackgroundSkin != null ? skin.downBackgroundSkin:skin.normalBackgroundSkin:skin.normalBackgroundSkin;

		if (_label!=null) {
			_label.textStyle = labelStyle;
		}
	}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////
	
//	override protected void drawChildren(UIGameObject parentChild) 
//	{			
//		
//		if (background != null) {
//			drawChild(background, parentChild);
//		}
//
//		if (label != null) {
//			drawChild(label, parentChild);						
//				}
//	}

	[SerializeField]
	 UIButtonSkin _skin;

	public UIButtonSkin skin {
		get {
			return _skin;
		}
		set {
			if (_skin == value) {
				return;
			}
			_skin = value;
			invalidate();	
		}
	}

	[SerializeField]
		 UIGameObject _background;

	public UIGameObject background {
		get {
			return _background;
		}
		set {
			if (_background == value) {
				return;
			}
			_background = value;
			invalidate();	
		}
	}

	[SerializeField]
		 UITextStyle _labelStyle;

	public UITextStyle labelStyle {
		get {
			return _labelStyle;
		}
		set {
			if (_labelStyle == value) {
				return;
			}
			_labelStyle = value;
			invalidate();	
		}
	}

	[SerializeField]
		 UILabel _label;

	public UILabel label {
		get {
			return _label;
		}
		set {
			if (_label == value) {
				return;
			}
			_label = value;
			invalidate();	
		}
	}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		bool _isDown = false;
	
		public bool isDown {
				get {
						return _isDown;
				}
				set {
						if (_isDown == value) {
								return;
						}
						_isDown = value;
			invalidate();						
				}
		}
	
	///////////////////////////////////////////////////////////////////////////////////////////////////	
	 
}
