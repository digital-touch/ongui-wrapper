﻿using UnityEngine;
using System.Collections;
using System;

public class UIScreen : UIGameObject
{
		
		
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		UIScreenNavigator _navigator;
	
		public UIScreenNavigator navigator {				
				get {
						return (UIScreenNavigator)parentUIGameObject;
				}
		}
	
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIScreen> ShowTransitionStartEvent;
		public Action<UIScreen> ShowTransitionCompleteEvent;
	
		public virtual void FireShowTransitionStart (UIScreen screen)
		{
				if (ShowTransitionStartEvent != null) {
						ShowTransitionStartEvent (screen);
				}
		}
	
		public virtual void FireShowTransitionComplete (UIScreen screen)
		{
				if (ShowTransitionCompleteEvent != null) {
						ShowTransitionCompleteEvent (screen);
				}
		}	

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIScreen> HideTransitionStartEvent;
		public Action<UIScreen> HideTransitionCompleteEvent;
	
		public virtual void FireHideTransitionStart (UIScreen screen)
		{
				if (HideTransitionStartEvent != null) {
						HideTransitionStartEvent (screen);
				}
		}
	
		public virtual void FireHideTransitionComplete (UIScreen screen)
		{
				if (HideTransitionCompleteEvent != null) {
						HideTransitionCompleteEvent (screen);
				}
		}	

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
