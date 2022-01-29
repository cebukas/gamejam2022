using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Feed : MonoBehaviour
{    
    public GameObject Poster;
    private const float PostDelaySeconds = 10.0f;
    private const float QuoteDelaySeconds = 5.0f;
    private const float CommentDelaySeconds = 15.0f;

    [SerializeField]
    private DictatorQuotes DictatorQuotes;

    [SerializeField]
    private PostData PossiblePosts;
    
    public Quote ActiveQuote;
    public List<Post> ActivePosts;

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
        
        Poster.GetComponent<Poster>().Quote(ActiveQuote);
        Debug.Log($"{ActiveQuote.type}; {ActiveQuote.statement}");
    }

    private void TryPosting()
    {
        var randomPostIndex = PickRandom(PossiblePosts.posts, _lastPostIndex);
        ActivePosts.Add(PossiblePosts.posts[randomPostIndex]);
        _lastPostIndex = randomPostIndex;

        Poster.GetComponent<Poster>().Post(ActivePosts[ActivePosts.Count-1]);
        Debug.Log($"{ActivePosts[ActivePosts.Count-1].postContent}");
    }

    private void TryCommenting()
    {
        // pick random post to comment on
        var randomPost = PickRandom(ActivePosts, -1);
        // pick random comment 
        var randomComment = PickRandom(ActivePosts[randomPost].possibleComments, -1);
        // comment
        Debug.Log(randomPost);
    
        Poster.GetComponent<Poster>().Comment(randomPost, ActivePosts[randomPost].possibleComments[randomComment]);

        Debug.Log($"{ActivePosts[randomPost].possibleComments[randomComment].commentingGroup} comment  '{ActivePosts[randomPost].possibleComments[randomComment].comment}' " +
                  $" under {ActivePosts[randomPost].postContent}");
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
