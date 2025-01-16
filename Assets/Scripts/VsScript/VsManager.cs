using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VsManager : MonoBehaviour
{
    enum Decision
    {
        None,
        Cooperate,
        Defect
    }

    [SerializeField] bool Algorithm = false;
    [SerializeField] TitForTat AgentAlgorithm = null;  
    [SerializeField] private float[,] GameHistory = new float[2,50];

    [SerializeField] private float[] AgentOneHistroy = new float[50];
    public float[] AgentTwoHistory = new float[50];

    [SerializeField] AgentScript Agent_One = null;
    [SerializeField] AgentScript Agent_Two = null;

    public float AgentOneDescision = -1;
    public float AgentTwoDescision = -1;

    [SerializeField] float AgentOneReward = 0f;
    [SerializeField] float AgentTwoReward = 0f;
    public int Counter = 1;

    public void TriggerTurn()
    {
        //Debug.Log("Turn Triggered");
        Agent_One.RequestDecision();
        if (!Algorithm) { Agent_Two.RequestDecision(); }
        else if (Algorithm) {AgentAlgorithm.GetMatchArray(); AgentAlgorithm.SetDecision(); }
        

        SetRewards(AgentOneDescision, AgentTwoDescision);
        MapDecisionToArray();

        if (Counter == 50) {ResetArray();Counter = 1; Agent_One.TriggerEndEpisode(); }
        else { Counter++; }


        
    }

    public float GetAgentOneReward()
    {
        return AgentOneReward;
    }
    public float GetAgentTwoReward()
    {
        return AgentTwoReward;
    }

    public void SetAgentOne(int Number)
    {
        if(Number == 0 || Number == 1)
        {
            //Debug.Log("numeber being set correctly i think " + Number);
            AgentOneDescision = Number;

            //Debug.Log("Decision for agents one is " + AgentOneDescision);
        }
        else
        {
            //Debug.Log("AgentOnesetting-1?");
            AgentOneDescision = -1;
        }
    }

    public void SetAgentTwo(int Number)
    {
        if (Number == 0 || Number == 1)
        {

            AgentTwoDescision = Number;
        }
        else
        {
            //Debug.Log("Agenttwosetting-1?");

            AgentTwoDescision = -1;
        }
    }

    private void SetRewards(float AgentOne, float AgentTwo)
    {
        Debug.Log("agent one is " + AgentOne + " : Agent two is " + AgentTwo);
        if(AgentOne == 0f && AgentTwo == 0f)
        {
            AgentOneReward = 2f;
            AgentOneReward = 2f;
        }

        else if (AgentOne == 1f && AgentTwo== 1f)
        {
            AgentOneReward = 1f;
            AgentTwoReward = 1f;
        }
        else if(AgentOne == 1f && AgentTwo == 0f)
        {
            AgentOneReward = 3f;
            AgentTwoReward = 0f;
        }

        else if(AgentOne == 0f && AgentTwo == 1f)
        {
            AgentOneReward = 0f;
            AgentTwoReward = 3f;
        }

        else
        {
            Debug.Log("Something Went Wrong");
            AgentOneReward = 0f;
            AgentTwoReward = 0f;
        }
    }

    private void MapDecisionToArray()
    {
      
        AgentOneHistroy[Counter-1] = AgentOneDescision;
        AgentTwoHistory[Counter-1] = AgentTwoDescision;


    }

    private void ResetArray()
    {
        for(int i = 0; i< 50; i++)
        {
            AgentOneHistroy[i] = -1;
            AgentTwoHistory[i] = -1;
        }
    }

    public float[] AgentOneObservation()
    {
        //int colums = GameHistory.GetLength(1);
        //float[] AgentOneObs = new float[colums];
        //for (int i = 0; i < colums; i++)
        //{
        //    AgentOneObs[i] = GameHistory[0, i];
        //}

        return AgentOneHistroy;
    }

    public float[] AgentTwoObservation()
    {
        //int colums = GameHistory.GetLength(1);
        //float[] AgentOneObs = new float[colums];
        //for (int i = 0; i < colums; i++)
        //{
        //    AgentOneObs[i] = GameHistory[1, i];
        //}

        return AgentTwoHistory;

        //float[,] NewArray = new float[50, 2];

        //for (int i = 0;i< GameHistory.GetLength(1); i++)
        //{
        //    float tempC1 = GameHistory[0,i];
        //    float tempC2 = GameHistory[1,i];

        //    NewArray[0,i] = tempC2;
        //    NewArray[1, i] = tempC1;
        //}
        //return NewArray;

    }
}
