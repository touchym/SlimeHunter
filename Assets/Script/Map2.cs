using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;
    PlayerControl player;
    public Text needAkey;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        needAkey.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player.key == 3)
            {
             SceneManager.LoadScene(3);
             gm.lastCheckpoint = new Vector2(92.4f, -6);
            // gm.lastCheckpoint = transform.position;
            //player.transform.position = new Vector2(92.4f, -6);
            }
            else
            {
                needAkey.text = "Need 3 Key";
            }
          
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        needAkey.text = "";
    }
}
