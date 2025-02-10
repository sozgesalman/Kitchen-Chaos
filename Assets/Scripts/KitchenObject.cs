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

    public void SetParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(kitchenObjectParent != null)
        {
            this.kitchenObjectParent = kitchenObjectParent;    
            
        }
        else
        {
            Debug.LogError("Parent already has kitchen object!");
        }
        this.transform.parent = kitchenObjectParent.HoldPosition();
        transform.localPosition = Vector3.zero;
       
    }

    public IKitchenObjectParent GetParent()
    {
        return kitchenObjectParent;
    }

}
