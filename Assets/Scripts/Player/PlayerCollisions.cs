using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    Vector2 screenBounds;
    public int lives = 3;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        FindObjectOfType<HealthBar>().SetMaxHealth(lives);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Projectile"))
        {
            collision.gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            lives--;
            FindObjectOfType<HealthBar>().SetHealth(lives);
            if (lives == 0)
                FindObjectOfType<LevelManager>().GameOver();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            lives--;
            FindObjectOfType<HealthBar>().SetHealth(lives);
            if (lives == 0)
                FindObjectOfType<LevelManager>().GameOver();
        }
    }

/*    private void Update()
    {
        if (transform.position.x < screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        }

        if (transform.position.x > -screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }

        if (transform.position.y < screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
        }
        if (transform.position.y > -screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
        }
    }*/
}
