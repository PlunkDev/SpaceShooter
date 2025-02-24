using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float fireRate = 1f;
    private float timeSinceLastAction = 0f;

    public Transform playerTransform;

    public GameObject bulletPrefab;
    public Transform enemyGunEnd;

    private ScreenShake screenShake;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.Find("Player");
        GameObject cameraObject = GameObject.Find("Main Camera");
        screenShake = cameraObject.GetComponent<ScreenShake>();
        playerTransform = playerGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        Shoot();

        if (transform.position.y < -5.5f)
        {
            GameManager.playerController.Hitted();

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            screenShake.start = true;
            GameManager.audioManager.Play("explosion", 1.0f);
            GameManager.uiManager.ChangeScore();
            Destroy(gameObject);
        }
    }
    void Shoot()
    {
        timeSinceLastAction += Time.deltaTime;
        if (timeSinceLastAction >= fireRate)
        {
            Instantiate(bulletPrefab, enemyGunEnd.position, Quaternion.identity);
            timeSinceLastAction = 0;
        }

    }
}
