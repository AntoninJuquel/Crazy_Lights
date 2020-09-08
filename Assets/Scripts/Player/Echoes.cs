using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echoes : MonoBehaviour
{
    float timer = 2;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy();
            timer = 2;
        }
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
