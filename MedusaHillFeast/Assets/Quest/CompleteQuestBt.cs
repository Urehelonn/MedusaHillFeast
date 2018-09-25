using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuestBt : MonoBehaviour {
    public QuestManager qm;
    public GameObject qum;

    public GameObject disable;
    public GameObject enable;

    public int completeCurrQuest;
    public bool enableBt = false;

    public void onClick()
    {
        Debug.Log("Quest complete button hit.");
        if (enableBt && qm.currQuest.Count!=0)
        {
            if (qm.currQuest[completeCurrQuest].questObjCount >= qm.currQuest[completeCurrQuest].questObjRequirement)
            {
                Debug.Log("Quest " + completeCurrQuest + " is going to set to complete.");
                qm.CompleteQuest(completeCurrQuest);
                Debug.Log("Quest " + completeCurrQuest + " is completed.");
                
                disable.SetActive(false);
                enable.SetActive(true);

                qum.GetComponent<MenuShowAtKeyUp>().closeMenu();
            }
            else
            {
                Debug.Log("Quest object not enough.");
            }
        }
    }
}