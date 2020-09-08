using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour
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
    }
}
