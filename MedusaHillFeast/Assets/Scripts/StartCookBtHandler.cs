using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCookBtHandler : MonoBehaviour {
    public GameObject cookManage;
    public GameObject dishBt;

    public void onClick()
    {
        if (dishBt.GetComponent<DishBtHandler>().enable)
        {
            cookManage.GetComponent<CookingManager>().startCook(0,"Pudding Fries");
        }
    }
}
