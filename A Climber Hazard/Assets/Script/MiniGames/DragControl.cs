using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private bool isDragActive;
    private Vector2 _ScreenPos;
    private Vector3 worldPos;
    private Draggable _lastDrag;

    private void Awake()
    {
        DragControl[] controllers = FindObjectsOfType<DragControl>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(isDragActive && (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Drop();
            return;
        }
        
        if(Input.touchCount > 0)
        {
            
            _ScreenPos = Input.GetTouch(0).position;

        }
        else
        {
            return;
        }

        worldPos = Camera.main.ScreenToWorldPoint(_ScreenPos);

        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    _lastDrag = draggable;
                    InitDrag();
                }
            }

        }

    }

    public void InitDrag()
    {
        isDragActive = true;
    }

    public void Drag()
    {
        _lastDrag.transform.position = new Vector2(worldPos.x, worldPos.y);
    }

    public void Drop()
    {
        isDragActive = false;
        
    }


}
