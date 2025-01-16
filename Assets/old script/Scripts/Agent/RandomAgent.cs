using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAgent : MonoBehaviour
{
    public int PickRandom()
    {
        int Number = Random.Range(0, 2);
        if (Number == 1) { TriggerDefect(); return Number; }
        if (Number == 0) { triggerCoop(); return Number; }
        return 0;
    }

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        PickRandom();
    //    }
    //}

    private void triggerCoop()
    {
        this.gameObject.GetComponent<TestOutPut>().TriggerCOOP();
    }

    private void TriggerDefect()
    {
        this.gameObject.GetComponent<TestOutPut>().TriggerDefect();

    }
}
