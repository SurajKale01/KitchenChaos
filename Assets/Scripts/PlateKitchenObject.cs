using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();


    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Not a valid Ingredient;
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Already Has these type;
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
        
    }

}
