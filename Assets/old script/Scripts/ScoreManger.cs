using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;



public enum Choices
{
    Defect,
    Cooperate
}
public class ScoreManger : MonoBehaviour
{
    [SerializeField] GameObject RandomAgent = null;
    [SerializeField] GameObject AIAgent = null;
    public List<Choices> PreviousAnswers = new List<Choices>();
    public Choices CurrentAgentChoice = Choices.Cooperate;
    public Choices CurrentRandomChoice = Choices.Cooperate;

    public float StartTurn(int AgentChoice)
    {
        int RandomChoice = RandomAgent.GetComponent<RandomAgent>().PickRandom();

        return CalculatePoints(AgentChoice, RandomChoice);

    }
    public void EndTurn()
    {
        AddDecision(CurrentRandomChoice);
    }
    public void AddDecision(Choices Choice)
    {

        PreviousAnswers.Add(Choice);
    }

    public float[] GetChoices()
    {
        return List_ConvertChoiceToFloat(PreviousAnswers);
    }

    private float[] List_ConvertChoiceToFloat(List<Choices> Choices)
    {
        float[] ChoicesAsFloats = new float[Choices.Count];
        for (int i = 0; i < Choices.Count; i++)
        {
            ChoicesAsFloats[i] = ChoiceToFloat(Choices[i]);
        }
        return ChoicesAsFloats;
    }

    private int ChoiceToFloat(Choices choice)
    {
        switch (choice)
        {
            case Choices.Cooperate:
                return 0;
            case Choices.Defect:
                return 1;
            default:
                return 0;
        }
    }

    private float CalculatePoints(int AiAgentChoice, int RandomAgentChoice)
    {
        //Random Agent Defects
        if (AiAgentChoice == 0 && RandomAgentChoice == 1) { return 0f; }

        //Both Defect
        if (AiAgentChoice == 1 && RandomAgentChoice == 1) { return 1f; }

        //Both cooperate
        if (AiAgentChoice == 0 && RandomAgentChoice == 0){return 2f;}

        //Ai agent Defect
        if (AiAgentChoice == 1 && RandomAgentChoice == 0) { return 3f; }

        return 0;
    }
}
