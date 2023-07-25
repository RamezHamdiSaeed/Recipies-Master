using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{  
    [SerializeField]
    private CuttingRecipesSO[] cuttingRecipes;

    public override void Interact(Player player) {
        if (!HasKitchenObjectInParent() && player.HasKitchenObjectInParent()) {
            if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else Debug.Log("attempts to put non CuttingRecipesSO.input (KitchenObjectsSO) ");
        }
        else if (HasKitchenObjectInParent() && !player.HasKitchenObjectInParent()) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
        else Debug.Log("No Element To Pick Up Or Drop");
    }
    public override void InteractAlternate(Player player) {
        if (HasKitchenObjectInParent()) {
            KitchenObjectsSO OutputkitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            
            KitchenObject.SpawnKitchenObject(OutputkitchenObjectSO,this);


        }
        else {
            Debug.Log("No Element To InteractAlternate");
        }   
    }
    public bool HasRecipeWithInput(KitchenObjectsSO kitchenObjectSO) {
        foreach (CuttingRecipesSO cuttingRecipe in cuttingRecipes) {
            if (cuttingRecipe.input == kitchenObjectSO) {
                return true;
            }
        }
        return false;
    }
    public KitchenObjectsSO GetOutputForInput(KitchenObjectsSO kitchenObjectSO) {
        foreach (CuttingRecipesSO cuttingRecipe in cuttingRecipes) {
            if (cuttingRecipe.input==kitchenObjectSO) { 
                return cuttingRecipe.output;
            }
        }
        return null;
    }
}
