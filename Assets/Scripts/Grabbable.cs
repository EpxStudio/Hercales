using UnityEngine;

public class Grabbable : MonoBehaviour, IMouseClickable
{
	public CursorSetter cursor;
	public Rigidbody2D rb;

	[System.NonSerialized]
	public Texture2D defaultCursor;
	public Texture2D inactiveCursor;

	public float shakeDistance = 0.1f;

	public bool isGrabbed = false;
	private Vector2 center;

	private bool grabbable = false;
	public bool isGrabbable
	{
		get { return grabbable; }
		set
		{
			grabbable = value;
			cursor.myCursor = (value ? defaultCursor : inactiveCursor);
		}
	}

	private void Awake()
	{
		defaultCursor = cursor.myCursor;
		isGrabbable = false;
	}

	private void Update()
	{
		if (isGrabbed)
		{
			transform.position = center + Random.insideUnitCircle * shakeDistance;
		}
	}

	public void OnClick()
	{
		if (isGrabbable)
		{
			if (isGrabbed)
			{
				showSelect(false);
				Arc.Apex(rb, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			}
			else
			{
				showSelect(true);
			}
		}
	}

	private void showSelect(bool show)
	{
		Time.timeScale = show ? 0 : 1;
		isGrabbed = show;
		if (show)
			center = transform.position;
		else
			transform.position = center;
	}
}
