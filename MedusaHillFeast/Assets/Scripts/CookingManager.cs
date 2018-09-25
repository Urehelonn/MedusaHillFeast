using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : MonoBehaviour {

    public GameObject bag;
    public ItemObject item;
    public Text popUpMsg;

    public List<DishRequirement> dishRequirement;
    public bool CheckBag(int dishID)
    {
        bool result=true;

        /* for(int i = 0; i < dishRequirement[dishID].ingredientsRequire.Count; i++)
        {

            if (!bag.GetComponent<BackPack>().checkIng(dishRequirement[dishID].ingredientsRequire[i])) break;
            if (i >= dishRequirement[dishID].ingredientsRequire.Count
                && bag.GetComponent<BackPack>().checkIng(dishRequirement[dishID].ingredientsRequire[i])) result = true;
        }*/

       foreach (Ingredients ingR in dishRequirement[dishID].ingredientsRequire)
        {
            if (!bag.GetComponent<BackPack>().checkIng(ingR))
            {
                result = false;
                break;
            }
            //check if there are enough requirement ingredients in the bag
        }
        return result;
    }

    public void startCook(int dishID, string dishName)
    {
        //check if the material is enough if enough, 
        //and player's level meet the goal,start cook
        if (CheckBag(dishID) && levelCheck())
        {
            //remove required ingredients from the bag
            romoveIngredients(dishID);

            //pop messages after done
            StartCoroutine(popMessage(dishName, 1.5f,true));

            //add dish into the bag
            addDish(dishID);
            QuestManager.qm.AddQuestItem("Cook Pudding Fries", 1);
            Debug.Log("cooked: "+dishID);
        }
        else
        {
            StartCoroutine(popMessage(dishName, 1.5f, false));
        }

    }

    private void romoveIngredients(int dishID)
    {
        foreach (Ingredients ingR in dishRequirement[dishID].ingredientsRequire)
        {
            bag.GetComponent<BackPack>().removeItem(ingR.ingID, ingR.ingNum);
        }
    }

    public void addDish(int dishID)
    {
        bag.GetComponent<BackPack>().addItem(item);
    }

    public bool levelCheck()
    {
        //unimplemented
        return true;
    }

    IEnumerator popMessage(string message, float delay,bool check)
    {
            Debug.Log("popup msg");

        if (check)
        {
            popUpMsg.text = "Complete Cooking: "+ message;
            popUpMsg.enabled = true;

            yield return new WaitForSeconds(delay);
            popUpMsg.enabled = false;
        }

        else
        {
            popUpMsg.text = "No enough ingredients. ";
            popUpMsg.enabled = true;
            yield return new WaitForSeconds(delay);
            popUpMsg.enabled = false;
        }
    }
}
