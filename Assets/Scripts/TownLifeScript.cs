using UnityEngine;
using UnityEngine.SceneManagement;

public class TownLifeScript : MonoBehaviour
{
    GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

        public void UpdateTownLife(){
        if (gameObject.transform.localScale.x <=0 ){
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
