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

    [SerializeField] private GameObject townLife;

    int score;
    int lives = LIVES;

    private void OnGUI(){
        for (int i = 0; i < imgLives.Length; i++)
        {
            imgLives[i].SetActive(i<lives);
        }

        txtScore.text = string.Format("{0,2:D2}", score);
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
        if (score >= 5){
            Destroy(gameObject);
            SceneManager.LoadScene("WinScene");
        }
    }

    public void UpdateLives(int l){
        lives += l;
        if (lives <= 0){
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void UpdateTownLife(){
        if (townLife.transform.localScale.x <= 0f ){
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
