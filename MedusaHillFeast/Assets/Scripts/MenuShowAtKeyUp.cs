using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShowAtKeyUp : MonoBehaviour {

    public GameObject player;
    public GameObject menu;

    public bool openMenu;
    public bool talking;

    // Use this for initialization
    void Start () {
        openMenu = false;
    }
	
	// Update is called once per frame
	void Update () {

        //open menu
        if (Input.GetKeyUp(KeyCode.Escape) && !talking)
        {
            if (!openMenu)
            {
                turnOnMenu();
            }

        //close menu
            else
            {
                closeMenu();
            }
        }
        menu.SetActive(openMenu);
    }
    public void turnOnMenu()
    {
        Debug.Log("escape input for open menu");
        player.GetComponent<CharacterControl>().playerMovingEnable = false;
        openMenu = true;

        //add quest object to ensure that the quest can be finish
        QuestManager.qm.AddQuestItem("Check book", 1);

        //get all the quest infos and add the quest button list
        QuestUIManager.qum.FreshQuestDescription();
        QuestUIManager.qum.FillQuestButtons();

    }

    public void closeMenu()
    {
        Debug.Log("escape input for close menu");
        player.GetComponent<CharacterControl>().playerMovingEnable = true;
        openMenu = false;

        //add quest object
        QuestManager.qm.AddQuestItem("Check book", 1);

        //clear all the quest button and list
        QuestUIManager.qum.FreshQuestDescription();
        QuestUIManager.qum.ClearButtons();
    }
}
