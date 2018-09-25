using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishBtHandler : MonoBehaviour {

    public bool enable;
    public GameObject ingredients;

	void Start () {
        enable = false;
        ingredients.SetActive(enable);
    }
    

    public void OnClick()
    {
        enable = !enable;
        ingredients.SetActive(enable);
    }
}
