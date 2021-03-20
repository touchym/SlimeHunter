using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPurpleSlime : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveDiect;
    public float bulletSpeed=5f;
    private PlayerControl PlayerCon;
    Animator anPlaycon;

    // Start is called before the first frame update
    void Start()
    {

        anPlaycon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();

        PlayerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        rb = GetComponent<Rigidbody2D>();
        moveDiect = (PlayerCon.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDiect.x, moveDiect.y);

        Destroy(gameObject, 3f);
       
    }

    // Update is called once per frame
    void Update()
    {
        

 
    }
  private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();

        if (hit != null)
        {
            hit.Damage();
            Destroy(gameObject);
            SoundManager.Playsound("hit");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
