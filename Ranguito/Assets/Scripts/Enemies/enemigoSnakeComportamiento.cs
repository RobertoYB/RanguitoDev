using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoSnakeComportamiento : MonoBehaviour
{

    public float speed;
    public bool esDerecha;
    public float contadorTiempo;
    public float tiempoDeCambio;

    void Start()
    {
        contadorTiempo = tiempoDeCambio; 
    }

    
    void Update()
    {
        if (esDerecha == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(-6, 6, 1);
        }

        if (esDerecha == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(6, 6, 1);
        }

        contadorTiempo -= Time.deltaTime;

        if(contadorTiempo <= 0)
        {
            contadorTiempo = tiempoDeCambio;
            esDerecha = !esDerecha;
        }
    }
}
