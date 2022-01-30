using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExitButton : MonoBehaviour
    {

        private void Start()
        {
            var quitButton = GetComponent<Button>();
            quitButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
