using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlateCounter : BaseCounter 
{   //! the numbered fields are default initialized by 0;
    public event EventHandler onPlateSpown;
    public event EventHandler onPlateRemoved;
    [SerializeField]
    private KitchenObjectsSO plateSO;
    private float spownPlatesTimer;
    private float spownPlatesTimerMax=4f;
    private int spownedPlates;
    private int spownedPlatesMax=5;
    private void Update() {
        spownPlatesTimer += Time.deltaTime;
        if (spownPlatesTimer > spownPlatesTimerMax) {
            spownPlatesTimer = 0;
            if (spownedPlates < spownedPlatesMax) {
                spownedPlates++;
                onPlateSpown?.Invoke(this,EventArgs.Empty);
            }
        }
    }
    public override void Interact(Player player) {
        if (!player.HasKitchenObjectInParent()) {
            if (spownedPlates > 0) {
                spownedPlates--;
                KitchenObject.SpawnKitchenObject(plateSO,player);
                onPlateRemoved?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}
