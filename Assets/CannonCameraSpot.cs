using UnityEngine;

public class CannonCameraSpot
{
    private readonly Camera _cam;
    private readonly Transform _camSpot;

    public CannonCameraSpot(Camera cam, Transform cameraSpot)
    {
        _cam = cam;
        _camSpot = cameraSpot;
    }

    public void SetCannonCamera()
    {
        if (_cam != null) _cam.transform.position = _camSpot.position;
    }
}
