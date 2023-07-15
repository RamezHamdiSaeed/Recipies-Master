using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO kitchenObject;
    [SerializeField]
    private Transform TopPoint;
    public void InteractMessage() {
        Debug.Log("Interaction with ClearCounter");
       Transform tomatoTranform= Instantiate(kitchenObject.kitchenObject, TopPoint);
        //! to insure that the child game object instantiated as a child in TopPoint will be without any offset from the parent transform position
        tomatoTranform.localPosition = Vector3.zero;
        //Debug.Log(kitchenObject.objectName);
        //! alternatively we will attach a script to each prefab to assign its own scriptable object and use its properties when the prefab instantiated in the scene to avoid accessing them when uninstantiated yet
        Debug.Log(tomatoTranform.GetComponent<KitchenObject>().getPrefabKitchenObject().objectName);
    }
}
