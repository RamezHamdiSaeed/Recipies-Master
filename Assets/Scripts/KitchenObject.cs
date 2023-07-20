// Ignore Spelling: Getkitchen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO prefabKitchenObject;
    private IKitchenObjectParent kitchenObjectParent;
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent) {
        if (this.kitchenObjectParent != null) this.kitchenObjectParent.ClearKitchenObjectParent();
        this.kitchenObjectParent = kitchenObjectParent;
        if (this.kitchenObjectParent.HasKitchenObjectParent()) {
            Debug.LogError("the target has spownKitchenObject");
        }
        //! the below statement to transform the visual prefab to topPoint object in the hierarchy
            this.kitchenObjectParent.SetKitchenObjectParent(this);
        transform.parent = this.kitchenObjectParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetkitchenObjectParent() {
        return kitchenObjectParent;
    }
}
