using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public Text nameText;
    public Text dialogText;
    public GameObject dBox;
    public GameObject setPlayerAbleToMove;
    public GameObject dialogTrigger;
    public GameObject currDM;
    public GameObject nextDM;
    public GameObject setMenuAbleToShow;

    private Dialog[] dialogAry;
    private int count;

    public void StartDialog(Dialog[] dialog)
    {
        setPlayerAbleToMove.GetComponent<CharacterControl>().playerMovingEnable = false;
        setMenuAbleToShow.GetComponent<MenuShowAtKeyUp>().talking = true;

        dialogAry = dialog;
        dBox.SetActive(true);
        count = 1;
        Debug.Log("Starting conversation with "+ dialog[0].name);
        dialogText.text = dialog[0].sentences;
        nameText.text = dialog[0].name;
    }

    public void DisplayNext()
    {
        if(count >= dialogAry.Length)
        {
            EndDialog();
            return;
        }
        string sentence = dialogAry[count].sentences;
        string name = dialogAry[count].name;
        dialogText.text = sentence;
        nameText.text = name;
        count++;        
    }

    protected void EndDialog()
    {
        Debug.Log("End of conversation.");
        dBox.SetActive(false);
        setPlayerAbleToMove.GetComponent<CharacterControl>().playerMovingEnable = true;
        setMenuAbleToShow.GetComponent<MenuShowAtKeyUp>().talking = false;
        dialogTrigger.GetComponent<DialogTrigger>().doneChat = true;
        dialogTrigger.GetComponent<DialogTrigger>().startChat = false;

        //trigger to enable the quest if this conversation is a quest trigger
        dialogTrigger.GetComponent<DialogTrigger>().checkQuestTriger();
        currDM.SetActive(false);
        nextDM.SetActive(true);
        /*if (dialogTrigger.GetComponent<DialogTrigger>().questTrigger)
        {
            Debug.Log("attempting to accept quest : " + dialogTrigger.GetComponent<DialogTrigger>().questNeeded);
            QuestManager.qm.AcceptQuest(dialogTrigger.GetComponent<DialogTrigger>().questNeeded);
        }*/
    }
}
