using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    public float timeStanding = 0;
    public int totalDashCounter = 0;
    bool dashIncrease = false;

    public float distanceTravelled = 0;
    Vector2 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerMouvements>().movement == Vector2.zero)
        {
            timeStanding += Time.deltaTime;
        }

        if (GetComponent<PlayerMouvements>().dashStart)
        {
            if (!dashIncrease)
            {
                dashIncrease = true;
                totalDashCounter++;
            }

        }
        else
        {
            dashIncrease = false;
        }

        distanceTravelled += Vector2.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }
}
