using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBarSetting : MonoBehaviour
{
    private float fillAmount;

    [Header("ScoreBar Setting", order = 1)]

    [SerializeField]
    private Text valueText;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value + "/ " + MaxValue;
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
    private float LerpSpeed = 3;


    private void Update()
    {
        ScoreBarControl();
    }

    public void ScoreBarControl()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * LerpSpeed);
        }

    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
