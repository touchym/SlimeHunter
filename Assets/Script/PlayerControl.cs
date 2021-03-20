using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerControl : MonoBehaviour,IDamageable
{
    Rigidbody2D rb;
    Animator an;

    public float runSpeed = 10f;
    public float jumpHeight = 8f;

    public bool isGround;
    public LayerMask groundMask;
    public float groundDistance;
    public Transform groundCheck;

    public float knockback;
    public float knockbackLenght;
    public float knockbackcount;
   public bool knockRight;

    public int Health { get; set; }
    public  int health;

    public int key;
    public GameObject keyObj;

    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponentInChildren<Animator>();
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();

        transform.position = gm.lastCheckpoint;

        
    }

    // Update is called once per frame
    void Update()
    {
        Conchar();

    }
    void Conchar()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,groundDistance, groundMask);

        /*  if (CrossPlatformInputManager.GetButton("Left"))
          {
              Vector3 movementHorizontal = new Vector3(-runSpeed*Time.deltaTime, 0, 0);
              transform.position += movementHorizontal;
          }
          if (CrossPlatformInputManager.GetButton("Right"))
          {
              Vector3 movementHorizontal = new Vector3(runSpeed * Time.deltaTime, 0, 0);
              transform.position += movementHorizontal;
          }*/
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 movementHorizontal = new Vector3(-runSpeed * Time.deltaTime, 0, 0);
            transform.position += movementHorizontal;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 movementHorizontal = new Vector3(runSpeed * Time.deltaTime, 0, 0);
            transform.position += movementHorizontal;
        }
        




         if (Input.GetKeyDown(KeyCode.Space)&&isGround)
        //if (CrossPlatformInputManager.GetButtonDown("Jump") && isGround)
        {
            SoundManager.Playsound("jump");
             rb.velocity = new Vector3(0, jumpHeight,0);        
        }
    }
    public void Damage()
    {
        if (health <= 1)
        {
            //KnockBackqq();
            //return;
            Debug.Log("die");
           SoundManager.Playsound("die");
            StartCoroutine(timez());
            
           
        }
        if (health > 0)
        {
            Debug.Log("playerDamage");
            KnockBackqq();
            an.SetTrigger("Hit");
            health--;
            UIManager.Instance.UpdateLife(health);
            SoundManager.Playsound("hit");


        }
      
    }

    public void KnockBackqq()
    {
        if (knockbackcount <= 0)
        {
            rb.velocity = new Vector2(20f, rb.velocity.y);
        }
        else
        {
            if (knockRight)
                rb.velocity = new Vector2(-knockback, knockback);
            if (!knockRight)
                rb.velocity = new Vector2(knockback, knockback);
            knockbackcount -= Time.deltaTime;
        }
    }

    IEnumerator timez()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("key"))
        {
            key++;
            SoundManager.Playsound("hp");
            Key keyz = GameObject.FindGameObjectWithTag("key").GetComponent<Key>();
            
                 Destroy(other.gameObject);
            UIManager.Instance.UpdateKey(key);

           
        }
    }


}
