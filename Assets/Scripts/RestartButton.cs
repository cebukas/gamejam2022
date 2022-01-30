using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace UIButtons
{
    public class RestartButton : MonoBehaviour
    {
        private SceneController sceneController;

        private void Start()
        {
            sceneController = FindObjectOfType<SceneController>();
            var restartButton = GetComponent<Button>();
            restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            sceneController.LoadScene(Scene.Intro);
        }
    }
}

