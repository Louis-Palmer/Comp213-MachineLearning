using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AgentScript : Agent
{
    [SerializeField] bool MasterAgent = false;
    [SerializeField] VsManager VsManager = null;
    public override void OnEpisodeBegin()
    {
        if (MasterAgent)
        {
            base.OnEpisodeBegin();
            VsManager.TriggerTurn();

        }
    }
    public override void OnActionReceived(ActionBuffers actions)
    {

        base.OnActionReceived(actions);
        int chosenAction = actions.DiscreteActions[0];
        //Debug.Log(MasterAgent + "Chose " + chosenAction);

        if (MasterAgent) { VsManager.SetAgentOne(chosenAction); }
        else if (!MasterAgent) { VsManager.SetAgentTwo(chosenAction); }

        if (MasterAgent)
        {
            SetReward(VsManager.GetAgentOneReward());
        }

        else if (!MasterAgent)
        {
            SetReward(VsManager.GetAgentTwoReward());
        }




        VsManager.TriggerTurn();

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);

        if (MasterAgent)
        {
            sensor.AddObservation(VsManager.AgentTwoObservation());
        }
        else if (!MasterAgent)
        {
            sensor.AddObservation(VsManager.AgentOneObservation());
        }
    }

    public void TriggerEndEpisode()
    {
        EndEpisode();
    }
}
