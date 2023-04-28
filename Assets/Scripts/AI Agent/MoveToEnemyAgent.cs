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
    [SerializeField] private Material green;
    [SerializeField] private Material red;
    [SerializeField] private MeshRenderer floor;
 

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-8.5f,8.5f), 0,Random.Range( 0.5f,8.5f));
        targetTr.transform.localPosition = new Vector3(Random.Range(-8.5f, 8.5f), 0, Random.Range(-1.5f, -8.0f));
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTr.transform.localPosition);

    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 2f;
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<EnemyTarget>(out EnemyTarget eTarget))
        {
            SetReward(1f);
            floor.material = green;
            EndEpisode();

        }
        if (other.TryGetComponent<Boundary>(out Boundary boundary))
        {
            SetReward(-1f);
            floor.material = red;
            EndEpisode();
        }
    }
}
