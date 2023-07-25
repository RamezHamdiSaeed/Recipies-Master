using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField]
    private Transform TopPoint;
    private KitchenObject spawnKitchenObject;
    public virtual void Interact(Player player) {
        Debug.LogError("BaseCounter.Interact()");
           }
    public virtual void InteractAlternate(Player player) {
        Debug.LogError("BaseCounter.InteractAlternate()");
           }

    public Transform GetKitchenObjectFollowTransform() {
        return TopPoint;
    }
    public void ClearKitchenObjectInParent() {
        spawnKitchenObject = null;
    }
    public bool HasKitchenObjectInParent() {
        return spawnKitchenObject != null;
    }
    public void SetKitchenObjectInParent(KitchenObject kitchenObject) {
        spawnKitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return spawnKitchenObject;
    }

}
