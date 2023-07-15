using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO prefabKitchenObject;
    public KitchenObjectsSO getPrefabKitchenObject() { 
        return prefabKitchenObject;
    }
}
