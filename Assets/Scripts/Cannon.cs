using System;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cameraSpot;

    private CannonCameraSpot _cannonCameraSpot;

    private void Start()
    {
        _cannonCameraSpot = new CannonCameraSpot(Camera.main, cameraSpot);
    }

    private void Update()
    {
        _cannonCameraSpot.SetCannonCamera();
    }
}
