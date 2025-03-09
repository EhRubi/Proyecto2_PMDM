using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFightManager : MonoBehaviour
{
    static BossFightManager instance;

    public static BossFightManager GetInstance(){
        return instance;
    }

    const int LIVES = 3;
    [SerializeField] GameObject[] imgLives;

    [SerializeField] private GameObject bossLife;
    int lives = LIVES;

    private void OnGUI(){
        for (int i = 0; i < imgLives.Length; i++)
        {
            imgLives[i].SetActive(i<lives);
        }
    }

    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void UpdateLives(int l){
        lives += l;
        if (lives <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void Win(){
        if (bossLife.transform.localScale.x <= 0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("WinScene");
        }
    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
