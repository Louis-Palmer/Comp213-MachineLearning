using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class TitForTat : MonoBehaviour
{
    [SerializeField] VsManager Manager = null;
    [SerializeField] float[] MatchHistory = new float[50];

    public void SetDecision()
    {
        Manager.AgentTwoDescision = CalculateDecision();
    }

    public void GetMatchArray()
    {
        MatchHistory = Manager.AgentOneObservation();
    }

    private float CalculateDecision()
    {
        if (Manager.Counter == 1) { return 0; }
        if (MatchHistory[Manager.Counter-2] == 0f)
        {
            return 0f;
        }
        if (MatchHistory[Manager.Counter-2] == 1f)
        {
            return 1f;
        }
        Debug.Log("ChoseNotham because" + MatchHistory[Manager.Counter - 1]);
        return 0f;
    }
}
