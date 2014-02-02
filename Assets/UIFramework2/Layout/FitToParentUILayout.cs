using UnityEngine;
using System.Collections;

public class FitToParentUILayout : UILayout
{

		[SerializeField]
		bool _fitHorizontally = false;

	public bool fitHorizontally {
		get {
			return _fitHorizontally;
		}
		set {
			if (_fitHorizontally == value) {
				return;
			}
			_fitHorizontally = value;
			Layout();
		}
	}

	[SerializeField]
		bool _fitVertically = false;

	public bool fitVertically {
		get {
			return _fitVertically;
		}
		set {
			if (_fitVertically == value) {
				return;
			}
			_fitVertically = value;
			Layout();
		}
	}
	
		public override void Layout ()
		{
				setContentSize (0, 0);
		
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();
				UIGameObject parentTransform = transform.parent.GetComponent<UIGameObject> ();
						
		setContentSize (fitHorizontally ? parentTransform.width:uiGameObject.width, fitVertically ? parentTransform.height:uiGameObject.height);

				if (fitHorizontally) {
						uiGameObject.x = 0;
						uiGameObject.width = (int)contentSize.x;
				} 

				if (fitVertically) {
						uiGameObject.y = 0;
						uiGameObject.height = (int)contentSize.y;
				}

		}
	
}
