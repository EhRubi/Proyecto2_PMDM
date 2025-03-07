using UnityEngine;

public class LimitController : MonoBehaviour
{
    [SerializeField] private GameObject life;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            life.transform.localScale = new Vector3(life.transform.localScale.x - 1f, life.transform.localScale.y, life.transform.localScale.z);
        }
        Debug.Log("Trigger detecta: " + collision.gameObject.name);
    }
}
