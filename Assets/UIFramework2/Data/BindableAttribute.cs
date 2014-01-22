using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[AttributeUsage(AttributeTargets.Property)]
public class BindableAttribute : Attribute
{
		public bool twoWay { get; set; }
}