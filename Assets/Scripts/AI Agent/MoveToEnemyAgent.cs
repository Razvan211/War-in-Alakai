using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToEnemyAgent : Agent
{
    [SerializeField] private Transform targetTr;
    [SerializeField] private NavMeshAgent agent;
    RaycastHit hit;

    public override void OnEpisodeBegin()
    {
        agent.transform.position = new Vector3(0, 0, 7.4f);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(agent.transform.position);
        sensor.AddObservation(targetTr.transform.position);

    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        agent.SetDestination(targetTr.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetReward(1f);

        EndEpisode();
    }
}
