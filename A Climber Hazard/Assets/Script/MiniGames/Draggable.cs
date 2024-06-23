using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Vector3 StartPos;
    public SpriteRenderer WireEnd;
    public int number;
    public Vector2 StartSize;
    public Vector3 offset;
    public bool Benar;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.parent.position;
        StartSize = new Vector2(WireEnd.size.x, WireEnd.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
