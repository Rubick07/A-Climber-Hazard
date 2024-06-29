using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    Rigidbody2D rb;
    Touch touch;
    public float movespeed;
    public float Arah;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                if(touch.deltaPosition.y > 0)
                {
                    rb.velocity = Vector2.up * movespeed;
                    Arah = 1;
                }
                else if(touch.deltaPosition.y < 0)
                {
                    rb.velocity = -Vector2.up * movespeed;
                    Arah = -1;
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    Arah = 0;
                }
            }

            
        }
    }

    public void diam()
    {
        rb.velocity = Vector2.zero;
        Arah = 0;
    }
}
