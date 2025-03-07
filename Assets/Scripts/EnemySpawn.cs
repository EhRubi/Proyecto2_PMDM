using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    const float MAX_Y = -2.79f;
    const float MIN_Y = -3.99f;

    [SerializeField] float interval;
    [SerializeField] float delay;
    [SerializeField] GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("EnemySpawner");
    }

    IEnumerator EnemySpawner(){
        yield return new WaitForSeconds(delay);
        while (true){
            Vector3 position = new Vector3(transform.position.x, Random.Range(MIN_Y, MAX_Y), 0);
            Instantiate(enemyPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
