using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float walkSpeed = 5f;

    public float runSpeed = 10f;

    public int maxDash = 3;
    public int dashCounter;

    public bool dashReloadingStart;
    public float dashReloadingTime = 1.5f;
    public float dashReloadingTimer;

    public float dashSpeed = 50;
    public float dashTime = 0.1f;
    public bool dashStart = false;
    public float dashTimer;
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float noColliderTime = 0.2f;
    public bool noColliderStart = false;
    public float noColliderTimer;

    Rigidbody2D rb;
    Collider2D col;

    public Vector2 movement;

    LayerMask playerLayer;
    LayerMask obstaclesLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        dashCounter = maxDash;

        playerLayer = LayerMask.NameToLayer("Dash");
        obstaclesLayer = LayerMask.NameToLayer("Obstacles");

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        moveSpeed = walkSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashTimer = 0;
            dashStart = true;

            noColliderTimer = 0;
            noColliderStart = true;
        }

        if (noColliderStart)
        {
            noColliderTimer += Time.deltaTime;
            col.enabled = false;
            Physics2D.IgnoreLayerCollision(playerLayer, obstaclesLayer, true);

            if (dashStart && dashCounter > 0)
            {
                moveSpeed = dashSpeed;
                dashTimer += Time.deltaTime;

                dashReloadingStart = true;
                dashReloadingTimer = dashReloadingTime;
                if (dashTimer >= dashTime)
                {
                    dashCounter--;
                    dashStart = false;
                }
            }
            else if (noColliderTimer > noColliderTime)
            {
                Physics2D.IgnoreLayerCollision(playerLayer, obstaclesLayer, false);
                col.enabled = true;
                noColliderStart = false;
            }
        }



        if (dashReloadingStart)
        {
            dashReloadingTimer -= Time.deltaTime;
            if (dashReloadingTimer <= 0)
            {
                dashCounter++;
                dashStart = false;
                dashReloadingTimer = dashReloadingTime;
                dashReloadingStart = dashCounter < maxDash;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        if (dashStart)
        {
            if(timeBtwSpawns <= 0)
            {
            GameObject echo = ObjectsPool.Instance.SpawnFromPool("Echo", transform.position, Quaternion.identity) as GameObject;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
