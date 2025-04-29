using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar (aseg�rate de que est� en Build Settings)
    public string NIVEL;

    // M�todo que se llama cuando se hace clic en el bot�n
    public void CambiarAEscena()
    {
        // Carga la nueva escena
        SceneManager.LoadScene(NIVEL);
    }
}