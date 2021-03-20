using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.lastCheckpoint = transform.position;
            SoundManager.Playsound("checkp");
        }
    }
}
