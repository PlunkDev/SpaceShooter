using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed = 2f;

    public Transform playerTransform;

    public Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();


        rb.velocity = (playerTransform.position - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.playerController.Hitted();
            Destroy(gameObject);
        }
    }
}
