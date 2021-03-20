using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public Vector2 lastCheckpoint;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("gameanager is null");
            }
            return _instance;
        }
    }
    public PlayerControl Player { get; private set; }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
       
        
        if (_instance == null)
        {
             _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
