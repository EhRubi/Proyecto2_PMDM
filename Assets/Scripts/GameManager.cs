using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static GameManager instance;

    public static GameManager GetInstance(){
        return instance;
    }

    const int LIVES = 3;

    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] GameObject[] imgLives;

    int score;
    int lives = LIVES;

    private void OnGUI(){
        for (int i = 0; i < imgLives.Length; i++)
        {
            imgLives[i].SetActive(i<lives);
        }

        txtScore.text = string.Format("{0,3:D3}", score);
    }

    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int p){
        score += p;
    }

    public void UpdateLives(int l){
        lives += l;
        if (lives <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
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
