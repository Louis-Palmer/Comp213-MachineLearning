using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;

public class Manager : MonoBehaviour
{
   
    enum Choice
    {
        Defect,
        Cooperate,
        Default
    }
    [SerializeField] AgentAiPrisoner AiScript = null;
    public int AIChoiceAsInt = 0;
    public int RandomChoiceAsInt = 0;

    [SerializeField] Choice AIChoiceAsChoice = Choice.Default;

    [SerializeField] List<float> CurrentRandomChoiceAsList = new List<float>();
    public List<float> RandomChoiceList = new List<float>(50);

    [SerializeField] float Reward = 0f;



    
    public void TriggerTurn()
   {
        //Debug.Log("Triggered Turn");
        AiScript.RequestDecision();
        AIChoiceAsChoice = MapIntToChoice(AIChoiceAsInt);

        Choice RandomsChoice = RandomChoice();
        //AiScript.SetReward(4f);
        //AiScript.AddRewardo(CalculateScore(AIChoiceAsChoice, RandomsChoice));

        Reward = CalculateScore(AIChoiceAsChoice, RandomsChoice);
        CurrentRandomChoiceAsList.Add(MapChoiceToInt(RandomsChoice));

        

    }


    public void ClearList()
    {
        //Debug.Log("Calling ClearList");
        //RandomChoiceList = CurrentRandomChoiceAsList;

        for(int i = 0;i<=49; i++)
        {
            RandomChoiceList[i] = CurrentRandomChoiceAsList[i];
        }
        CurrentRandomChoiceAsList.Clear();
    }

    public float[] GetChoiceList()
    {
        return RandomChoiceList.ToArray();
    }


    private Choice RandomChoice()
    {
        return (MapIntToChoice(Random.Range(0, 2)));
    }



    /// <summary>
    /// function to map into to coice
    /// </summary>
    /// <param name="Number"></param>
    /// <returns></returns>
    private Choice MapIntToChoice(int Number)
    {
        Number = Mathf.Clamp(Number, 0, 1);
        if (Number == 0) { return Choice.Cooperate; }
        if (Number == 1) { return Choice.Defect; }

        Debug.Log("SomethingWentWrong In" + this.GetComponent<Manager>()); return Choice.Default;

    }

    private float MapChoiceToInt(Choice Chosen)
    {
        if (Chosen == Choice.Cooperate) { return 0f; }
        if (Chosen == Choice.Defect) { return 1f; }

        Debug.Log("Something went wrong");
        return 0f;
    }

    /// <summary>
    /// function to work out score
    /// </summary>
    /// <param name="AgentChoice"></param>
    /// <param name="RandomChoice"></param>
    /// <returns></returns>
    private float CalculateScore(Choice AgentChoice, Choice RandomChoice)
    {
        if (AgentChoice == Choice.Defect && RandomChoice == Choice.Cooperate) {    //Debug.Log("3f");
            return 3f;}                                                            //
        if (AgentChoice == Choice.Cooperate && RandomChoice == Choice.Cooperate) { //Debug.Log("2f"); 
            return 2f;}                                                            //
        if (AgentChoice == Choice.Defect && RandomChoice == Choice.Defect) {       //Debug.Log("1f"); 
            return 1f;}                                                            //
        if (AgentChoice == Choice.Cooperate && RandomChoice == Choice.Defect) {    //Debug.Log("0f");
            return 0f;}

        Debug.Log("Someone chose default?"); return 0;

    }

    public float GetRewardFromscript()
    {
        return Reward;
    }
}
