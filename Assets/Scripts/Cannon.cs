using System;
using DefaultNamespace;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cameraSpot;
    
    [SerializeField] private Transform mainConstruction;
    [SerializeField] private Transform cannonPipe;

    private CannonCameraSpot _cannonCameraSpot;
    private CannonMovement _cannonMovement;

    private void Start()
    {
        _cannonCameraSpot = new CannonCameraSpot(Camera.main, cameraSpot, mainConstruction);
        _cannonMovement = new CannonMovement(mainConstruction, cannonPipe);
    }

    private void Update()
    {
        _cannonCameraSpot.SetCannonCamera();
        _cannonMovement.MoveCannon();
    }
}
