using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private bool isDragActive;
    private Vector2 _ScreenPos;
    private Vector3 worldPos;
    private Draggable _lastDrag;
    public LayerMask CableLayer;
    public Draggable[] kabels;

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
                if(draggable != null && draggable.enabled == true)
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
        //UpdateRotation
        Vector3 Direction = _lastDrag.transform.position - _lastDrag.StartPos;
        _lastDrag.transform.right = Direction;

        float dist = Vector2.Distance(_lastDrag.StartPos, _lastDrag.transform.position);
        _lastDrag.WireEnd.size = new Vector2(dist, _lastDrag.WireEnd.size.y);
    }

    public void Drop()
    {
        isDragActive = false;
        Collider2D[] Wireright = Physics2D.OverlapCircleAll(_lastDrag.transform.position, 0.1f, CableLayer);

        foreach(Collider2D Wire in Wireright)
        {
            if(Wire.gameObject != _lastDrag.gameObject)
            {
                Debug.Log(Wire.gameObject);
                Draggable Kanan = Wire.GetComponent<Draggable>();
                if (_lastDrag.number == Kanan.number)
                {
                    Debug.Log(_lastDrag.number);
                    Debug.Log(Kanan.number);
                    _lastDrag.Benar = true;
                    Vector3 Direction = _lastDrag.transform.position - Wire.transform.position;
                    _lastDrag.transform.position = Wire.transform.position;
                    // _lastDrag.transform.right = Vector3.zero;
                    transform.right = Direction;

                    float dist = Vector2.Distance(_lastDrag.StartPos, Wire.transform.position);
                    _lastDrag.WireEnd.size = new Vector2(dist, _lastDrag.WireEnd.size.y);
                    check();
                    return;
                }
                    
                
            }

        }
        Debug.Log("salah");
        _lastDrag.transform.position = _lastDrag.StartPos + _lastDrag.offset;
        _lastDrag.WireEnd.size = new Vector2(_lastDrag.StartSize.x, _lastDrag.StartSize.y);
        _lastDrag.transform.right = Vector3.zero;
    }


    public void check()
    {
        int benar = 0;
        foreach(Draggable kabel in kabels)
        {
            if(kabel.Benar == true)
            {
                benar++;
            }

        }

        if(benar == kabels.Length)
        {
            Debug.Log("menang");
            FindAnyObjectByType<MiniGames>().WinGames();
        }

    }
}
