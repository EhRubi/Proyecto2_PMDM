using NUnit.Framework;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed;

    GameManager gm;
    const float DESTROY_WIDTH = -7.08f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1f, 10f); // Asigna un valor aleatorio a la velocidad
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= DESTROY_WIDTH){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")){
            // Ignorar la colisión entre los dos enemigos
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }       
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("shoot")){
            gm.UpdateScore(1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
