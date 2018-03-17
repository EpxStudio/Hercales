using UnityEngine;

public class TestScreenTransform : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			transform.position = new Vector3(transform.position.x, transform.position.y, 0);
			
		}
	}
}