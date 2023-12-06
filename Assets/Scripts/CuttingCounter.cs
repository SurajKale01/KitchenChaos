using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //There is no kitchenobject here
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player is not carrying anything;
            }
        }
        else
        {
            //there is a kitchenObject here;
            if (player.HasKitchenObject())
            {
                //Player is carrying something;
            }
            else
            {
                //Player is not carrying anything;
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            //there is kitchenobject here;
            GetKitchenObject().DestorySelf();

            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);

        }
    }
}
