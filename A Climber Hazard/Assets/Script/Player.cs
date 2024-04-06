using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManajer gameManajer = GetComponentInParent<GameManajer>();
            gameManajer.LoseGame();
            Destroy(gameObject);
        }
    }


}
