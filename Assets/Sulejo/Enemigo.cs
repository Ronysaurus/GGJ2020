using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
	public GameObject Player;
	public float TargetDistance;
	public float AllowedDistance = 5;
	public GameObject Enemy;
	public float FollowSpeed;
	public RayCastHit Shot;

    void Update()
    {
        transform.LookAt(Player.transform);
		if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
		{
			TargetDistance = Shot.distance;
			if(TargetDistance >= AllowedDistance)
			{
				FollowSpeed = 0.5f;
				NPC.GetComponent<Animation>().Play("Running");
				transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
			}
			else
			{
				FollowSpeed = 0;
				NPC.GetComponent<Animation>().Play("Idle");
			}
		}
    }
}