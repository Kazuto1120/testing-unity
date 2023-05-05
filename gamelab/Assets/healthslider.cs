using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthslider : MonoBehaviour
{
    public Slider slider;

    public void addheath(int i)
    {
        slider.value += i;
    }
    public void setheath(int i)
    {
        slider.value = i;
    }
}
