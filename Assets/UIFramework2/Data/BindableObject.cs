using UnityEngine;
using System.Collections;
using System;

public class BindableObject : MonoBehaviour
{
		public Action<PropertyChangeEventArgs> PropertyChangeEvent;
		
		protected void firePropertyChange (string propertyName, object lastValue, object newValue)
		{
				if (PropertyChangeEvent != null) {
						PropertyChangeEvent (new PropertyChangeEventArgs (propertyName, lastValue, newValue));
				}
		}
}
