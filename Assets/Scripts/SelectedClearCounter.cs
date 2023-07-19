using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedClearCounter : MonoBehaviour
{
    private ClearCounter clearCounter;
    [SerializeField]
    private GameObject selectedCounterVisual;

    private void Start() {
        Player.Instance.OnSelectedClearCounterChanged += Player_onSelectedClearCounterChanged;
        clearCounter = GetComponentInParent<ClearCounter>();
        
    }

    private void Player_onSelectedClearCounterChanged(object sender, Player.OnSelectedClearCounterChangedEventArgs e) {
        if (e.selectedClearCounter == clearCounter) {
            Show();
        }
        else Hide();
    }
    private void Show() {

        selectedCounterVisual.SetActive(true);
    }
    private void Hide() {

        selectedCounterVisual.SetActive(false);
    }
}
