using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    int direction = 1;

    bool use;

    private void Start()
    {
        transform.parent = null;
        float random = Random.Range(0, 2);
        speed = Random.Range(1, 5);


        if (random == 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

    }

    bool useDes;
    private void Update()
    {
        if (GameplayManager.instance.nonEnemy && !useDes)
        {
            useDes = true;
            Animator animator = gameObject.GetComponent<Animator>();
            animator.SetTrigger("Start");
            Destroy(gameObject, 1);
        }

        if (transform.position.x > 20)
        {
            direction = -1;
        }
        else if (transform.position.x < -20)
        {
            direction = 1;
        }

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        transform.GetChild(0).Rotate(Vector3.forward, speed * direction * 40 * -1 * Time.deltaTime);

        if (use) return;
        if (transform.position.z <= Player.instance.transform.position.z + -50)
        {
            use = true;
            Destroy(gameObject);
        }
    }
}
