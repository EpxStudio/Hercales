using UnityEngine;

public class Boat : MonoBehaviour
{
	public Transform cam;
	public Rigidbody2D rb;
	public float speed;

	private Vector2 direction;

	void Update()
	{
		cam.position = new Vector3(transform.position.x, transform.position.y, cam.position.z);
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mouse = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
			direction = (mouse - new Vector2(0.5f, 0.5f)).normalized;
		}
		rb.velocity = direction * speed * Time.deltaTime;
	}
}