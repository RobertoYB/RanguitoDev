using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerDeJuego : MonoBehaviour
{
    public void StartGame()
    {
        PlayerController.health = 3;
        SceneManager.LoadScene("NIVEL");
    }
}

