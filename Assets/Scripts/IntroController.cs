using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace Intro
{
    public class IntroController : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField inputTMP;
        [SerializeField]
        private Settings settings;
        [SerializeField]
        private SceneController sceneController;

        private void Start()
        {
            focusInput();
        }

        public void ClearText()
        {
            FindObjectOfType<AudioManager>().Play("click"); 
            inputTMP.text = null;
            focusInput();
        }

        public void LoadGameIfPossible()
        {
            FindObjectOfType<AudioManager>().Play("click"); 
            var text = inputTMP.text;
            if(string.IsNullOrWhiteSpace(text)) return;

            settings.country = text;
            sceneController.LoadScene(Scene.Game);
        }

        private void focusInput()
        {
            inputTMP.ActivateInputField();
        }
    }
}