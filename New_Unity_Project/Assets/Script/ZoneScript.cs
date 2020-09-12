using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            EnemyMoving.follow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision )
    {
        if ( collision.CompareTag("Player"))
        {
            EnemyMoving.follow = false;
        }
    }
}
