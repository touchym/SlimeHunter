using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerControl player;
    GameManager gm;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //transform.position = gm.lastCheckpoint;
            //player.health = 0;
            SoundManager.Playsound("die");
            StartCoroutine(waitz());
            
            
        }
        IEnumerator waitz()
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(2);
        }
    }
}
