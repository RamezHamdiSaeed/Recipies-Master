using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static IHasProgress;

public class ProgressBar : MonoBehaviour{
    [SerializeField]
    //! we cannot make a reference to assign value by the editor if it is an interface
    //private IHasProgress counter;
    private GameObject counter;
    private IHasProgress counterWithProgress;
    [SerializeField]
    private GameObject[] progressBarAndBackground;
    //! now the progress bar can be attached to any counter implements IHasProgress
    private Image progressBar;


    private void Counter_onCounterProgress(object sender, IHasProgress.OnCounterProgressEventArgs e) {
        progressBar.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0 || e.progressNormalized ==1) {
             Hide();
        }
            else Show();
    }
    private void Awake() {
        if (!counter.TryGetComponent<IHasProgress>(out counterWithProgress)) { Debug.LogError("the assigned Game Object : "+counterWithProgress+"not an Object Implements IHasProgress"); }
        
        progressBar = progressBarAndBackground[1].GetComponent<Image>();
        progressBar.fillAmount = 0;
        Hide();

    }
    void Start() {
       counterWithProgress.OnCounterProgress += Counter_onCounterProgress;
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
