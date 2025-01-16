using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PrisonerAgent : Agent
{
    [SerializeField] GameObject ScoreManger = null;
    [SerializeField] GameObject InputOBJ = null;
    private void Start()
    {
        ScoreManger = GameObject.FindGameObjectWithTag("ScoreManager");
        
    }
    public override void OnEpisodeBegin()
    {
        Debug.Log("episodebegan");
        RequestDecision();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        int chosenAction = actions.DiscreteActions[0];
        Debug.Log(chosenAction);
        //Debug.Log(ScoreManger.GetComponent<ScoreManger>().StartTurn(chosenAction));
        //SetReward(ScoreManger.GetComponent<ScoreManger>().StartTurn(chosenAction));
        if (chosenAction == 0) { TriggerDefect(); }
        if (chosenAction == 1) { TriggerCoop(); }
        EndEpisode();
        //calling end finished here
        //base.OnActionReceived(actions);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(34f);
        //sensor.AddObservation(GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManger>().GetChoices());
        //base.CollectObservations(sensor);
    }


    private void TriggerDefect() 
    {
        this.gameObject.GetComponent<TestOutPut>().TriggerDefect();
    }
    private void TriggerCoop()
    {
        this.gameObject.GetComponent<TestOutPut>().TriggerCOOP();
    }
}
