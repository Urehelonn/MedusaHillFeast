using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public static QuestManager qm;
    public List<Quest> questList = new List<Quest>();   //master quest list
    public List<Quest> currQuest = new List<Quest>();   //current running quest

    //private values for quest
    private void Awake()
    {
        if(qm == null)
        {
            qm = this;
        }
        //prevent doubling quest
        else if(qm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //check quest, pass the trigger of the object as perameter, set to triger the quest to acceptable
    /*public void QuestRequest(QuestObject NPCQO)
    {
        //check for avaliable quest
        if (NPCQO.avaliableQuestIDs.Count > 0)
        {

            for (int i = 0; i < questList.Count; i++)
            {
                for (int j = 0; j < NPCQO.avaliableQuestIDs.Count; j++)
                {
                    if (questList[i].questID == NPCQO.avaliableQuestIDs[j] 
                        && questList[i].progress == Quest.QuestProgress.AVALIABLE)
                    {
                        Debug.Log("Avaliable Quest ID: " + NPCQO.avaliableQuestIDs[j] 
                            + " " + questList[i].progress);
                        //testing
                        AcceptQuest(NPCQO.avaliableQuestIDs[j]);
                        //get quest manager ui

                    }
                }
            }
        }

        //check for active quest
         (int i = 0; i < currQuest.Count; i++) {
            for (int j = 0; j < NPCQO.currQuestIDs.Count; j++)
            {
                if(currQuest[i].nextQuestID == NPCQO.currQuestIDs[j]
                    && (currQuest[i].progress == Quest.QuestProgress.ACCEPTED
                    || currQuest[i].progress==Quest.QuestProgress.COMPLETE))
                {
                    Debug.Log("Accepted or Complete Quest ID: " + NPCQO.currQuestIDs[j]+ " is " +
                        currQuest[i].progress);

                    CompleteQuest(NPCQO.currQuestIDs[j]);
                    //quest ui manager
                }
            }
        }
    }*/

    //Accept Quest
    public void AcceptQuest(int questID)
    {
        Debug.Log("try to accept quest "+ questID);
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].questID == questID && questList[i].progress 
                == Quest.QuestProgress.AVALIABLE)
            {
                currQuest.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;
            Debug.Log("quest accept: " + questID);
            }
            else
            {
                Debug.Log("quest accept error: " + questID);
            }
        }
    }
    //give up quest
    //which will never be used probably
    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].questID == questID && questList[i].progress 
                == Quest.QuestProgress.ACCEPTED)
            {
                questList[i].progress = Quest.QuestProgress.AVALIABLE;
                currQuest[i].questObjCount = 0; //reset object count for it;
                currQuest.Remove(currQuest[i]);
            }
        }
    }

    //complete quest
    public void CompleteQuest(int currQ)
    {
        int chainQ = currQ;
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].questID == currQuest[currQ].questID && questList[i].progress 
                == Quest.QuestProgress.COMPLETE)
            {
                chainQ = i;
                questList[i].progress = Quest.QuestProgress.DONE;
                currQuest.Remove(currQuest[currQ]);

                //add reward blah blah

                break;
            }
        }

        //after complete this one, active next chain quest if available.
        CheckChainQuest(chainQ);
    }


    //check chain quest
    void CheckChainQuest(int questID)
    {
        int tempID = 0;
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].questID == questID && questList[i].nextQuestID > 0)
            {
                tempID = questList[i].nextQuestID;
            }
        }
        if (tempID > 0)
        {
            for(int i=0; i < questList.Count; i++)
            {
                //unlock the next chain quest
                if(questList[i].questID==tempID
                    && questList[i].progress == Quest.QuestProgress.NOT_AVALIABLE)
                {
                    questList[i].progress = Quest.QuestProgress.AVALIABLE;
                }
            }
        }
    }

    //Add quest required items
    public void AddQuestItem(string questObject, int itemAmount)
    {
        for(int i=0;i< currQuest.Count; i++)
        {
            if(currQuest[i].questObj == questObject && currQuest[i].progress 
                == Quest.QuestProgress.ACCEPTED)
            {
                currQuest[i].questObjCount += itemAmount;
            }

            if(currQuest[i].questObjCount>= currQuest[i].questObjRequirement
                && currQuest[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currQuest[i].progress = Quest.QuestProgress.COMPLETE;
            }
        }

    }

    //boolean to check progress of the quest
    public bool RequestAvilableQuest(int questID)
    {
        for(int i = 0; i < questList.Count; i++)
        {
            if (questList[i].questID == questID && questList[i].progress 
                == Quest.QuestProgress.AVALIABLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].questID == questID && questList[i].progress 
                == Quest.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].questID == questID && questList[i].progress 
                == Quest.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }
}
