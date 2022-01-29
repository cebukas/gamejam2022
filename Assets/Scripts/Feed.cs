using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Feed : MonoBehaviour
{    
    public GameObject Poster;
    public GameObject Statman;

    private const float PostDelaySeconds = 10.0f;
    private const float QuoteDelaySeconds = 20.0f;
    private const float CommentDelaySeconds = 15.0f;

    private const int MaxActivePostCount = 5;

    private int uniqueId = 0;

    [SerializeField]
    private DictatorQuotes DictatorQuotes;

    [SerializeField]
    private PostData PossiblePosts;
    
    public Quote ActiveQuote;
    public List<Post> Posts;
    public List<Comment> Comments;
    public List<GameObject> InstantiatedPosts = new List<GameObject>();
    public List<GameObject> InstantiatedComments = new List<GameObject>();

    private int _lastQuoteIndex = -1;
    private int _lastPostIndex = -1;
    private int _currentMood = -1;

    public void StartUpdateFeedRoutine()
    {
        PrepareForEvents();
        
        InvokeRepeating(nameof(TryChangingQuote), 0, QuoteDelaySeconds);
        InvokeRepeating(nameof(TryPosting), 0, PostDelaySeconds);
        InvokeRepeating(nameof(TryCommenting), 0, CommentDelaySeconds);
    }

    private void PrepareForEvents()
    {
        Interactor.CommentInteractionEvent += InteractorOnCommentInteractionEvent;
        Interactor.PostInteractionEvent += InteractorOnPostInteractionEvent;
    }

    private void InteractorOnPostInteractionEvent(object sender, PostInteractionEventArgs e)
    {
        var post = Posts[e.objectId];

        foreach(var statChange in post.statChanges)
        {
            if (post._approved)
                Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.approvalStatChange);
            else
                Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.disapprovalStatChange);
        }
        if (e.status == 0)
        {
            // Remove this post
            Posts.RemoveAt(e.objectId);
            InstantiatedPosts.RemoveAt(e.objectId);
        }
        else
        {
            Posts[e.objectId]._approved = true;
        }
    }

    private void InteractorOnCommentInteractionEvent(object sender, CommentInteractionEventArgs e)
    {
        var comment = Comments[e.commentId];

        foreach(var statChange in comment.statChanges)
        {
            if (comment._approved)
                Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.approvalStatChange);
            else
                Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.disapprovalStatChange);
        }
        if (e.status == 0)
        {
            Comments.RemoveAt(e.commentId);
            InstantiatedComments.RemoveAt(e.commentId);
        }
    }

    private void TryChangingQuote()
    {
        var randomQuoteIndex = PickRandom(DictatorQuotes.quotes, _lastQuoteIndex);
        ActiveQuote = DictatorQuotes.quotes[randomQuoteIndex];

        _lastQuoteIndex = randomQuoteIndex;
        _currentMood = ActiveQuote.type;
        
        Poster.GetComponent<Poster>().Quote(ActiveQuote);
        Debug.Log($"{ActiveQuote.type}; {ActiveQuote.statement}");
    }

    private void TryPosting()
    {
        var randomPostIndex = PickRandom(PossiblePosts.posts, _lastPostIndex);

        var foundPostByMood = false;
        int index = 0;
        foreach (var post in PossiblePosts.posts)
        {
            if (post.postType == _currentMood)
            {
                foundPostByMood = true;
            }

            if (foundPostByMood || index >= PossiblePosts.posts.Count)
            {
                break;
            }

            index++;
        }

        if (foundPostByMood)
        {
            var newPost = PossiblePosts.posts[randomPostIndex];
            newPost._uniqueId = uniqueId;
            newPost._approved = false;
            uniqueId++;

            if (Posts.Count > MaxActivePostCount)
            {
                Posts.RemoveAt(0);
                InstantiatedPosts.RemoveAt(0);
            }
            
            Posts.Add(newPost);
            _lastPostIndex = randomPostIndex;

            GameObject instantiatedPost = Poster.GetComponent<Poster>().Post(Posts[Posts.Count - 1]);
            InstantiatedPosts.Add(instantiatedPost);
            
            Debug.Log($"{Posts[Posts.Count - 1].postContent}");
        }
        else
        {
            Debug.Log("No posts to match dictator's mood");
        }
    }

    private void TryCommenting()
    {
        // pick random post to comment on
        var randomPost = PickRandom(InstantiatedPosts, -1);
        // pick random comment 
        var randomComment = PickRandom(Posts[randomPost].possibleComments, -1);
        // comment

        var newComment = Posts[randomPost].possibleComments[randomComment];
        newComment._uniqueId = uniqueId;
        uniqueId++;
        
        Comments.Add(newComment);
        
        GameObject instantiatedComment = Poster.GetComponent<Poster>().Comment(InstantiatedPosts[randomPost], newComment);
        InstantiatedComments.Add(instantiatedComment);

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
