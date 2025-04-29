using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJon : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 6f;
    public Transform detectorSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rigidbody;
    private float movimientoHorizontal;
    private bool mirandoDerecha = true;
    private int saltosDisponibles = 2;
    private bool enSuelo;

    public Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        // Voltear sprite si cambia de dirección
        if (movimientoHorizontal > 0 && !mirandoDerecha)
        {
            Voltear();
        }
        else if (movimientoHorizontal < 0 && mirandoDerecha)
        {
            Voltear();
        }

        // Cambiar parámetro en el Animator
        animator.SetFloat("movimiento", Mathf.Abs(movimientoHorizontal)); // Usar movimientoHorizontal

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && saltosDisponibles > 0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f); // Reinicia la velocidad vertical
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltosDisponibles--;
        }
    }

    void FixedUpdate()
    {
        // Movimiento lateral
        rigidbody.velocity = new Vector2(movimientoHorizontal * velocidad, rigidbody.velocity.y);

        // Verificar si está tocando el suelo
        enSuelo = Physics2D.OverlapCircle(detectorSuelo.position, radioSuelo, capaSuelo);

        // Si está en el suelo, reiniciar saltos
        if (enSuelo)
        {
            saltosDisponibles = 2;
        }

        Debug.Log("Está en el suelo: " + enSuelo);
    }

    void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            saltosDisponibles = 2;
        }
    }
}
