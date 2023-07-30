using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress
{
    public EventHandler<OnCounterProgressEventArgs> OnCounterProgress{ get;set; }
    public class OnCounterProgressEventArgs : EventArgs {
        public float progressNormalized;
    }
}
