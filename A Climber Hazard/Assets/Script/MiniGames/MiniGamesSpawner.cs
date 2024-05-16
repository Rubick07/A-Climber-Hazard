using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesSpawner : MonoBehaviour
{
    public GameObject MinigamesButton;
    public float maxX;
    public float minX;
    public float posY;


    public void Spawn()
    {
        float RandomX = Random.Range(0,2);
        if(RandomX == 0)
        {
            RandomX = minX;
        }
        else
        {
            RandomX = maxX;
        }

        GameObject Enemies = Instantiate(MinigamesButton, transform.position + new Vector3(RandomX, posY, 0), transform.rotation);
        //Enemies.transform.SetParent(transform);
        
    }
}
