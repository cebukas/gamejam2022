using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountryBind : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]
    private Settings settings;

    void Start()
    {
        textMeshProUGUI.text = settings.country;
    }
}
