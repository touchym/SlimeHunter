using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlus : MonoBehaviour
{
    PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.health == 5)
            {
                Destroy(gameObject);
                SoundManager.Playsound("hp");
            }
            else
            {
                SoundManager.Playsound("hp");
                player.health++;
            UIManager.Instance.UpdateLife(player.health);
            Destroy(gameObject);
            }
                
        }
    }
}
