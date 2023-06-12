using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : PhysicsObject
{
	[Header("Reference")]
	public Transform player;
	public EnemyBase enemyBase;

	[Header("Properties")]
	public bool isFlipped = false;
	public float changeDirectionEase = 1; //How slowly should we change directions? A higher number is slower!
	[System.NonSerialized] public float direction = 1;
	[System.NonSerialized] public float directionSmooth = 1; //The float value that lerps to the direction integer.
	public float hurtLaunchPower = 10; //How much force should be applied to the player when getting hurt?
	[System.NonSerialized] public float launch = 1; //The float added to x and y moveSpeed. This is set with hurtLaunchPower, and is always brought back to zero
	public float maxSpeed = 7;

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	public void ComputeVelocity(Vector2 distanceFromPlayer)
	{
		Vector2 move = Vector2.zero;

		if (!NewPlayer.Instance.frozen)
		{
			// distanceFromPlayer = new Vector2 (NewPlayer.Instance.gameObject.transform.position.x - transform.position.x, NewPlayer.Instance.gameObject.transform.position.y - transform.position.y);
			directionSmooth += (direction - directionSmooth) * Time.deltaTime * changeDirectionEase;
			move.x = (1 * directionSmooth) + launch;
			launch += (0 - launch) * Time.deltaTime;

			LookAtPlayer();

			if (!enemyBase.recoveryCounter.recovering)
			{
				if (distanceFromPlayer.x < 0)
				{
					direction = -1;
				}
				else
				{
					direction = 1;
				}
			}
		}

		targetVelocity = move * maxSpeed;
	}
}