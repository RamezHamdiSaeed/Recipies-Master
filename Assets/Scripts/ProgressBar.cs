using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    [SerializeField]
    private GameObject[] progressBarAndBackground;
    private CuttingCounter cuttingCounter;
    private Image progressBar;

    private void CuttingCounter_onCuttingCounterProgress(object sender, CuttingCounter.OnCuttingCounterProgressEventArgs e) {
        progressBar.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0 || e.progressNormalized ==1) {
             Hide();
        }
            else Show();
    }
    private void Awake() {
        cuttingCounter = GetComponentInParent<CuttingCounter>();
        progressBar = progressBarAndBackground[1].GetComponent<Image>();
        progressBar.fillAmount = 0;
        Hide();

    }
    void Start() {
        cuttingCounter.onCuttingCounterProgress += CuttingCounter_onCuttingCounterProgress;
    }

    public void Show() {
        foreach (GameObject gameObject in progressBarAndBackground) {
            gameObject.SetActive(true);
        }
    }
    public void Hide() {
        foreach (GameObject gameObject in progressBarAndBackground) {
            gameObject.SetActive(false);
        }
    }
}
