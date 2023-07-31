using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    // Start is called before the first frame update
    private StoveCounter stoveCounter;
    [SerializeField]
    private GameObject stoveParticles, stoveVisual;
    void Start()
    {
        stoveCounter = gameObject.GetComponentInParent<StoveCounter>();
        stoveCounter.onStoveCounterFrying += StoveCounter_onStoveCounterFrying;
        
    }
    private void StoveCounter_onStoveCounterFrying(object sender,StoveCounter.OnStoveCounterFryingEventArgs e) {
        if (e.stoveCounterState == StoveCounter.State.Frying || e.stoveCounterState == StoveCounter.State.Fried) {
            Show();
        }
        else Hide();
    }
    private void Show() { 
    stoveVisual.SetActive(true);
    stoveParticles.SetActive(true);
    }
    private void Hide() { 
    stoveVisual.SetActive(false);
    stoveParticles.SetActive(false);
    }
}
