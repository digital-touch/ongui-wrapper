using UnityEngine;
using System.Collections;

public class PropertyChangeEventArgs
{

		public string propertyName;
		public  object lastValue;
		public  object newValue;
	
		public PropertyChangeEventArgs (string propertyName, object lastValue, object newValue)
		{
				this.propertyName = propertyName;
				this.lastValue = lastValue;
				this.newValue = newValue;
		}
}
