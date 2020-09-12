using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{

    Rigidbody2D rb;
    Transform target;
    public static bool isDanger = false;
    public static bool isFollow = false;

    [Header("추격 속도")]
    [SerializeField] [Range(1f, 4f)] float movespeed = 3f;

    [Header("근접 거리")]
    [SerializeField] [Range(0f, 3f)] float contactDistance = 1;

    Transform enemyTransfrom;

    public static bool follow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyTransfrom = GetComponent<Transform>();
    }

    void Update()
    {
        FollowTarget();
    }


    void FollowTarget()
    {
        if(Vector2.Distance(transform.position, target.position) > contactDistance)
        {
            isDanger = true;
        }
        else
        {
            isDanger = false;
        }
        if(Vector2.Distance(transform.position, target.position) > contactDistance && follow && Player.run_check)
        {
            enemyTransfrom.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
            isFollow = true;
        }
        else
        {
            rb.velocity = Vector2.zero;
            isFollow = false;
        }
    }

  

}
