using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Feed : MonoBehaviour
{
    private const float PostDelaySeconds = 10.0f;
    private const float QuoteDelaySeconds = 5.0f;

    public DictatorQuotes DictatorQuotes;
    
    public Quote ActiveQuote;
    public Post ActivePost;
    
    public void UpdateFeed()
    {
        Debug.Log("[DEBUG] Feed is updating");
        TryChangingQuote();
    }

    private void TryChangingQuote()
    {
        StartCoroutine(QuoteTimeoutRoutine());
        
        var randomQuoteIndex = PickRandom(DictatorQuotes.quotes);
        ActiveQuote = DictatorQuotes.quotes[randomQuoteIndex];
    }

    private void TryPosting()
    {
    }

    private void TryCommenting()
    {
    }

    private int PickRandom<T>(IReadOnlyCollection<T> objects)
    {
        return Random.Range(0, objects.Count-1);
    }

    private IEnumerator PostTimeoutRoutine()
    {
        Debug.Log($"[DEBUG][POST] Waiting for {PostDelaySeconds} seconds before posting");
        yield return new WaitForSeconds(PostDelaySeconds);
        Debug.Log($"[DEBUG][POST] Waited enough, time for new post");
    }
    
    private IEnumerator QuoteTimeoutRoutine()
    {
        Debug.Log($"[DEBUG][POST] Waiting for {QuoteDelaySeconds} seconds before posting");
        yield return new WaitForSeconds(QuoteDelaySeconds);
        Debug.Log($"[DEBUG][POST] Waited enough, time for new post");
    }
}
