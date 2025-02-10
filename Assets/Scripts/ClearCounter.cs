using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform spawnPosition;

    private KitchenObject kitchenObject;
 
   
    public void Interact()
    {
        print("Interact!");

        if (kitchenObject == null)
        {
            Transform kitchenObjectSO = Instantiate(this.kitchenObjectSO.objectPrefab, spawnPosition);
           
            kitchenObject = kitchenObjectSO.GetComponent<KitchenObject>();
            kitchenObjectSO.GetComponent<KitchenObject>().SetParent(this);

        }      
        else
        {
            print(kitchenObject.GetParent());
        }
    }

    public Transform HoldPosition()
    {
        return spawnPosition;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
   

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

   
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

   
}
