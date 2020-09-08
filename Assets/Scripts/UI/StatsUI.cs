using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{

    public TextMeshProUGUI score;
    public TextMeshProUGUI dashCounter;
    public TextMeshProUGUI distanceTravelled;
    public TextMeshProUGUI timeStandingStill;
    public TextMeshProUGUI grade;

    public void SetDashCounter(int dashes)
    {
        dashCounter.text = "Dash used : " + dashes;
    }

    public void SetDistanceTravelled(float distance)
    {
        distanceTravelled.text = "Distance travelled : " + distance;
    }

    public void SetTimeStandingStill(float time)
    {
        timeStandingStill.text = "Time standing still : " + time;
    }

    public void SetScore(float _score)
    {
        score.text = "Score :" + _score;
    }
    public void SetGrade(string _grade)
    {
        grade.text = _grade;
    }
}
