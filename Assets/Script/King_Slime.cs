using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Slime : EnemyAI,IDamageable
{
    public int Health { get; set; }

    //private PlayerControl playerCon;

 public GameObject bulletPrefab;
    public Transform bulletPoint;
    public GameObject key;

    bool atk = true;
    bool bull = true;


    public void Damage()
    {
        Health = base.health;

        Debug.Log("damage");
        SoundManager.Playsound("hit");
        health--;

        if (health < 1)
        {
            SoundManager.Playsound("die");
            Destroy(gameObject);
            Instantiate(key, transform.position, Quaternion.identity);
            
        }
        else
        {
            if (moveRight == true)
            {
                    rb.velocity = new Vector2(-7, 2);
                an.SetTrigger("Hit");
            }
            if (moveRight == false)
            {
                rb.velocity = new Vector2(7, 2);
                an.SetTrigger("Hit");
            }

        }
    }
    public override void EnemyDetactPlayer()
    {
        base.EnemyDetactPlayer();

        if (distanceOBJ < distanceBull)
        {
                 if (atk == true)
                {
                    StartCoroutine(WaitAttck());
                    
                    atk = false;

                }
                if (bull == true)
                {
                    StartCoroutine(WaitBullet());
                    bull = false;
                }
        }

      
     
            
        


    }

    void addBullet()
    {
        float posX = bulletPoint.transform.position.x;
        float posY = bulletPoint.transform.position.y;
        Vector3 prefabPos = new Vector3(posX, posY, 0);

            Instantiate(bulletPrefab, prefabPos, Quaternion.identity);
            nextFire = Time.time + firerate;
        SoundManager.Playsound("shoot");




    }


    void SlimeAttack()
    {
        float disx = transform.position.x;
        float disy = transform.position.y;

        disy = player.transform.position.y;

        //float distance;
        //distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 pp =new Vector2(player.transform.position.x,disy+10f);
        transform.position = pp;
        SoundManager.Playsound("slimejump");

    }


    IEnumerator WaitAttck()
    {
        SlimeAttack();
        yield return new WaitForSeconds(5f);;
        atk = true;

    }
    IEnumerator WaitBullet()
    {
        addBullet();
        yield return new WaitForSeconds(0.5f);
        bull = true;
    }



}
