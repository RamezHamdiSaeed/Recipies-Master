using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField]
    private BaseCounter counter;
    [SerializeField]
    private GameObject[] selectedCounterVisuals;

    private void Start() {
        Player.Instance.OnSelectedClearCounterChanged += Player_onSelectedClearCounterChanged;
    }

    private void Player_onSelectedClearCounterChanged(object sender, Player.OnSelectedClearCounterChangedEventArgs e) {
        if (e.selectedCounter == counter) {
            Show();
        }
        else Hide();
    }
    private void Show() {
        foreach (GameObject gameObject in selectedCounterVisuals) {
            gameObject.SetActive(true);
        }
    }
    private void Hide() {
        foreach (GameObject gameObject in selectedCounterVisuals) {
            gameObject.SetActive(false);
        }
    }
}
