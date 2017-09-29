using UnityEngine;
using UnityEngine.AI;
using System;

[Serializable]
public class SteeringBehaviors
{
    public WanderProperties wander;

    public void Init() { /* Set variables here that need to be initialized before hand*/ }

    public Vector3 Wander(Vector3 target, float deltaTime)
    {
        wander.IncreaseTime(deltaTime);

        if(wander.getTimeCounter() > wander.timeLimit)
        {
            wander.resetTimeCounter();
            
            Vector3 randDirection = UnityEngine.Random.insideUnitSphere * wander.Radius * wander.Jitter;
            randDirection.y = target.y;
            randDirection += target;

            NavMeshHit navHit;

            if (NavMesh.SamplePosition(randDirection, out navHit, wander.Distance, -1))
            {
                return navHit.position;
            }
            else
            {
                Debug.Log("Wander NavMesh sample position error");
            }
        }
        
        return target;
    }

    public String printWanderProp()
    {
        return "Radius: " + wander.Radius + " Distance " + wander.Distance + " Jitter: " + wander.Jitter + " time: " + wander.getTimeCounter() + " timelimit: " + wander.timeLimit; 
    }
}