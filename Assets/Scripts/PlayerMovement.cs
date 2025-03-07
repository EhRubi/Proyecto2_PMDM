using UnityEngine;

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

    GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(-3.34f, -3.09f, 0);
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento izquierdo
        if (Input.GetKey("a") && transform.position.x >= -3.35f)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }

        //Movimiento derecho
        if (Input.GetKey("d") && transform.position.x <= 0.45f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
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
                Shoot();
                shotCount = 1;
                nextFireTime = Time.time + secondShotDelay; // Pequeño delay antes del segundo disparo
            }
            else if (shotCount == 1 && Time.time >= nextFireTime)
            {
                Shoot();
                shotCount = 0; // Reinicia el contador de disparos
                nextFireTime = Time.time + fireRate; // Aplica cooldown después del segundo disparo
            }
        }
    }

    void Shoot()
    {
        Vector3 shootPosition = transform.position + Vector3.right * shootOffset + Vector3.up * verticalOffset;
        Instantiate(shootPrefab, shootPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("enemy")){
            gm.UpdateLives(-1);
        }
    }
}
