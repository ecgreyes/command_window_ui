using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector2 moveDelta;
    private RaycastHit2D hit;
    public float scaleTime = 5.0f;
    private bool isActive = false;
    public bool movementHorizontal= false;
    public bool movementVertical = false; 
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector2(x, y);

        if (moveDelta.x > 0)
            transform.localScale = Vector2.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector2(-1, 1);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
      

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Time.timeScale = scaleTime;
        }
        else if ((Input.GetKeyDown(KeyCode.KeypadMinus)))
        {
            scaleTime = 1.0f;
            Time.timeScale = scaleTime;
        }
    }
}