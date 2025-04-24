using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;

    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            // check if kitchen object has clear Counter, if yes set it to null
            this.clearCounter.ClearKitchenObject();
        }

        // set clear counter of kitchen obj to new clear counter
        this.clearCounter = clearCounter; 

        if (clearCounter.HasKitchenObject())
        {
            
            Debug.LogError("This Clear Counter already has a KitchenObject!");
        }
        else
        {
            // Set kitchen object to clear counter
            clearCounter.SetKitchenObject(this);
        }

        // Set position of kitchen object in game
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
        
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
    
}
