using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOutPut : MonoBehaviour
{
    [SerializeField] private GameObject Defect_Obj = null;
    [SerializeField] private GameObject Coop_Obj = null;

    // Start is called before the first frame update
    void Start()
    {
        if (Defect_Obj == null) { Defect_Obj = this.gameObject.transform.GetChild(0).gameObject; }
        if (Coop_Obj == null) { Coop_Obj = this.gameObject.transform.GetChild(1).gameObject; }
    }

    public void TriggerDefect()
    {
        DisableAllOBJ();
        Defect_Obj.SetActive(true);
    }
    public void TriggerCOOP()
    {
        DisableAllOBJ();
        Coop_Obj.SetActive(true);
    }

    private void DisableAllOBJ()
    {
        Defect_Obj.SetActive(false);
        Coop_Obj.SetActive(false);    
    }

}
