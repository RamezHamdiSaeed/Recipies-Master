// Ignore Spelling: Spown

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
        public Transform GetKitchenObjectFollowTransform();
        public KitchenObject GetKitchenObject();
        public void ClearKitchenObjectInParent();
        public bool HasKitchenObjectInParent();
        public void SetKitchenObjectInParent(KitchenObject kitchenObject);
}
