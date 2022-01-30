using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMeshProUGUI;

        [SerializeField]
        private int initialMins = 10;
        [SerializeField]
        private int initialSeconds = 0;

        private float timeRemaining;
        private bool timerIsRunning = false;
        private SceneController sceneController;

        private void Start()
        {
            sceneController = FindObjectOfType<SceneController>();
            timeRemaining = getInitialTime();
            timerIsRunning = true;
        }

        private void Update()
        {
            if (!timerIsRunning) return;

            timeRemaining -= Time.deltaTime;
            if (timeRemaining > 0)
            {
                UpdateText();
            }
            else
            {
                timeRemaining = 0;
                UpdateText();
                timerIsRunning = false;
                sceneController.LoadScene(Scene.GameOver);
            }
        }

        private int getInitialTime()
        {
            return initialMins * 60 + initialSeconds;
        }

        private void UpdateText()
        {
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            textMeshProUGUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void Pause()
        {
            timerIsRunning = false;
        }

        public void Resume()
        {
            timerIsRunning = true;
        }
        public void Reset()
        {
            timeRemaining = getInitialTime();
            timerIsRunning = true;
        }
    }
}