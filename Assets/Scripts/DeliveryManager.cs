using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimermax = 4f;
    private int waitingRecipeMax = 4;

    private void Awake()
    {

        Instance = this;

        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimermax;

            if(waitingRecipeSOList.Count < waitingRecipeMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);
            }
        }

    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if(waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                //Has the same no. of ingredients;
                bool plateContentsMatchesRecipe = true;

                foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    //Cycling through all ingredients in the recipe
                    bool ingredientFound = false;

                    foreach(KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        //Cycling through all ingredients in the plate
                        if(plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            //Ingredients Matches
                            ingredientFound = true;
                            break;
                        }
                    }
                    if(!ingredientFound)
                    {
                        //This recipe Ingredients not found on the plate
                        plateContentsMatchesRecipe = false;
                    }
                }
                if(plateContentsMatchesRecipe)
                {
                    //Player delivered the correct recipe
                    Debug.Log("Player delivered the correct recipe");
                    waitingRecipeSOList.RemoveAt(i);
                    return;
                }
            }

        }

        //No Matches Found
        //Player did not received correct recipe
        Debug.Log("Player did not delivered correct recipe");
    }



}
