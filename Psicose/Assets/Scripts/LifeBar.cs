using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public int MaxLife
    {
        set {
            this.slider.maxValue = value;
        }
    }

    public int Life
    {
        set
        {
            this.slider.value = value;
        }

    }

    public void HideBar()
    {
        this.gameObject.SetActive(false);
    }


}
