using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    public void ShakeCamera(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        var originalPosition = _cam.transform.localPosition;

        while (duration > 0)
        {
            var offsetX = Random.Range(-1f, 1f) * magnitude;
            var offsetY = Random.Range(-1f, 1f) * magnitude;

            _cam.transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);

            duration -= Time.deltaTime;
            yield return null;
        }

        _cam.transform.localPosition = originalPosition;
    }
}
