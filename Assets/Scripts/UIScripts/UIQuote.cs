using TMPro;
using UnityEngine;

public class UIQuote : MonoBehaviour
{
    public Quote quote;
    public void UpdateFields(Quote quote)
    {   
        this.quote = quote;

        TMP_Text quoteMPComponent = GetComponentInChildren<TMP_Text>();
        quoteMPComponent.text = quote.statement;

        FindObjectOfType<AudioManager>().Play("storychange"); 
    }
}
