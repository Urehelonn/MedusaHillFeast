using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DishRequirement{
    public string dishName;
    public int dishID;
    public int requireLv;
    public List<Ingredients> ingredientsRequire;
}
