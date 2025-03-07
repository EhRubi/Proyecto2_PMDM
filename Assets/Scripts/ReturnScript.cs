using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "GameOverScene" || SceneManager.GetActiveScene().name == "WinScene") && Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("SampleScene");
        }else if ((SceneManager.GetActiveScene().name == "GameOverScene" || SceneManager.GetActiveScene().name == "WinScene") && Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("StartScene");
        }
    }
}
