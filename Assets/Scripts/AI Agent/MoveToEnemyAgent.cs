using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToEnemyAgent : Agent
{
    //stores the target
    [SerializeField] private Transform targetTr;
    //win material
    [SerializeField] private Material green;
    //lose material
    [SerializeField] private Material red;
    //stores the mesh of the floor
    [SerializeField] private MeshRenderer floor;
 
    //handles the episode initialization
    public override void OnEpisodeBegin()
    {
        //randomly assigns a position to the agent and the target
        transform.localPosition = new Vector3(Random.Range(-8.5f,8.5f), 0,Random.Range( 0.5f,8.5f));
        targetTr.transform.localPosition = new Vector3(Random.Range(-8.5f, 8.5f), 0, Random.Range(-1.5f, -8.0f));
    }

    
    public override void CollectObservations(VectorSensor sensor)
    {   
        //collects information about the position of the agent and the target
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTr.transform.localPosition);

    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        //actions for x axis movement
        float moveX = actions.ContinuousActions[0];
        //actions for z axis movement
        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 2f;
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    //player controls
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
        
    }


    // gives / takes reward based on the outcome
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
