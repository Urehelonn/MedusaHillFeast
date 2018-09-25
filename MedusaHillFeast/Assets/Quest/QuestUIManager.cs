using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {

    public static QuestUIManager qum;
    public QuestManager qm;


    //bools to enable the penal logs
    public bool checkQuest;

    //panels
    public GameObject currQuestDes;

    //quest object
    //private QuestObject currQuestObject;

    //quest list
    public List<Quest> currQuestList;

    //buttons
    public GameObject qButton;
    public List<GameObject> qButtons = new List<GameObject>();
    public GameObject completeBt;

    //info
    public Text questTitle;
    public Text questDes;
    public Text questSum;

    //panel to place the quest buttons
    public Transform qbPanel;

    private void Awake()
    {
        if(qum == null)
        {
            qum = this;
        }
        else if (qum != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	}

    //called by open up the menu
    public void FreshQuestDescription()
    {
        //clear quest description if the quest is checked
        questTitle.text = "";
        questDes.text = "Select a quest to get its description. ";
        questSum.text = "";
    }

    //called when the quest panel is opened
    public void FillQuestButtons()
    {
        //add current quest information into the currquestlist
        for(int i = 0; i < qm.currQuest.Count; i++)
        {
            currQuestList.Add(qm.currQuest[i]);
        }

        for(int i = 0; i < currQuestList.Count; i++)
        {
            GameObject questBt = Instantiate(qButton);
            QuestButtonScript qbScipt = questBt.GetComponent<QuestButtonScript>();

            qbScipt.questID = currQuestList[i].questID;
            qbScipt.questTitle.text = currQuestList[i].title;

            questBt.transform.SetParent(qbPanel, false);
            qButtons.Add(questBt);
        }
    }

    //after click each current quest title button, show quest title and description and quest summary
    //using questID to seach for the quest is the wrong way, didnt find the fix so far
    //use 0 to access the first of the current quest instead
    public void AddCurrQuestInfos(int questID)
    {
        questTitle.text = currQuestList[0].title;
        questDes.text = currQuestList[0].description;
        completeBt.GetComponent<CompleteQuestBt>().enableBt = true;

        questSum.text = currQuestList[0].questObj + " : "
            + currQuestList[0].questObjCount + " / " + currQuestList[0].questObjRequirement
            + " .";
    }

    //called when the quest panel is closed, empty the list and button 
    //so it can be add correctly next time
    public void ClearButtons()
    {
        currQuestList.Clear();
        completeBt.GetComponent<CompleteQuestBt>().enableBt = false;

        //clear buttons
        for (int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }
        qButtons.Clear();
    }
}
