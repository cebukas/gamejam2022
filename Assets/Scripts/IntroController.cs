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

        private void focusInput()
        {
            inputTMP.ActivateInputField();
        }
    }
}