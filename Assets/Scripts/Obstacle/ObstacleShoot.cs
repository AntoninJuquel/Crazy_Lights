using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShoot : MonoBehaviour
{

    [Header("Shoot Mode")]
    public bool circular;
    public bool doubleSpiral;
    public bool isRotating;

    public float rotationSpeed;
    public float projectileSpeed;

    public float angleStep;
    public bool shootActive = true;
    public float size;
    public float timer;
    public float timeToShoot;
    public int numberOfProjectiles;
    public float startAngle = 0,endAngle = 360;
    private float angle = 0;

    private void Awake()
    {
        Invoke("Activate", GetComponent<ObstacleStats>().activationTimer + GetComponent<ObstacleStats>().spawningTimer);
    }
    private void Start()
    {
        GetComponent<ObstacleShoot>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToShoot)
        {
            if (circular)
                CircularShoot(numberOfProjectiles);
            else if (doubleSpiral)
                DoubleSpiralShoot();

            if (isRotating)
            {
                startAngle += rotationSpeed;
                endAngle += rotationSpeed;
                

                if (startAngle > 360)
                    startAngle -= 360;
                
                if (endAngle > 360)
                    endAngle -= 360;
            }
        }
    }

    private void Activate()
    {
        GetComponent<ObstacleShoot>().enabled = true;
        if (circular)
            CircularShoot(numberOfProjectiles);
        else if (doubleSpiral)
            DoubleSpiralShoot();
    }


    void CircularShoot(int _numberOfProjectiles)
    {
        float _angleStep = Mathf.Abs(endAngle - startAngle) / _numberOfProjectiles;

        float angle = startAngle;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180 * 1);
            float projectileDirYPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180 * 1);

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0f);
            Vector2 projectileMoveDirection = (projectileVector - transform.position).normalized * projectileSpeed;

            GameObject tmpObj = ObjectsPool.Instance.SpawnFromPool("Projectile", transform.position, Quaternion.identity) as GameObject;
            tmpObj.GetComponent<Transform>().localScale = Vector3.one * size;
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += _angleStep;
            if (angle >= 360f)
                angle = 0f;
        }

        timer = 0;
    }

    void DoubleSpiralShoot()
    {
        for (int i = 0; i <= 1; i++)
        {
            float projectileDirXPosition = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f * 1);
            float projectileDirYPosition = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f * 1);

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0f);
            Vector2 projectileMoveDirection = (projectileVector - transform.position).normalized * projectileSpeed;

            GameObject tmpObj = ObjectsPool.Instance.SpawnFromPool("Projectile", transform.position, Quaternion.identity) as GameObject;
            tmpObj.GetComponent<Transform>().localScale = Vector3.one * size;
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
        }

        angle += 10f;

        if (angle >= 360f)
            angle = 0f;
        timer = 0;
    }
}
