using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float BackgroundSpeed;
    public Renderer backgroundRenderer;
    MoveByTouch moveByTouch;

    // Update is called once per frame
    void Update()
    {
        moveByTouch = GetComponentInParent<MoveByTouch>();
        backgroundRenderer.material.mainTextureOffset += new Vector2(0f, BackgroundSpeed* moveByTouch.Arah * Time.deltaTime);
    }


}
