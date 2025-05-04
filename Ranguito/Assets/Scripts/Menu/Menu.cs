using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar (asegúrate de que está en Build Settings)
    public string NIVEL;

    // Método que se llama cuando se hace clic en el botón
    public void CambiarAEscena()
    {
        // Carga la nueva escena
        SceneManager.LoadScene(NIVEL);
    }
}