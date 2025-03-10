using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    Rigidbody rb;
    // Referencia al prefab del disparo
    [SerializeField] GameObject shootPrefab;

    // Distancia desde el centro de la nave hasta la posición donde se creará el disparo
    private float shootOffset = 1f;
    private float verticalOffset = 0.5f;

    [SerializeField] private float fireRate = 0.5f; // Tiempo entre disparos (1 segundo)
    private float secondShotDelay = 0.1f; // Pequeño delay entre los dos disparos
    private int shotCount = 0; // Contador de disparos

    private float nextFireTime = 0f;
    // Variable para determinar si la nave está activa y puede disparar
    bool active = true;

    BossFightManager bm;

    GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(-3.34f, -3.09f, 0);
        bm = BossFightManager.GetInstance();
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento izquierdo
        if (Input.GetKey("a") && transform.position.x >= -3.35f)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(-6.781723f, 6.49313f, 1);
        }

        //Movimiento derecho
        if (Input.GetKey("d") && transform.position.x <= 3.82f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(6.781723f, 6.49313f, 1);
        }

        //movimiento hacia arriba
        if (Input.GetKey("w") && transform.position.y <= -2.69f)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        //movimiento hacia abajo
        if (Input.GetKey("s") && transform.position.y >= -3.98f)
        {
            transform.position += -transform.up * speed * Time.deltaTime;
        }

        // DISPARO DOBLE
        if (active && Input.GetKeyDown(KeyCode.RightArrow) && Time.time >= nextFireTime)
        {
            if (shotCount == 0)
            {
                StartCoroutine(Sound());
                Shoot();
                shotCount = 1;
                nextFireTime = Time.time + secondShotDelay; // Pequeño delay antes del segundo disparo
            }
            else if (shotCount == 1 && Time.time >= nextFireTime)
            {
                StartCoroutine(Sound());
                Shoot();
                shotCount = 0; // Reinicia el contador de disparos
                nextFireTime = Time.time + fireRate; // Aplica cooldown después del segundo disparo
            }
        }
        
        if (SceneManager.GetActiveScene().name == "BossScene")
        {
            if (active && Input.GetKeyDown(KeyCode.LeftArrow) && Time.time >= nextFireTime)
        {
            if (shotCount == 0)
            {
                StartCoroutine(Sound());
                ShootLeft();
                shotCount = 1;
                nextFireTime = Time.time + secondShotDelay; // Pequeño delay antes del segundo disparo
            }
            else if (shotCount == 1 && Time.time >= nextFireTime)
            {
                StartCoroutine(Sound());
                ShootLeft();
                shotCount = 0; // Reinicia el contador de disparos
                nextFireTime = Time.time + fireRate; // Aplica cooldown después del segundo disparo
            }
        }
        }
    }
    IEnumerator Sound()
    {
        AudioSource audio1 = gameObject.GetComponent<AudioSource>();
        audio1.Play(); // Reproduce el sonido antes de destruir

        yield return new WaitForSeconds(audio1.clip.length); // Espera a que termine el sonido
        
    }


    void Shoot()
    {
        Vector3 shootPosition = transform.position + Vector3.right * shootOffset + Vector3.up * verticalOffset;
        Instantiate(shootPrefab, shootPosition, Quaternion.identity);
    }

    void ShootLeft()
    {
        float extraHeight = 0.5f; // Ajusta este valor para que salga más arriba
        Vector3 shootPosition = transform.position + Vector3.left * shootOffset + Vector3.up * (verticalOffset + extraHeight);
        GameObject projectile = Instantiate(shootPrefab, shootPosition, Quaternion.Euler(0, 0, 180)); // Rotar 180° en Z
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemy"))
        {
            if (SceneManager.GetActiveScene().name == "BossScene")
            {
                bm.UpdateLives(-1);
            }else if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                gm.UpdateLives(-1);
            }
        }
    }
}
