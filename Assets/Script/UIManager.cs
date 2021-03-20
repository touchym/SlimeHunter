using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UImanager is NULL!!");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;

        key[0].enabled = false;
        key[1].enabled = false;
        key[2].enabled = false;
    }

    public Image[] healBars;
    public Image[] key;


    public void UpdateLife(int lifeRemaining)
    {
        for (int i = 0; i <= lifeRemaining; i++)
        {
            if (i == lifeRemaining)
            {
                healBars[i].enabled = false;
            }
            if (i != lifeRemaining)
            {
                healBars[i].enabled = true;

            }
            else return;

        }
    }
    public void UpdateKey(int keyremaining)
    {
        if (keyremaining == 1)
        {
            key[0].enabled = true;
        }
        if (keyremaining == 2)
        {
            key[1].enabled = true;
        }
        if (keyremaining == 3)
        {
            key[2].enabled = true;
        }

    }
}
