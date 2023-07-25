using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{  
    [SerializeField]
    private KitchenObjectsSO kitchenObject;

    public override void Interact(Player player) {
        if (!HasKitchenObjectInParent() && player.HasKitchenObjectInParent()) {
            player.GetKitchenObject().SetKitchenObjectParent(this);
        }
        else if (HasKitchenObjectInParent() && !player.HasKitchenObjectInParent()) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
        else Debug.Log("No Element To Pick Up Or Drop");
    }
    public override void InteractAlternate(Player player) {
        if (HasKitchenObjectInParent()) {
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(kitchenObject,this);


        }
        else {
            Debug.Log("No Element To InteractAlternate");
        }   
    }
}
