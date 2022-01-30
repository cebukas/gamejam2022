using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleFullScreen);
    }

    private void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
