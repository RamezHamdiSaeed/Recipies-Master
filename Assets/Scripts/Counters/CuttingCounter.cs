using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter {
    public float cuttingProgressNormalized;
    public EventHandler onCuttingCounterInteract;
    public EventHandler<OnCuttingCounterProgressEventArgs> onCuttingCounterProgress;
    public class OnCuttingCounterProgressEventArgs : EventArgs {
        public float progressNormalized;
    }
    [SerializeField]
    private CuttingRecipesSO[] cuttingRecipes;
    private int cuttingProgress;
    

    public override void Interact(Player player) {
        if (!HasKitchenObjectInParent() && player.HasKitchenObjectInParent()) {
            if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                cuttingProgress = 0;
            KitchenObjectsSO kitchenObjectSOInput = GetKitchenObject().GetKitchenObjectSO();
            CuttingRecipesSO parentCuttingRecipe = GetCuttingRecipe(kitchenObjectSOInput);
                onCuttingCounterProgress?.Invoke(this,new OnCuttingCounterProgressEventArgs { progressNormalized = (float)cuttingProgress / parentCuttingRecipe.cuttingProgressMax });
            }
            else Debug.Log("attempts to put non CuttingRecipesSO.input (KitchenObjectsSO) ");
        }
        else if (HasKitchenObjectInParent() && !player.HasKitchenObjectInParent()) {
            GetKitchenObject().SetKitchenObjectParent(player);
        }
        else Debug.Log("No Element To Pick Up Or Drop");
    }
    public override void InteractAlternate(Player player) {
        cuttingProgress++;
        onCuttingCounterInteract?.Invoke(this,EventArgs.Empty);
        if (HasKitchenObjectInParent()&& HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {
            KitchenObjectsSO kitchenObjectSOInput = GetKitchenObject().GetKitchenObjectSO();
            CuttingRecipesSO parentCuttingRecipe = GetCuttingRecipe(kitchenObjectSOInput);
            onCuttingCounterProgress?.Invoke(this, new OnCuttingCounterProgressEventArgs { progressNormalized = (float)cuttingProgress / parentCuttingRecipe.cuttingProgressMax });
        
            if (cuttingProgress >= parentCuttingRecipe.cuttingProgressMax) {
                KitchenObjectsSO outPutKitchenObjectSO = GetOutputForInput(kitchenObjectSOInput);
                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(outPutKitchenObjectSO, this);
            }

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

        public CuttingRecipesSO GetCuttingRecipe(KitchenObjectsSO kitchenObjectSO) {
            foreach (CuttingRecipesSO cuttingRecipe in cuttingRecipes) {
                if (cuttingRecipe.input == kitchenObjectSO) {
                    return cuttingRecipe;
                }
            }
            return null;
        }

    public KitchenObjectsSO GetOutputForInput(KitchenObjectsSO kitchenObjectSO) {
        if (HasRecipeWithInput(kitchenObjectSO)) {
            return GetCuttingRecipe(kitchenObjectSO).output;
        }
            return null;
    }
    } 
