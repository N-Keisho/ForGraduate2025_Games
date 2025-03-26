using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image image;
    public float value;
    public float maxValue;
    private float timer;
    public float separateTime;
    // Start is called before the first frame update
    void Start()
    {
        value = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= separateTime)
        {
            timer = 0;
            value -= separateTime;
            image.fillAmount = value / maxValue;
            if (value <= 0)
            {
                value = 0;
                image.fillAmount = 0;
            }
        }
    }
}
