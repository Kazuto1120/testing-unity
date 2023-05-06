using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public AudioSource audio;
    public Slider slide;

    private void Awake()
    {
        audio.volume = slide.value;
    }
    public void volume()
    {
        audio.volume = slide.value;
    }
    }


