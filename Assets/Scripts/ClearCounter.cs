// Ignore Spelling: Spown

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO kitchenObject;
    [SerializeField]
    private Transform TopPoint;
    [SerializeField]
    private bool test;
    [SerializeField]
    private ClearCounter secondClearCounter;
    private KitchenObject spownKitchenObject;

    private void Update() {
        //* we need to re-transform or move the kitchenObject to another clear counter top point
        if (test && Input.GetKeyDown(KeyCode.T)) {
            if (spownKitchenObject != null) {
                spownKitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }

    public void Interact() {
        if (spownKitchenObject == null) {
            Transform kitchenObjectTransform = Instantiate(kitchenObject.prefab, TopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            spownKitchenObject.SetClearCounter(this);
        }
        else {
            Debug.Log(spownKitchenObject.GetClearCounter());
        }   
    }
    public Transform GetKitchenObjectFollowTransform() {
        return TopPoint;
    }
    public void ClearSpownKitchenObject() {
        spownKitchenObject = null;
    }
    public bool HasSpownKitchenObject() {
        return spownKitchenObject != null;
    }
    public void SetSpownKitchenObject(KitchenObject kitchenObject) {
        spownKitchenObject = kitchenObject;
    }
}
