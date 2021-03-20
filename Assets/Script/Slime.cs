using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyAI,IDamageable
{
    public int Health { get; set; }

    //private PlayerControl playerCon;

 


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
    }
    


}
