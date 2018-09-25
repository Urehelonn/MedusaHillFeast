using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public Dialog[] dialog;
    public bool inTalkingArea;
    public bool startChat;
    public bool questTrigger;
    public int questNeeded;
    public bool doneChat;

    public DialogManager DM;
    public QuestManager qm;
    //get questId in order to trigger it

    //ensure the conversation only happen once, also trigger the quest

    void Start()
    {
        inTalkingArea = false;
        startChat = false;
        doneChat = false;
    }

    private void Update()
    {   
        if(inTalkingArea && Input.GetKeyUp(KeyCode.E) && !startChat &&!doneChat)
        {
            TriggerDialog();
        }
        else if (inTalkingArea && startChat )
        {
            if (Input.GetKeyUp(KeyCode.E) && inTalkingArea)
            {
                //FindObjectOfType<DialogManager>().DisplayNext();
                DM.GetComponent<DialogManager>().DisplayNext();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inTalkingArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inTalkingArea = false;
        }
    }


    public void TriggerDialog()
    {
        //FindObjectOfType<DialogManager>().StartDialog(dialog);
        DM.GetComponent<DialogManager>().StartDialog(dialog);
        startChat = true;

    }

    public void checkQuestTriger()
    {
        if (questTrigger)
        {
            Debug.Log("attempting to accept quest : " + questNeeded);
            QuestManager.qm.AcceptQuest(questNeeded);
        }
    }
}
