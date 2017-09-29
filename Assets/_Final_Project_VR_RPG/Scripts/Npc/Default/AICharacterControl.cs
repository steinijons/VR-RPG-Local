using System;
using UnityEngine;


[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class AICharacterControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent { get; private set; }              // the navmesh agent required for the path finding
    public ThirdPersonCharacter character { get; private set; }                 // the character we are controlling
    public Transform target;                                                    // target to aim for

    [SerializeField]
    private SteeringBehaviors steering;
    /* 
     * Todo:
     * Create state machine/behavior tree or some
     * Action selector that decides what steering 
     * algorithm is supposed to be used.
     * 
    */
    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
	    agent.updateRotation = false;
	    agent.updatePosition = true;
        
    }

    private void Update()
    {

        if (target != null)
        {
            //For later when we know what steering we want to do!
            //target.position = steering.Wander(target.position, Time.deltaTime);
            agent.SetDestination(target.position);
        }
 
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
            
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}
