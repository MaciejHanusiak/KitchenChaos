using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {   // There is no kitchen object here

            if (player.HasKitchenObject())
            {
                // Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {   // There is kitchen object here
            Debug.Log("There is kitchen object here");
            if (player.HasKitchenObject())
            {
                Debug.Log(" Player has kitchen object");
                // Player has kitchen object
                if (player.GetKitchenObject() is PlateKitchenObject)
                {
                    // Player is holding a Plate
                    Debug.Log("Player is holding a Plate");
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
            }
            else
            {
                // The player does not have an object
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }
    


}
