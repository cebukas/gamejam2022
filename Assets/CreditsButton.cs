using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsScreen;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowCredits);
    }

    private void ShowCredits()
    {
        creditsScreen.SetActive(true);
    }
}
