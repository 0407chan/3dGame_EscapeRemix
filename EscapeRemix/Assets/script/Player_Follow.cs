using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class Player_Follow : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling
    public Transform target;                                    // target to aim for
	private bool ShieldCheck = false;
	private bool Follow = false;
    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

	    agent.updateRotation = false;
	    agent.updatePosition = true;
    }

    private void Update()
    {
		if (Follow)
		{
			if (target != null)
				agent.SetDestination(target.position);
			if (agent.remainingDistance > agent.stoppingDistance)
				character.Move(agent.desiredVelocity, false, false);
			else
				character.Move(Vector3.zero, false, false);
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Follow = true;
			if (ShieldCheck == false)
			{
				PlayerManager.FriendSheild++;
				ShieldCheck = true;
			}
		}
	}

	public void SetTarget(Transform target)
    {
        this.target = target;
    }
}

