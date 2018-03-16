using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public Animator anim;
	public Rigidbody2D rb;

	private bool isStanding = false;

	private void Update()
	{
		anim.SetBool("isStanding", isStanding);
		anim.SetFloat("ySpeed", rb.velocity.y);
		if (Input.GetMouseButtonDown(0))
		{
			// TODO: position of object at middle (maybe use center of mass?)
			this.Jump(rb, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		if (rb.velocity.x > 0)
			anim.transform.localScale = new Vector3(1, 1, 1);
		if (rb.velocity.x < 0)
			anim.transform.localScale = new Vector3(-1, 1, 1);
	}

	private void Jump(Rigidbody2D jumper, Vector2 apexPosition)
	{
		Vector2 delta = apexPosition - jumper.position;

		if (delta.y > 0)
		{
			float vy, vx, dt, gravity;
			gravity = Physics.gravity.y * jumper.gravityScale;
			vy = Mathf.Sqrt(-2 * delta.y * gravity);
			dt = Mathf.Sqrt(-2 * delta.y / gravity);
			vx = delta.x / dt;

			jumper.velocity = new Vector2(vx, vy);
		}
	}
}
