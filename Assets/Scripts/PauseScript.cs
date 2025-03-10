using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false; // Estado del juego
    [SerializeField] private GameObject pauseMenu; // Referencia al menú de pausa

    void Start()
    {
        // Desactivar el menú de pausa al iniciar el juego
        pauseMenu.SetActive(false);
    }

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
        pauseMenu.SetActive(isPaused); // Muestra u oculta el menú de pausa
    }
}
