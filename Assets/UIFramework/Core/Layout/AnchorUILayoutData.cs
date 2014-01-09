using UnityEngine;
using System.Collections;

public class AnchorUILayoutData : MonoBehaviour
{

	public bool leftAnchor = false;
	public UIWidget leftTarget;
		public int left = 0;

	public bool rightAnchor = false;
	public UIWidget rightTarget;
		public int right = 0;

	public bool topAnchor = false;
	public UIWidget topTarget;
		public int top = 0;

	public bool bottomAnchor = false;
	public UIWidget bottomTarget;
		public int bottom = 0;

	public bool verticalAnchor = false;
	public UIWidget verticalTarget;
	public int vertical = 0;

	public bool horizontalAnchor = false;
	public UIWidget horizontalTarget;
	public int horizontal = 0;
}
