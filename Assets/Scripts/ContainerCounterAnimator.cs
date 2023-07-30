using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnimator : MonoBehaviour
{
    private ContainerCounter containerCounter;
    private const string OPEN_CLOSE = "OpenClose";
    private Animator animator;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Start() {
        containerCounter= GetComponentInParent<ContainerCounter>();
        containerCounter.onContainerCounterInteract += ContainerCounter_onContainerCounterInteract;
        
    }

    private void ContainerCounter_onContainerCounterInteract(object sender, System.EventArgs e) {
        animator.SetTrigger(OPEN_CLOSE);
    }
}
