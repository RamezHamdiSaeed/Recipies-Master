// Ignore Spelling: Spown

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField]
    private KitchenObjectsSO kitchenObject;
    [SerializeField]
    private Transform TopPoint;
    [SerializeField]
    private ClearCounter secondClearCounter;
    private KitchenObject spownKitchenObject;


    public void Interact(Player player) {
        if (spownKitchenObject == null) {
            Transform kitchenObjectTransform = Instantiate(kitchenObject.prefab, TopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            // ! we want to make the same logic for player and counters both of them so we will make them implements the same interface IKitchenObjectParent
        }
        else {
                spownKitchenObject.SetKitchenObjectParent(player);
        }   
    }
    public Transform GetKitchenObjectFollowTransform() {
        return TopPoint;
    }
    public void ClearKitchenObjectParent() {
        spownKitchenObject = null;
    }
    public bool HasKitchenObjectParent() {
        return spownKitchenObject != null;
    }
    public void SetKitchenObjectParent(KitchenObject kitchenObject) {
        spownKitchenObject = kitchenObject;
    }
}
