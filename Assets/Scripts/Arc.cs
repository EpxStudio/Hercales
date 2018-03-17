using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc
{
	public static void Apex(Rigidbody2D obj, Vector2 apexPosition)
	{
		Vector2 delta = apexPosition - obj.position;

		if (delta.y > 0)
		{
			float vy, vx, dt, gravity;
			gravity = Physics.gravity.y * obj.gravityScale;
			vy = Mathf.Sqrt(-2 * delta.y * gravity);
			dt = Mathf.Sqrt(-2 * delta.y / gravity);
			vx = delta.x / dt;

			obj.velocity = new Vector2(vx, vy);
		}
	}
}
