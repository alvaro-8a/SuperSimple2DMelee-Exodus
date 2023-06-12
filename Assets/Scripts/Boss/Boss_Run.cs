using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
	[SerializeField] float speed = 2.5f;
	[SerializeField] float attackRange = 3f;

	Transform player;
	Rigidbody2D rb;
	Boss boss;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = NewPlayer.Instance.transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Boss>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// boss.LookAtPlayer();
		// Vector2 target = new Vector2(player.position.x, rb.position.y);
		// Vector2 newPos = Vector2.MoveTowards(rb.transform.position, target, speed * Time.fixedDeltaTime);
		// rb.MovePosition(newPos);

		Vector2 distance = new Vector2(player.position.x - rb.position.x, 0);

		animator.GetComponent<Boss>().ComputeVelocity(distance);

		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			// attack
			animator.SetTrigger("attack");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("attack");
	}

}
