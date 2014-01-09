using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIDataProvider : UIWidgetBehaviour
{
		
		protected override void Awake ()
		{
				base.Awake ();
		}

		protected override void OnDestroy ()
		{
				base.OnDestroy ();
		}		
		
		List<object> _source;
		public List<object> source {
				set {
						if (_source == value) {
								return;
						}
						_source = value;
				}
				get {
						return _source;
				}
		}
}
