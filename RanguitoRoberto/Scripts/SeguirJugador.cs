using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform objetivo; // Tu personaje
    public Vector3 offset; // Separación deseada (opcional)
    public float suavizado = 0.125f;

    void LateUpdate()
    {
        if (objetivo != null)
        {
            Vector3 posicionDeseada = objetivo.position + offset;
            Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
            transform.position = new Vector3(posicionSuavizada.x, posicionSuavizada.y, transform.position.z); // Mantiene z fijo
        }
    }
}