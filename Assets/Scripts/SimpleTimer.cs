using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleTimer : MonoBehaviour
{

    public float targetTime = 60.0f;
    public Text timerText;

    void Update()
    {

        targetTime -= Time.deltaTime;
        SetTimerText();
        if (targetTime <= 0.0f)
        {
            TimerEnded();
        }

    }

    void TimerEnded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetTimerText()
    {
        timerText.text = "Timer:   " + targetTime.ToString();
    }

}
