using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false; // Estado del juego

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Pausa o reanuda el juego
    }
}
