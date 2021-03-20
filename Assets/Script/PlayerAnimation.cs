using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAnimation : MonoBehaviour
{
    Animator an;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimRun();
        RotateChar();
        AnimJump();
        AnimAttack();


    }

    private void RotateChar()
    {
       /* if (CrossPlatformInputManager.GetButton("Left"))
        {
            an.transform.localScale = new Vector3(-1, 1, 1);

        }
        if (CrossPlatformInputManager.GetButton("Right"))
        {
            an.transform.localScale = new Vector3(1, 1, 1);

        }*/

        if (Input.GetKey(KeyCode.A))
        {
            an.transform.localScale = new Vector3(-1, 1, 1);

        }
        if (Input.GetKey(KeyCode.D))
        {
            an.transform.localScale = new Vector3(1, 1, 1);

        }
    }


    private void AnimRun()
    {
        //run
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
          // if (CrossPlatformInputManager.GetButton("Left") || CrossPlatformInputManager.GetButton("Right"))
        {
            an.SetBool("Run", true);
        }
        else
        {
            an.SetBool("Run", false);

        }
    }


    private void AnimJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            an.SetBool("Jump", true);
        }
        else
        {
            an.SetBool("Jump", false);
        }
    }

    private void AnimAttack()
    {
        if (Input.GetMouseButtonDown(0))
       // if (CrossPlatformInputManager.GetButtonDown("Attack"))
        {
            an.SetTrigger("Attack");
            SoundManager.Playsound("slave");
        }
    }
}
