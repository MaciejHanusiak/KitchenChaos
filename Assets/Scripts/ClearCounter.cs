using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public void Interact()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint); // Create new kitchen object
            kitchenObjectTransform.localPosition = Vector3.zero; // Set position of this object to zero
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        }

    }


}
