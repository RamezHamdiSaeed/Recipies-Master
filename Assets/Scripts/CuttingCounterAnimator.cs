using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterAnimator : MonoBehaviour
{
    private CuttingCounter cuttingCounter;
    private const string CUT = "Cut";
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Start() {
        cuttingCounter= GetComponentInParent<CuttingCounter>();
        cuttingCounter.onCuttingCounterInteract += CuttingCounter_onCuttingCounterInteract;
        
    }

    private void CuttingCounter_onCuttingCounterInteract(object sender, System.EventArgs e) {
        animator.SetTrigger(CUT);
    }
}
