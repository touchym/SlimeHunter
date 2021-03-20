using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map1 : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;
    PlayerControl player;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();
       // player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(2);
            gm.lastCheckpoint = new Vector2(-19.7f, 0);
            
        }
        
    }
}
