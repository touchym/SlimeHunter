using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_Slime : EnemyAI,IDamageable
{
    public int Health { get; set; }

    //private PlayerControl playerCon;

    public GameObject bulletPrefab;
    public Transform bulletPoint;

    


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
            
        }
        else
        {
            if (moveRight == true)
            {
                    rb.velocity = new Vector2(-15, 2);
                an.SetTrigger("Hit");
            }
            if (moveRight == false)
            {
                rb.velocity = new Vector2(15, 2);
                an.SetTrigger("Hit");
            }

        }
    }
    public override void EnemyDetactPlayer()
    {
        base.EnemyDetactPlayer();

        if (distanceOBJ < distanceBull)
        {
            addBullet();
        }

    }
    
    void addBullet()
    {
        float posX = bulletPoint.transform.position.x;
        float posY = bulletPoint.transform.position.y;
        Vector3 prefabPos = new Vector3(posX, posY, 0);

        if (Time.time > nextFire)
        {
                Instantiate(bulletPrefab, prefabPos, Quaternion.identity);
            nextFire = Time.time + firerate;
            SoundManager.Playsound("shoot");

        }
        
    }
   
}
