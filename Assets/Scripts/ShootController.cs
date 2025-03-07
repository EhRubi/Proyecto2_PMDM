using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    // Velocidad de los disparos
    [SerializeField] float speed;
    // Tiempo que duran los disparos antes de autodestruirse
    [SerializeField] float lifetime;

    void Start()
    {
        // Destruir el disparo después de un cierto tiempo
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mover el disparo hacia la derecha
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // Método para destruir el disparo cuando sale de la pantalla
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnBecameVisible()
    {
        StartCoroutine(Sound());
    }

    IEnumerator Sound()
    {
        AudioSource audio1 = gameObject.GetComponent<AudioSource>();
        audio1.Play(); // Reproduce el sonido antes de destruir

        yield return new WaitForSeconds(audio1.clip.length); // Espera a que termine el sonido
        
    }
}
