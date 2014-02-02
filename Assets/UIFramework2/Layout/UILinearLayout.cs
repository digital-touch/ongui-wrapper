using UnityEngine;
using System.Collections;

public abstract class UILinearLayout : UIScrollableLayout
{
		
		

		[SerializeField]
		int
				_gap = 10;		

		public int gap {
				get {
						return _gap;
				}
				set {
						if (_gap == value) {
								return;
						}
						_gap = value;						
						uiGameObject.validate ();
				}
		}
}
