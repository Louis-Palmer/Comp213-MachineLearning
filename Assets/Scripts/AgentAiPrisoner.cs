using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class AgentAiPrisoner : Agent
{
    [SerializeField] Manager manager = null;
    [SerializeField] int counter = 0;

    public override void OnEpisodeBegin()
    {
        //Debug.Log("began Episode");
        base.OnEpisodeBegin();
        manager.TriggerTurn();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {

        base.OnActionReceived(actions);
        int chosenAction = actions.DiscreteActions[0];
        //Debug.Log("Ai Chose "+chosenAction);
        manager.AIChoiceAsInt = chosenAction;

        SetReward(manager.GetRewardFromscript());

        if (counter== 50)
        {
            counter = 0;
            manager.ClearList();
            //EndEpisode();

        }
        else
        {
            counter++;
        }

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);
        sensor.AddObservation(manager.GetChoiceList());
    }

    public void TriggerEndEpisode()
    {
        EndEpisode();
    }
}
