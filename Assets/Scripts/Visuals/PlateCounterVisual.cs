using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounterVisual : MonoBehaviour {
    [SerializeField]
    private PlateCounter plateCounter;
    [SerializeField]
    private Transform plateCounterTopPoint, plateVisualPrefab;
    //! we want to instantiate multiple plates over the spowned plates with offset in y axis
    private float plateOffsetY = .2f;
    private List<GameObject> plates;
    private void Awake() {
        plates = new List<GameObject>();
        plateCounter.onPlateRemoved += PlateCounter_onPlateRemoved;
        plateCounter.onPlateSpown += PlateCounter_onPlateSpown;
    }

    private void PlateCounter_onPlateSpown(object sender, System.EventArgs e) {
        Transform instantiatedPlate=Instantiate(plateVisualPrefab,plateCounterTopPoint);
        //! we want to add different offsets according to the same position of top point
        instantiatedPlate.localPosition=new Vector3(0,plateOffsetY*plates.Count,0);
        plates.Add(instantiatedPlate.gameObject);

    }

    private void PlateCounter_onPlateRemoved(object sender, System.EventArgs e) {
        GameObject willBeDistroyedPlate = plates[plates.Count - 1];
        plates.Remove(willBeDistroyedPlate);
        Destroy(willBeDistroyedPlate);
    }
}
