// Ignore Spelling: Spown

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player) {
        if (!this.HasKitchenObjectInParent() && player.HasKitchenObjectInParent()) {
            player.GetKitchenObject().SetKitchenObjectParent(this);
        }
        else if (this.HasKitchenObjectInParent()&& !player.HasKitchenObjectInParent()) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
        else Debug.Log("No Element To Pick Up Or Drop");
    }


}
