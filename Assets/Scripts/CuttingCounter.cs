using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
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

            if (player.HasKitchenObject())
            {
                // Player has kitchen object
            }
            else
            {
                // The player does not have an object
                this.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        
    }
    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            // There is no object here
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(cutKitchenObjectSO, this);
        }
    }
}
