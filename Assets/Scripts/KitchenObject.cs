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
        if (this.kitchenObjectParent != null) this.kitchenObjectParent.ClearKitchenObjectInParent();
        this.kitchenObjectParent = kitchenObjectParent;
        if (this.kitchenObjectParent.HasKitchenObjectInParent()) {
            Debug.LogError("the target has spawnKitchenObject");
        }
        //! the below statement to transform the visual prefab to topPoint object in the hierarchy
            this.kitchenObjectParent.SetKitchenObjectInParent(this);
        transform.parent = this.kitchenObjectParent.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetkitchenObjectParent() {
        return kitchenObjectParent;
    }
    public void DestroySelf() {
        kitchenObjectParent.ClearKitchenObjectInParent();
        Destroy(gameObject);
    }
    public static KitchenObject SpawnKitchenObject(KitchenObjectsSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent) {

        Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
        return kitchenObject;
    }
    public KitchenObjectsSO GetKitchenObjectSO() {
        return prefabKitchenObject;
    }

}
