using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Feed : MonoBehaviour
{
    private const float PostDelaySeconds = 10.0f;
    private const float QuoteDelaySeconds = 5.0f;
    private const float CommentDelaySeconds = 15.0f;

    [SerializeField]
    private DictatorQuotes DictatorQuotes;

    [SerializeField]
    private PostData PossiblePosts;
    
    public Quote ActiveQuote;
    public List<Post> Posts;

    private int _lastQuoteIndex = -1;
    private int _lastPostIndex = -1;
    
    public void StartUpdateFeedRoutine()
    {
        InvokeRepeating(nameof(TryChangingQuote), 0, QuoteDelaySeconds);
        InvokeRepeating(nameof(TryPosting), 0, PostDelaySeconds);
        InvokeRepeating(nameof(TryCommenting), 0, CommentDelaySeconds);
    }

    private void TryChangingQuote()
    {
        var randomQuoteIndex = PickRandom(DictatorQuotes.quotes, _lastQuoteIndex);
        ActiveQuote = DictatorQuotes.quotes[randomQuoteIndex];

        _lastQuoteIndex = randomQuoteIndex;
        
        Debug.Log($"{ActiveQuote.type}; {ActiveQuote.statement}");
    }

    private void TryPosting()
    {
        var randomPostIndex = PickRandom(PossiblePosts.posts, _lastPostIndex);
        Posts.Add(PossiblePosts.posts[randomPostIndex]);
        _lastPostIndex = randomPostIndex;

        Debug.Log($"{Posts[Posts.Count-1].postContent}");
    }

    private void TryCommenting()
    {
        // pick random post to comment on
        var randomPost = PickRandom(Posts, -1);
        // pick random comment 
        var randomComment = PickRandom(Posts[randomPost].possibleComments, -1);
        // comment
        Debug.Log($"{Posts[randomPost].possibleComments[randomComment].commentingGroup} comment  '{Posts[randomPost].possibleComments[randomComment].comment}' " +
                  $" under {Posts[randomPost].postContent}");
    }

    private int PickRandom<T>(IReadOnlyCollection<T> objects, int lastIndex)
    {
        var rand = Random.Range(0, objects.Count);
        while (rand == lastIndex)
        {
            rand = Random.Range(0, objects.Count);
        }

        return rand;
    }
}
