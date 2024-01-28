using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public float speed;
    public float distance;
    public LayerMask isLayer;

    void Start()
    {
        Destroy(gameObject, lifetime); // lifetime ��(��) �� �Ѿ� ����
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)
        {
            if (ray.collider.tag == "enemy" && ray.collider.tag == "wall");
            Destroy(gameObject);
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
        
    }

}
