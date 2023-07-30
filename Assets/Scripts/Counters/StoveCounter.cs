using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter, IHasProgress {
    [SerializeField]
    //* cooking Recipes from uncooked to cooked
    private StoveRecipesSO[] cookingStoveRecipes;
    [SerializeField]
    //* burning Recipes from cooked to burned
    private StoveRecipesSO[] burningStoveRecipes;
    private StoveRecipesSO cookingStoveRecipe;
    private StoveRecipesSO burningStoveRecipe;
    //! we want to make a ref for any counter with progress bar so we mad the progress bar as a prefab
    //! then made each of them implemented same Interface IHasProgress
    public EventHandler<IHasProgress.OnCounterProgressEventArgs> OnCounterProgress { get; set; }
    //* we want to add event to update the visual object of stove which represents as a feedback to the gamer
    public EventHandler<OnStoveCounterFryingEventArgs> onStoveCounterFrying;
    public class OnStoveCounterFryingEventArgs : EventArgs{
        public State stoveCounterState;
    }
   public  enum State{ Idle, Frying, Fried, Burned}
    private State stoveState;
    private float fryingTimer;
    private float burningTimer;
    private void Start() {
        stoveState = State.Idle;
    }
    private void Update() {
        if (HasKitchenObjectInParent()) {
            switch (stoveState) {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;
                    //   currentStateStoveRecipe= GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                    OnCounterProgress?.Invoke(this, new IHasProgress.OnCounterProgressEventArgs { progressNormalized = (float)fryingTimer / cookingStoveRecipe.friedProgressMax });
                    if (fryingTimer > cookingStoveRecipe.friedProgressMax) {
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(cookingStoveRecipe.output,this);
                        stoveState =State.Fried;
                        onStoveCounterFrying!.Invoke(this,new OnStoveCounterFryingEventArgs { stoveCounterState=stoveState});
                    }
                    break;
                case State.Fried:
                    fryingTimer = 0;
                    burningTimer += Time.deltaTime;
                burningStoveRecipe = GetStoveRecipe(GetKitchenObject().GetKitchenObjectSO(),burningStoveRecipes);
                    OnCounterProgress?.Invoke(this, new IHasProgress.OnCounterProgressEventArgs { progressNormalized = (float)burningTimer / burningStoveRecipe.friedProgressMax });
                    if (burningTimer > burningStoveRecipe.friedProgressMax) { 
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(burningStoveRecipe.output,this);
                        stoveState =State.Burned;
                        onStoveCounterFrying!.Invoke(this,new OnStoveCounterFryingEventArgs { stoveCounterState=stoveState});
                    }

                    break;
                case State.Burned:
                    OnCounterProgress?.Invoke(this, new IHasProgress.OnCounterProgressEventArgs { progressNormalized = 0 });
                    break;
             }
        }
    }
    public override void Interact(Player player) {
        if (!HasKitchenObjectInParent() && player.HasKitchenObjectInParent()) {
            //! we need to insure that the player has something and is Uncooked to put it on the stove counter
            if (HasStoveRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO(), cookingStoveRecipes)) {
                player.GetKitchenObject().SetKitchenObjectParent(this);
                cookingStoveRecipe = GetStoveRecipe(GetKitchenObject().GetKitchenObjectSO(),cookingStoveRecipes);
            }
            else if (HasStoveRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO(), burningStoveRecipes)) { 
                player.GetKitchenObject().SetKitchenObjectParent(this);
                burningStoveRecipe = GetStoveRecipe(GetKitchenObject().GetKitchenObjectSO(),burningStoveRecipes);
            }
            else Debug.Log("attempts to put non StoveRecipesSO.input (KitchenObjectsSO) ");
        }
        else if (HasKitchenObjectInParent() && !player.HasKitchenObjectInParent()) {
            GetKitchenObject().SetKitchenObjectParent(player);
            stoveState = State.Idle;
            onStoveCounterFrying!.Invoke(this,new OnStoveCounterFryingEventArgs { stoveCounterState=stoveState});
            OnCounterProgress?.Invoke(this, new IHasProgress.OnCounterProgressEventArgs { progressNormalized = 0 });
            fryingTimer = 0;
            burningTimer = 0;
        }
        else Debug.Log("No Element To Pick Up Or Drop");
        } 
    public override void InteractAlternate(Player player) {
            //! to avoid attempting to fry a burned Meat or other KitchenObjectSO
        if (HasKitchenObjectInParent()) {
            //! since we can overcook a cooked meat or we can cook an Uncooked meat
            // currentStateStoveRecipe = GetStoveRecipe(GetKitchenObject().GetKitchenObjectSO());
            if (HasStoveRecipeWithInput(GetKitchenObject().GetKitchenObjectSO(), cookingStoveRecipes)) {
                stoveState = State.Frying;
                fryingTimer = 0;
                OnCounterProgress?.Invoke(this, new IHasProgress.OnCounterProgressEventArgs { progressNormalized = fryingTimer });
            }
            else {
                stoveState = State.Fried; burningTimer = 0;
                OnCounterProgress?.Invoke(this, new IHasProgress.OnCounterProgressEventArgs { progressNormalized = burningTimer });
            
            }

                onStoveCounterFrying!.Invoke(this, new OnStoveCounterFryingEventArgs { stoveCounterState = stoveState });
        }
        else {
            Debug.Log("No Element To InteractAlternate");
        }
    }
    public bool HasStoveRecipeWithInput(KitchenObjectsSO kitchenObjectSO, StoveRecipesSO[] stoveRecipes ) {
        foreach (StoveRecipesSO cookingRecipe in stoveRecipes) {
            if (cookingRecipe.input == kitchenObjectSO) {
                return true;
            }
        }
        return false;
    }

    public StoveRecipesSO GetStoveRecipe(KitchenObjectsSO kitchenObjectSO, StoveRecipesSO[] stoveRecipes) {
        foreach (StoveRecipesSO cookedStoveRecipe in stoveRecipes) {
            if (cookedStoveRecipe.input == kitchenObjectSO) {
                return cookedStoveRecipe;
            }
        }
        return null;
    }

    public KitchenObjectsSO GetOutputForInput(KitchenObjectsSO kitchenObjectSO,StoveRecipesSO[] stoveRecipes) {
        if (HasStoveRecipeWithInput(kitchenObjectSO,stoveRecipes)) {
            return GetStoveRecipe(kitchenObjectSO,stoveRecipes).output;
        }
        return null;
    }
}
