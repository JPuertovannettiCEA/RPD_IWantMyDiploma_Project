using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region Timer Variables
    [SerializeField]
    public static float timer;

    [SerializeField]
    private TMP_Text _timerText;

    #endregion

    void Start()
    {
        timer = 60f;
        _timerText.text = timer.ToString();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        DisplayTime(timer);

        void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            else if (timeToDisplay > 0)
            {
                timeToDisplay += 1;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (timer <= 0f)
        {
            //PlayerController._win = true;
            //SceneManager.LoadScene(2);
        }
    }

}
