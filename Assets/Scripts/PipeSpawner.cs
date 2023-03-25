using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float time = 2f;
    public GameObject pipes;
    public float height;
    public Bird bird;
   

    void Start()
    {
        StartCoroutine(SpawnPipes(time));
        
    }

    IEnumerator SpawnPipes(float time)
    {
        while (!bird.isDead)
        {
            Instantiate(pipes, new Vector3(gameObject.transform.position.x, (1.345f - Random.Range(-height, height))), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
    
}
