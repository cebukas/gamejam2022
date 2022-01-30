using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowInfoButton : MonoBehaviour
{

    [SerializeField]
    private GameObject info;
    [SerializeField]
    private Settings settings;
    [SerializeField]
    private TMP_InputField inputTMP;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ShowInfo);
    }

    private void ShowInfo()
    {
        FindObjectOfType<AudioManager>().Play("click"); 
        var text = inputTMP.text;
        if(string.IsNullOrWhiteSpace(text)) return;
        settings.country = text;
        info.SetActive(true);
    }
}
