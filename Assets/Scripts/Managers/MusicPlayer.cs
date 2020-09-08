using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioManager music;
    public string musicLevel;
    // Start is called before the first frame update
    void Start()
    {
        music = FindObjectOfType<AudioManager>();
        music.Play(musicLevel);
    }
}
