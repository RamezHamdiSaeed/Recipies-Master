using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler onContainerCounterInteract;
    [SerializeField]
    private KitchenObjectsSO kitchenObject;
    public override void Interact(Player player) {
        if (!player.HasKitchenObjectInParent()) {
                Transform kitchenObjectTransform = Instantiate(kitchenObject.prefab);
                kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
                onContainerCounterInteract?.Invoke(this,EventArgs.Empty);
        }
        else Debug.Log("Player Has Picked Element");
    }
}
