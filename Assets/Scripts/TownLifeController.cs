using Unity.VisualScripting;
using UnityEngine;

public class TownLifeController : MonoBehaviour
{
    [SerializeField] private GameObject life;

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


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")){
            life.transform.localScale = new Vector3(life.transform.localScale.x - 1f, life.transform.localScale.y, life.transform.localScale.z);
            if (life.transform.localScale.x <= 0f)
            {
                gm.GameOver();
                Destroy(life);
            }
        }
    }
}
