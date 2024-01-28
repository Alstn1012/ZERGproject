using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Bulletpos;
    public Transform pos; // �߻�ü�� ����
    public float Cooldown = 1f; // �߻�ü�� ��Ÿ�� (1��)

    private float Shoot_Time;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > Shoot_Time + Cooldown)
        {
            Instantiate(bullet,pos.position,Bulletpos.transform.rotation);
            Shoot_Time = Time.time;
        }
    }

}
