using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutRefresher : MonoBehaviour
{
    private VerticalLayoutGroup group;
    private Scrollbar scrollbar;
    private void Start()
    {
        group = GetComponent<VerticalLayoutGroup>();
        scrollbar = FindObjectOfType<Scrollbar>();
    }
    
    public IEnumerator UpdateLayoutGroup()
    {
        group.enabled = false;
        yield return new WaitForEndOfFrame();
        group.enabled = true;
        yield return new WaitForEndOfFrame();
        scrollbar.value = 1f;
    }
}
