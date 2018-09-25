using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum QuestProgress{NOT_AVALIABLE, AVALIABLE, ACCEPTED, COMPLETE, DONE}

    public string title;    //quest title
    public int questID;     //quest unique id
    public QuestProgress progress;  //progress state for the quest
    public string description;  //quest description, from Giver/Receiver
    public string hint; //hit for quest, from Giver/Receiver
    public string fin;  //receive after finish the quest, from Giver/Receiver
    public string summary;  //queset summart, from Giver/Receiver
    public int nextQuestID; //id for next quest (if there is any)
    public string questObj; //name for the quest objective (also for remove)
    public int questObjCount;   //current number of object count
    public int questObjRequirement; //requirement, after reach this the quest can be complete
    public string reward;   //reward acquire after finish the quest

    GameObject quest;
    public QuestManager qm;
    
    public void StartQuest(int questID)
    {
        quest.SetActive(true);
    }

    public void FinishQuest(int questID)
    {
        quest.SetActive(false);
    }
}
