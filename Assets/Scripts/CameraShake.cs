using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMPORTANTE:1  Meter la camara dentro de un gameObject con la posicion 0,0 para poder hacer el efecto
// 2 Anadir script a la camara
// 3 Invocar el metodo dentro del script que lo invoca 
// public CameraShake cameraShake;
// StartCoroutine(cameraShake.Shake(.15f, .4f));
// 4 Anadir Objeto al gameObject 


public class CameraShake : MonoBehaviour
{

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
