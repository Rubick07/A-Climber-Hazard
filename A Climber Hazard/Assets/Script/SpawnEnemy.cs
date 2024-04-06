using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float enemySpeed;
    public float TimeBetweenSpawn;
    public float TimeDestroy;
    private float SpawnTime;

    void Update()
    {
        if(Time.time >= SpawnTime)
        {
            Spawn();
            SpawnTime = Time.time + TimeBetweenSpawn;
        }
    }

    public void Spawn()
    {
        float RandomX = Random.Range(minX, maxX);
        float RandomY = Random.Range(minY, maxY);

       GameObject Enemies =  Instantiate(Enemy, transform.position + new Vector3(RandomX, RandomY, 0), transform.rotation);
        //Enemies.transform.SetParent(transform);
        Rigidbody2D  rbEnemy= Enemies.GetComponent<Rigidbody2D>();
        rbEnemy.velocity = new Vector2(enemySpeed, 0f);
        Destroy(Enemies, TimeDestroy);
    }


}
