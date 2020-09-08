using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public GameObject boss;
    public string animationName;
    public float animationSpeedMult;
    bool animationPlayed = false;
    // Start is called before the first frame update
    void Update()
    {
        if (!animationPlayed)
        {
            boss.GetComponent<Animation>()[animationName].speed = animationSpeedMult;
            boss.GetComponent<Animation>().Play(animationName);
            animationPlayed = true;
        }
    }
}
