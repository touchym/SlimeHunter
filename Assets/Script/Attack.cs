using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
   // public GameObject playerrr;

    bool canDamage=true;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("atk" + collision.name);
        // Destroy(collision.gameObject);
       // playerrr.GetComponentInParent<SpriteRenderer>().color = new Color(1, 0, 0, 1);


        IDamageable hit = collision.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (canDamage == true)
            {
                hit.Damage();
                canDamage = false;
                StartCoroutine(resetDamage());
            }
        }
    }
    IEnumerator resetDamage()
    {
        yield return new WaitForSeconds(0.3f);
        canDamage = true;
    }
}
