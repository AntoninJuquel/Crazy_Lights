using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1Actions : MonoBehaviour
{
    LevelManager levelManager;
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void Update()
    {
        if (levelManager.timer >= 33.9f && levelManager.timer <= 34.2f)
        {
            GetComponent<Animation>()["BossShoot"].speed = 0.625f;
            PlayAtk("BossShoot");
        }

        if (levelManager.timer>=36.4f && levelManager.timer <= 36.7f)
        {
            PlayAtk("BossTopRight");
        }

        if (levelManager.timer >= 42.9f && levelManager.timer <= 43.2f)
        {
            PlayAtk("BossBottomLeft");
        }

        if (levelManager.timer >= 49.3f && levelManager.timer <= 49.6f)
        {
            PlayAtk("BossTopRight");
        }

        if (levelManager.timer >= 85f && levelManager.timer <= 85.3f)
        {
            GetComponent<Animation>()["BossEnding"].speed = 0.1f;
            PlayAtk("BossEnding");
        }
    }

    void PlayAtk(string attackName)
    {
        GetComponent<Animation>().Play(attackName);
        
    }
}
