using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    [SerializeField]
    private Button hamburger;
    [SerializeField]
    private GameObject overlay;

    private void Start()
    {
        hamburger.onClick.AddListener(OpenMenu);
    }
    public void OpenMenu()
    {
        overlay.SetActive(true);
    }
}
