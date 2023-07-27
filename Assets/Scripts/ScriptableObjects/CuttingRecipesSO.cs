using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class CuttingRecipesSO : ScriptableObject
{
    public KitchenObjectsSO input;
    public KitchenObjectsSO output;
    public int cuttingProgressMax;
}
