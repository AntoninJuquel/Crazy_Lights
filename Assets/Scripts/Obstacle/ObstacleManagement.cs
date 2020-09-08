using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManagement : MonoBehaviour
{
    Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < screenBounds.x*1.5f || transform.position.x > -screenBounds.x * 1.5f || transform.position.y < screenBounds.y * 1.5f || transform.position.y > -screenBounds.y * 1.5f)
        {
            if (gameObject.CompareTag("Projectile"))
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }
    }
}
