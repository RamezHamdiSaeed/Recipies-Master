using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted
    }
    [SerializeField] private Mode mode;
    //! will run after every game object in the scene have been updated
    private void LateUpdate() {
        //! we usually use LateUpdate for dynamic Canvas i.e we need to make the progress bar
        switch (mode) { 
            case Mode.LookAt:
            //! face forward the camera main point (center point) so the progress bar will rotate around y axis and z axis
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
            //! face forward the camera main point (center point) but after get the position of the camera like the camera has been rotated 180 degrees around the progress bar so the progress bar will rotate around y axis and z axis with mirroring
                Vector3 dirFromCamera = transform.position - Camera.main.transform.forward;
                transform.LookAt(dirFromCamera+dirFromCamera);
                break;
            case Mode.CameraForward:
            //! face forward the camera so the progress bar will rotate around y axis 
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraForwardInverted:
            //! face forward the camera so the progress bar will rotate around y axis  with mirroring
                transform.forward= -Camera.main.transform.forward;
                break;

        }
    }
}
