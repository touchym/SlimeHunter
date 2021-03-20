using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Vector2 moveDirect;
    float speed = 3;
    Vector2 startPos;
    public bool k = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        k = false;
    }

    // Update is called once per frame
    void Update()
    {
        //KeyFollow();
    }

    public void KeyFollow()
    {
        if (k == true)
        {
            PlayerControl player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        moveDirect = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirect.x, moveDirect.y);
        }
        if (k == false)
        {
            startPos = transform.position;
        }
        
        
    }
}
