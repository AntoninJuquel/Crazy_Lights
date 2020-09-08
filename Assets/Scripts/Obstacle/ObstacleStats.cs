using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStats : MonoBehaviour
{
    public float spawningTimer = 10;

    public bool isActvating = true;
    public float activationTimer = 10;

    public bool hasTimeAlive;
    public float timeAlive;

    public float speed;

    [Header("Direction")]
    public bool right;
    public bool left;
    public bool up;
    public bool down;
    public bool toPlayer;
    public GameObject player;

    [Header("Rotator")]
    [Range(-1.0f, 1.0f)]
    public float xForceDirection = 0.0f;
    [Range(-1.0f, 1.0f)]
    public float yForceDirection = 0.0f;
    [Range(-1.0f, 1.0f)]
    public float zForceDirection = 0.0f;

    public float speedMultiplier = 1;

    public bool worldPivote = false;

    private Space spacePivot = Space.Self;

    [Header("Scaling")]
    public bool isScaling;
    public float scalingMult;
    public float targetScale;

    Collider2D col;
    Rigidbody2D rb;
    Color color;


    private void Awake()
    {
        if (GetComponent<Collider2D>())
            col = GetComponent<Collider2D>();
        if (GetComponent<Rigidbody2D>())
            rb = GetComponent<Rigidbody2D>();
        if (GetComponent<SpriteRenderer>())
            color = GetComponent<SpriteRenderer>().color;

    }

    void Start()
    {
        Invoke("Spawn", spawningTimer);
        if (color != null)
            color.a = 255;
        if (col != null)
            col.enabled = false;
        if (worldPivote)
            spacePivot = Space.World;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (isActvating)
        {
            activationTimer -= Time.deltaTime;

            if (activationTimer <= 0)
            {
                if (col != null)
                    col.enabled = true;
                Activate();
                isActvating = false;
            }
        }
        else
        {
            if (hasTimeAlive)
            {
                timeAlive -= Time.deltaTime;
                if (timeAlive <= 0)
                {
                    Destroy(gameObject);
                }
            }
            if (isScaling)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * targetScale, scalingMult * Time.deltaTime);
            }
        }

        

        this.transform.Rotate(xForceDirection * speedMultiplier
                            , yForceDirection * speedMultiplier
                            , zForceDirection * speedMultiplier
                            , spacePivot);
    }
    void Spawn()
    {
        gameObject.SetActive(true);
    }


    void Activate()
    {
        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().color = color;

        if (right)
            rb.velocity += new Vector2(speed, 0);
        else if (left)
            rb.velocity += new Vector2(-speed, 0);

        if (up)
            rb.velocity += new Vector2(0, speed);
        else if (down)
            rb.velocity += new Vector2(0, -speed);

        if (toPlayer)
        {
            rb.velocity += new Vector2(-transform.position.x + player.transform.position.x, (-transform.position.y + player.transform.position.y)).normalized * speed;
        }
    }
}
