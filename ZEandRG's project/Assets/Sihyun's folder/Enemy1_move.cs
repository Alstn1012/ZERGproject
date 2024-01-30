using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_move : MonoBehaviour
{
    public float dash_delay = 3f;//플레이어 감지 후 돌진까지의 대기시간
    public float detect_range = 25f;//플레이어 감지 범위
    public float max_dash_range = 10f;//돌진 거리
    public float dash_speed = 10f;//돌진 속도

    bool is_dash = false;
    bool is_dash2 = false;
    int dash_dir = 0;
    float dash_range = 0;

    GameObject pl;
    
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(pl.transform.position.x - this.gameObject.transform.position.x) < detect_range && is_dash == false)
        {
            is_dash = true;
            dash_dir = 1;
            if ((pl.transform.position.x - this.gameObject.transform.position.x) < 0)
            {
                dash_dir = -1;
            }
            dash_range = 0;

            Invoke("dash", dash_delay);
        }

        if(is_dash2 == true)
        {
            if(dash_range < max_dash_range)
            {
                GetComponent<Animator>().SetBool("is_idle", false);
                GetComponent<Animator>().SetBool("is_run", true);

                dash_range += dash_speed * Time.deltaTime;
                if (dash_dir < 0) {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                transform.position = new Vector3(transform.position.x + dash_speed*Time.deltaTime* dash_dir, transform.position.y, transform.position.z);
            }
            else
            {
                is_dash2 = false;
                is_dash = false;
                GetComponent<Animator>().SetBool("is_run", false);
                GetComponent<Animator>().SetBool("is_idle", true);
            }
        }
    }

    void dash()
    {
        is_dash2 = true;
    }
}
