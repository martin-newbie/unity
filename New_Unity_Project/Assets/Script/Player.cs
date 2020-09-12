using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int move_method;

    [SerializeField]
    private float maxHp;

    public static float hp;

    public static bool run_check = false;

    private float run;

    [SerializeField]
    private float run_speed;

    public float speed;
    public Vector2 speed_vec;

    public static bool player_moving = false;

    [SerializeField]
    private float startPosX;
    [SerializeField]
    private float startPosY;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Debug.Log(collision.name + "아이템 획득");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log(collision.name + "적에 공격받음");
            Dead();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Dead()
    {
        transform.position = new Vector2(startPosX, startPosY);
        hp -= 30;
        Debug.Log(hp);
        if(hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Moving()
    {
        if (move_method == 0)
        {
            speed_vec = Vector2.zero;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed_vec.x += speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed_vec.x -= speed;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed_vec.y += speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                speed_vec.y -= speed;
            }
            transform.Translate(speed_vec);
        }
        else if (move_method == 1)
        {
            speed_vec.x = Input.GetAxis("Horizontal") * speed;
            speed_vec.y = Input.GetAxis("Vertical") * speed;
            transform.Translate(speed_vec);
        }
        else if (move_method == 2)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run_check = true;
                run = run_speed;
            }
            else
            {
                run_check = false;
                run = 1;
            }

            speed_vec = Vector2.zero;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed_vec.x += speed * run;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed_vec.x -= speed * run;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed_vec.y += speed * run;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                speed_vec.y -= speed * run;
            }
            GetComponent<Rigidbody2D>().velocity = speed_vec;

        }
    }
}
