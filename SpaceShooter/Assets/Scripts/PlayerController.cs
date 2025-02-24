using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hp = 3;

    public int score = 0;

    public float moveSpeed = 4f;
    public Transform maxXValue;
    public Transform minXValue;

    public GameObject bulletPrefab;
    public Transform gunPosition;

    public float fireRate = 0.2f;
    private float timeSinceLastAction = 0f;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.playerController = this;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKey(KeyCode.Space)) 
        {
            Shoot();
        }

        if(hp <= 0)
        {
            PlayerPrefs.SetInt("score", score);
            GameManager.sceneManager.Over();
        }
    }

    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInputValue, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movementVector);

        if (transform.position.x > maxXValue.position.x)
        {
            transform.position = new Vector2(maxXValue.position.x, transform.position.y);
        }
        if (transform.position.x < minXValue.position.x)
        {
            transform.position = new Vector2(minXValue.position.x, transform.position.y);
        }
    }
    void Shoot()
    {
        timeSinceLastAction += Time.deltaTime;
        if(timeSinceLastAction >= fireRate)
        {
            GameManager.audioManager.Play("shot", 1.0f);
            Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            timeSinceLastAction = 0;
        }
        
    }

    public void Hitted()
    {
        hp--;
        GameManager.uiManager.DisableHpSprite(hp);
        GameManager.audioManager.Play("explosion", 1.0f);
    }
}
