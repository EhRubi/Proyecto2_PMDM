using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{

    private float speed;
    private float targetX;
    private bool movingRight = false;

    [SerializeField] private GameObject life;

    private BossFightManager bm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.position = new Vector3(5.74f, -1.94f, 0);
        bm = BossFightManager.GetInstance();

        // Iniciar el ciclo de movimiento del jefe
        StartCoroutine(MoveBoss());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveBoss()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio entre 4 y 7 segundos antes de moverse
            float waitTime = Random.Range(4f, 7f);
            yield return new WaitForSeconds(waitTime);

            // Definir la dirección del movimiento
            if (movingRight)
            {
                targetX = 5.74f;
                if (gameObject.transform.position == new Vector3(targetX, -1.94f, 0)){
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                targetX = -5.74f;
                if (gameObject.transform.position == new Vector3(targetX, -1.94f, 0)){
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }

            // Seleccionar una velocidad aleatoria entre 1 y 5
            speed = Random.Range(5f, 10f);

            // Mover el jefe hacia el objetivo
            while (Mathf.Abs(transform.position.x - targetX) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
                yield return null;
            }

            // Cambiar de dirección
            movingRight = !movingRight;
        }
    }

    IEnumerator DestroyAfterSound()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play(); // Reproduce el sonido antes de destruir

        yield return new WaitForSeconds(audio.clip.length); // Espera a que termine el sonido
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shoot"))
        {
            life.transform.localScale = new Vector3(life.transform.localScale.x - 1f, life.transform.localScale.y, life.transform.localScale.z);
            StartCoroutine(DestroyAfterSound());
            Destroy(collision.gameObject);
            if (life.transform.localScale.x <= 0f)
            {
                bm.Win();
                Destroy(life);
            }
        }
    }
}
