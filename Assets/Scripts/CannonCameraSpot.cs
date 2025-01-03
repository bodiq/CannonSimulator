using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CannonCameraSpot
{
    private readonly Camera _cam;
    private readonly Transform _camSpot;
    private readonly Transform _cannonConstruction;

    public float CameraYOffset = 90f;

    public CannonCameraSpot(Camera cam, Transform cameraSpot, Transform cannonConstruction)
    {
        _cam = cam;
        _camSpot = cameraSpot;
        _cannonConstruction = cannonConstruction;
    }

    public void SetCannonCamera()
    {
        if (_cam != null) _cam.transform.position = _camSpot.position;
        
        var targetRotation = new Vector3(0f, _cannonConstruction.eulerAngles.y + CameraYOffset, 0f);
        
        _cam.transform.rotation = Quaternion.Lerp(_cam.transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * 20f);
    }
}
