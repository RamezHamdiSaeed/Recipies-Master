// Ignore Spelling: Spown

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenObjectFollowTransform();
        public void ClearKitchenObjectParent();
        public bool HasKitchenObjectParent();
        public void SetKitchenObjectParent(KitchenObject kitchenObject);
}
