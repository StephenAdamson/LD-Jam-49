using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform fullApples;
    public RectTransform halfApples;

    public RectTransform emptyApples;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void UpdateHealth(float current) {

        fullApples.sizeDelta = new Vector2(20*(((Mathf.CeilToInt(current))/2)), 20);
        halfApples.sizeDelta = new Vector2(20*(((Mathf.CeilToInt(current)+1)/2)), 20);
    }

    public void UpdateMax(float max) {
        emptyApples.sizeDelta = new Vector2(20*(((Mathf.CeilToInt(max))/2)), 20);
    }
}
