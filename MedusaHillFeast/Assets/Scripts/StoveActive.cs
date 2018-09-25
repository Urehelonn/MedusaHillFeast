using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveActive : MonoBehaviour
{

    public GameObject player;
    public GameObject menu;
    public GameObject setMenuAbleToShow;
    public bool inArea;

    public bool openMenu;
    // Use this for initialization
    void Start()
    {
        openMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea)
        {
            //open menu
            if (Input.GetKeyUp(KeyCode.E))
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
    }
    public void turnOnMenu()
    {
        Debug.Log("e input for open menu");
        player.GetComponent<CharacterControl>().playerMovingEnable = false;
        setMenuAbleToShow.GetComponent<MenuShowAtKeyUp>().talking = true;
        openMenu = true;
    }

    public void closeMenu()
    {
        Debug.Log("e input for close menu");
        player.GetComponent<CharacterControl>().playerMovingEnable = true;
        setMenuAbleToShow.GetComponent<MenuShowAtKeyUp>().talking = false;
        openMenu = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            inArea = false;
        }
    }
}
