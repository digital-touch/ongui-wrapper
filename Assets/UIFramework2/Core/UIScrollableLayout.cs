using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public abstract class UIScrollableLayout : UILayout {

	[SerializeField]
	bool _lockMaxScrollPosition = true;
	
	public bool lockMaxScrollPosition {
		get {
			return _lockMaxScrollPosition;
		}
		set {
			if (_lockMaxScrollPosition == value) {
				return;
			}
			_lockMaxScrollPosition = value;
		}
	}
	
	[SerializeField]
	bool _lockMinScrollPosition = true;
	
	public bool lockMinScrollPosition {
		get {
			return _lockMinScrollPosition;
		}
		set {
			if (_lockMinScrollPosition == value) {
				return;
			}
			_lockMinScrollPosition = value;		
		}
	}
	
	[SerializeField]
	Vector2 _minScrollPosition = Vector2.zero;
	
	public Vector2 minScrollPosition {
		get {
			return _minScrollPosition;
		}
		set {
			if (_minScrollPosition == value) {
				return;
			}
			_minScrollPosition = value;
		}
	}
	
	[SerializeField]
	Vector2 _maxScrollPosition = Vector2.zero;
	
	public Vector2 maxScrollPosition {
		get {
			return _maxScrollPosition;
		}
		set {
			if (_maxScrollPosition == value) {
				return;
			}
			_maxScrollPosition = value;
		}
	}
	
	[SerializeField]
	Vector2
		_scrollPosition = Vector2.zero;
	
	public Vector2 scrollPosition {
		get {
			return _scrollPosition;
		}
		set {
			if (_scrollPosition == value) {
				return;
			}
			if (lockMaxScrollPosition && value.x > maxScrollPosition.x) {
				value.x = maxScrollPosition.x;
			} 
			
			if (lockMinScrollPosition && value.x < minScrollPosition.x) {
				value.x = minScrollPosition.x;
			}
			
			if (lockMaxScrollPosition && value.y > maxScrollPosition.y) {
				value.y = maxScrollPosition.y;
			} 
			
			if (lockMinScrollPosition && value.y < minScrollPosition.y) {
				value.y = minScrollPosition.y;
			}
			_scrollPosition = value;
			Layout();
		}
	}

	public override void setContentSize (int width, int height)
	{
		base.setContentSize (width, height);
		updateMaxScrollPosition();


	}

	public override void setContentSize (float width, float height)
	{
		base.setContentSize (width, height);
		updateMaxScrollPosition();
	}

	public void setScrollPosition (int x, int y)
	{			
		Vector2 newPosition = scrollPosition;
		newPosition.Set (x, y);
		scrollPosition = newPosition;
		
	}
	
	public void setScrollPosition (float x, float y)
	{			
		setScrollPosition ((int)x, (int)y);
	}
	
	public void updateMaxScrollPosition ()
	{			
		if (uiGameObject == null) {
			return;
		}
		
		float newMaxX = contentSize.x - uiGameObject.width;
		if (newMaxX < 0) {
			newMaxX = 0;
		}
		float newMaxY = contentSize.y - uiGameObject.height;
		if (newMaxY < 0) {
			newMaxY = 0;
		}	

		maxScrollPosition.Set(newMaxX, newMaxY);

	}
}
