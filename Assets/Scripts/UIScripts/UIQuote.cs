using TMPro;
using UnityEngine;

public class UIQuote : MonoBehaviour
{
    public Quote quote;
    public void UpdateFields(Quote quote){                    // TODO Karolis  update when UI comes
        this.quote = quote;

        TMP_Text quoteMPComponent = GetComponent<TMP_Text>();
        quoteMPComponent.text = quote.statement;
    }
}
