using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO prefabKitchenObject;
    private ClearCounter clearCounter;
    public void SetClearCounter(ClearCounter clearCounter) {
        if (this.clearCounter != null) this.clearCounter.ClearSpownKitchenObject();
        this.clearCounter = clearCounter;
        if (clearCounter.HasSpownKitchenObject()) {
            Debug.LogError("the target (second clear counter) has spownKitchenObject");
        }
        //! the below statement to transform the visual prefab to topPoint object in the hierarchy
            clearCounter.SetSpownKitchenObject(this);
            transform.parent = clearCounter.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter() {
        return clearCounter;
    }
}
