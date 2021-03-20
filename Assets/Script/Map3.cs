using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Map3 : MonoBehaviour
{
    public Text needAkey;
    PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
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
            if (player.key == 1)
            {
                SceneManager.LoadScene(4);
            }
            else
            {
                needAkey.text = "Defeat A Boss And Get A Key";
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        needAkey.text = "";
    }
}