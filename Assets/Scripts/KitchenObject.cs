using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;

    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            // check if kitchen object has  IKitchenObjectParent, if yes set it to null
            this.kitchenObjectParent.ClearKitchenObject();
        }

        // set IKitchenObjectParent of kitchen obj to new IKitchenObjectParent
        this.kitchenObjectParent = kitchenObjectParent; 

        if (kitchenObjectParent.HasKitchenObject())
        {
            
            Debug.LogError("This IKitchenObjectParent already has a KitchenObject!");
        }
        else
        {
            // Set kitchen object to IKitchenObjectParent
            kitchenObjectParent.SetKitchenObject(this);
        }

        // Set position of kitchen object in game
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
        
    }
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
    
}
