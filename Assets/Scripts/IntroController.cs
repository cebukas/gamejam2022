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
        private TMP_InputField textMeshProUGUI;
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
            textMeshProUGUI.text = null;
            focusInput();
        }

        public void LoadGameIfPossible()
        {
            var text = textMeshProUGUI.text;
            if(string.IsNullOrWhiteSpace(text)) return;

            settings.country = text;
            sceneController.LoadScene(Scene.Game);
        }

        private void focusInput()
        {
            textMeshProUGUI.ActivateInputField();
        }
    }
}