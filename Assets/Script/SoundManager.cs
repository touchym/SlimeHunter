using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jump, hit, checkp, die, select,shoot, slave, slimejump,hp;
    static AudioSource audioSrc;

    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        hit = Resources.Load<AudioClip>("hit");
        checkp = Resources.Load<AudioClip>("checkp");
        die = Resources.Load<AudioClip>("die");
        select = Resources.Load<AudioClip>("select");
        shoot = Resources.Load<AudioClip>("shoot");
        slave = Resources.Load<AudioClip>("slave");
        slimejump = Resources.Load<AudioClip>("slimejump");
     hp = Resources.Load<AudioClip>("hp"); 

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;

            case "hit":
                audioSrc.PlayOneShot(hit);
                break;

            case "checkp":
                audioSrc.PlayOneShot(checkp);
                break;

            case "die":
                audioSrc.PlayOneShot(die);
                break;

            case "select":
                audioSrc.PlayOneShot(select);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shoot);
                break;
            case "slave":
                audioSrc.PlayOneShot(slave);
                break;
            case "slimejump":
                audioSrc.PlayOneShot(slimejump);
                break;
            case "hp":
                audioSrc.PlayOneShot(hp);
                break;
        }
    }
}
