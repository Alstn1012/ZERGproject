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
        Destroy(gameObject, lifetime); // lifetime 값(초) 후 총알 제거
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        /**if(ray.collider != null)
        {
<<<<<<< HEAD
            if (ray.collider.tag == "enemy" && ray.collider.tag == "wall")
            {
                Destroy(gameObject);
            }
        }**/
=======
            if (ray.collider.tag == "enemy" && ray.collider.tag == "wall");
            Destroy(gameObject);
        }

>>>>>>> parent of 9bd9662 (bullet collision)
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
