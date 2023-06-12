using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public int attackDamage = 2;
	public int enragedAttackDamage = 4;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	private int targetSide = 1; //Is the attack target on the left or right side of this object?


	public void Attack()
	{
		SideToAttack();

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			NewPlayer.Instance.GetHurt(targetSide, attackDamage);
			// colInfo.GetComponent<NewPlayer>().TakeDamage(attackDamage);
		}
	}

	public void EnragedAttack()
	{
		SideToAttack();

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			NewPlayer.Instance.GetHurt(targetSide, enragedAttackDamage);
			// colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
		}
	}

	private void SideToAttack()
	{
		//Determine which side the attack is on
		if (GetComponent<Boss>().isFlipped)
		{
			targetSide = 1;
		}
		else
		{
			targetSide = -1;
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}