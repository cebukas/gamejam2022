using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DismissButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Dismiss);
    }

    // Update is called once per frame
    private void Dismiss()
    {
        gameObject.SetActive(false);
    }
}
