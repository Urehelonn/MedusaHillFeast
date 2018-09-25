using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButtonScript : MonoBehaviour {

    public int questID;
    public Text questTitle;

	//show info for selected quest

    public void ShowSelectQuestInfo()
    {
        QuestUIManager.qum.AddCurrQuestInfos(questID);
    }
}
