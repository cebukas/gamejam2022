using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DismissCreditsButton : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsScreen;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(DismissCredits);
    }

    private void DismissCredits()
    {
        creditsScreen.SetActive(false);
    }
}
