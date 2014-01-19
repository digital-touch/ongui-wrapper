using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIDataProvider : MonoBehaviour
{
		
		
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
