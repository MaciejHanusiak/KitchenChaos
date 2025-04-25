using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {   
            //Player already has kitchen object
        }
        else
        {
            // Player does not have a kitchen object
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab); // Create new kitchen object
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player); // Set this object to transform to parent
       
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }

    }
        
}
