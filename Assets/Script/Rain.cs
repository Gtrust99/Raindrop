using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject drop;
    public GameObject golden;
    private float spawnTimer = 0f;
    private float spawnInterval=1;
    public int goldentime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            Spawner();
            spawnTimer = 0f; // Reimposta il timer
            goldentime++;
            if(goldentime==5)
            {
                GoldenSpawn();
            }
            
        }

       

    }

    public void Spawner()
    {
        transform.position = new Vector2(Random.Range(-8, 9), 4);
        Instantiate(drop, transform.position, Quaternion.identity);
        drop.GetComponent<SpriteRenderer>().color = Color.cyan;
        spawnInterval = spawnInterval + 0.1f;
    }
    public void GoldenSpawn()
    {
        transform.position = new Vector2(Random.Range(-8, 9), 4);
        Instantiate(golden, transform.position, Quaternion.identity);
        spawnInterval = spawnInterval + 0.1f;
        goldentime = 0;
    }
    
}
