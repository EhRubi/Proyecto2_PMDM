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
    private float nextFireTime = 0f; // Momento en que se podrá disparar de nuevo
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

        // Comprobar si la nave está activa y se ha pulsado la tecla de disparo (barra espaciadora)
        if (active && Input.GetKeyDown(KeyCode.RightArrow) && Time.time >= nextFireTime)
{
        // Calcular la posición donde se creará el disparo (un poco por delante de la nave)
        Vector3 shootPosition = transform.position + Vector3.right * shootOffset + Vector3.up * verticalOffset;

        // Crear el disparo en la posición calculada y sin rotación
        Instantiate(shootPrefab, shootPosition, Quaternion.identity);

        // Actualizar el tiempo del próximo disparo
        nextFireTime = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("enemy")){
            gm.UpdateLives(-1);
        }
    }
}
