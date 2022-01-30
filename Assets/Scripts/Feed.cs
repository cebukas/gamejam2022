using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Core;
using UnityEngine;
using Random = UnityEngine.Random;

public class Feed : MonoBehaviour
{
    private SceneController _sceneController;
    
    public GameObject Poster;
    public GameObject Statman;

    private const float PostDelaySeconds = 10.0f;
    private const float QuoteDelaySeconds = 20.0f;
    private const float CommentDelaySeconds = 15.0f;
    private const float DayDuration = 300.0f; // 5 minutes
    private const int IterationCountAfterPostingDone = 3; // let's wait 3 more post iteration before calling victory (assuming we'll have enough stats)
    
    private int MaxActivePostCount = 5;

    private int uniqueId = 0;

    [SerializeField]
    private DictatorQuotes DictatorQuotes;

    [SerializeField]
    private PostData PossiblePosts;
    
    public Quote ActiveQuote;
    public List<Post> Posts;
    public List<Post> BlockedPosts;
    public List<Comment> Comments;
    public List<GameObject> InstantiatedPosts = new List<GameObject>();
    public List<GameObject> InstantiatedComments = new List<GameObject>();

    public UINotifications uiNotifications;

    private int _lastQuoteIndex = -1;
    private int _lastPostIndex = -1;
    private int _currentMood = -1;
    private int _currentOutOfPostIteration = -1;
    
    private bool outOfPosts = false;
    private bool outOfComments = false;

    private int _allCommentCount;
    
    public string TimeString { get; set; }

    private GameObject emptyState;

    private void Start()
    {
        emptyState = FindObjectOfType<EmptyState>().gameObject;
    }

    private void setEmptyStateEnabled()
    {
        emptyState.SetActive(!Posts.Any() && !Comments.Any());
    }

    public void StartUpdateFeedRoutine()
    {
        PrepareForEvents();

        _sceneController = FindObjectOfType<SceneController>();
        
        _allCommentCount = GetAllCommentCount();
        
        InvokeRepeating(nameof(TryChangingQuote), 0, QuoteDelaySeconds);
        InvokeRepeating(nameof(TryPosting), 0, PostDelaySeconds);
        InvokeRepeating(nameof(TryCommenting), 0, CommentDelaySeconds);
    }
    
    private void Update(){
        uiNotifications.updateText(getNotificationsCount());
    }

    private void PrepareForEvents()
    {
        Interactor.CommentInteractionEvent += InteractorOnCommentInteractionEvent;
        Interactor.PostInteractionEvent += InteractorOnPostInteractionEvent;
        Interactor.PerkInteractionEvent += InteractorOnPerkInteractionEvent;
    }

    private void InteractorOnPerkInteractionEvent(object sender, PerkInteractionEventArgs e)
    {
        if (!Statman.GetComponent<StatManager>().GetPerkStatus(e.Perk)) return;
        
        switch (e.Perk)
        {
            case PerkEnum.Bribery:
                Debug.Log("bribin'");
                Bribe(e.PostId);
                Statman.GetComponent<StatManager>().UpdateStat(Stats.CryptoKopek, -50);
                break;
            case PerkEnum.Embrace:
                Debug.Log("embracin'");
                Embrace(e.PostId);
                Statman.GetComponent<StatManager>().UpdateStat(Stats.CitizenSupport, -50);
                break;
            case PerkEnum.Reshuffle:
                Debug.Log("reshufflin'");
                Reshuffle();
                Statman.GetComponent<StatManager>().UpdateStat(Stats.ForeignAffairs, -50);
                break;
            case PerkEnum.Wait:
                Debug.Log("waitin'");
                Wait();
                Statman.GetComponent<StatManager>().UpdateStat(Stats.DictatorApproval, -50);
                break;
        }
    }

    private void Bribe(int postId)
    {
        DeletePostByUniqueId(postId);
    }

    private void Embrace(int postId)
    {
        var post = GetPostByUniqueId(postId);
        post._approved = true;
        if (post.statChanges != null)
        {
            foreach (var statChange in post.statChanges)
            {
                if (statChange.statType != 0)
                {
                    Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.approvalStatChange * 2);
                }
            }
        }
    }

    private void Reshuffle()
    {
        // bbd
        TryPosting();
        TryPosting();
    }

    private void Wait()
    {
        if (MaxActivePostCount < 7)
        {
            MaxActivePostCount++;
        }
    }

    private Post GetPostByUniqueId(int id)
    {
        foreach (var post in Posts)
        {
            if (post._uniqueId == id)
            {
                return post;
            }
        }

        return null;
    }

    private Comment GetCommentByUniqueId(int id)
    {
        foreach (var comment in Comments)
        {
            if (comment._uniqueId == id)
            {
                return comment;
            }
        }

        return null;
    }

    private void DeletePostByUniqueId(int id)
    {
        int index = 0;

        foreach (var post in Posts)
        {
            if (post._uniqueId == id)
            {
                break;
            }

            index++;
        }
        
        Posts.RemoveAt(index);
        Destroy(InstantiatedPosts[index]);
        InstantiatedPosts.RemoveAt(index);
        setEmptyStateEnabled();
    }
    
    private void DeleteCommentByUniqueId(int id)
    {
        int index = 0;

        foreach (var comment in Comments)
        {
            if (comment._uniqueId == id)
            {
                break;
            }

            index++;
        }
        
        Comments.RemoveAt(index);
        Destroy(InstantiatedComments[index]);
        InstantiatedComments.RemoveAt(index);
        setEmptyStateEnabled();
    }
    
    private void InteractorOnPostInteractionEvent(object sender, PostInteractionEventArgs e)
    {
        var post = GetPostByUniqueId(e.ObjectId);

        if (e.Status != 0)
        {
            post._approved = true;
        }

        if(post.statChanges != null)
        {
            foreach(var statChange in post.statChanges)
            {
                if(statChange.statType != 0)
                {
                    if (post._approved){
                        Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.approvalStatChange);
                    }
                    else
                        Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.disapprovalStatChange);
                }
            }
        }

        if (e.Status == 0)
        {
            DeletePostByUniqueId(e.ObjectId);
        }
       
        BlockedPosts.Add(post); // make sure this post won't reappear
    }

    private void InteractorOnCommentInteractionEvent(object sender, CommentInteractionEventArgs e)
    {
        var comment = GetCommentByUniqueId(e.CommentId);
        
        if (comment == null)
        {
            return;
        }
        
        if (e.Status != 0)
        {
            comment._approved = true;
        }
        
        if(comment.statChanges != null)
        {
            foreach(var statChange in comment.statChanges)
            {
                if(statChange.statType != 0)
                {
                    if (comment._approved)
                        Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.approvalStatChange);
                    else
                        Statman.GetComponent<StatManager>().UpdateStat((Stats)statChange.statType, statChange.disapprovalStatChange);
                }
            }
        }

        if (e.Status == 0)
        {
            DeleteCommentByUniqueId(e.CommentId);
        }
    }

    private void TryChangingQuote()
    {
        var randomQuoteIndex = PickRandom(DictatorQuotes.quotes, _lastQuoteIndex);
        if(randomQuoteIndex == -1)
        {
            return;
        }
        ActiveQuote = DictatorQuotes.quotes[randomQuoteIndex];

        _lastQuoteIndex = randomQuoteIndex;
        _currentMood = ActiveQuote.type;
        
        Poster.GetComponent<Poster>().Quote(ActiveQuote);
        Debug.Log($"{ActiveQuote.type}; {ActiveQuote.statement}");
    }

    private void TryPosting()
    {
        if (outOfPosts)
        {
            if (_currentOutOfPostIteration >= IterationCountAfterPostingDone)
            {
                _sceneController.LoadScene(Scene.GameWon);
                //VictoryEvent?.Invoke(this, EventArgs.Empty);
            }
            
            _currentOutOfPostIteration++;
            _allCommentCount = GetAllCommentCount();
            return;
        }
        
        var randomPostIndex = PickRandom(PossiblePosts.posts, _lastPostIndex);

        if (randomPostIndex == -1 || BlockedPosts.Count >= PossiblePosts.posts.Count)
        {
            outOfPosts = true;
            return;
        }
        
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

            if (CheckIfSuchPostWasMade(newPost))
            {
                return;
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

        setEmptyStateEnabled();
    }

    private int getNotificationsCount()
    {
        int notifications = 0;
        foreach(var post in Posts)
        {
            if(post._approved == false)
            {
                notifications++;
            }
        }
        foreach(var comment in Comments)
        {
            if(comment._approved == false)
            {
                notifications++;
            }
        }
        return notifications;
    }

    private bool CheckIfSuchCommentWasMade(Comment comment)
    {
        foreach (var com in Comments)
        {
            if (com.comment.Equals(comment.comment) && com.commentingGroup.Equals(comment.commentingGroup))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckIfSuchPostWasMade(Post post)
    {
        foreach (var p in Posts)
        {
            if (p.postContent.Equals(post.postContent))
            {
                return true;
            }
        }

        return false;
    }
    
    private int GetAllCommentCount()
    {
        int i = 0;
        foreach (var post in PossiblePosts.posts)
        {
            i += post.possibleComments.Length;
        }

        return i;
    }
    
    private void TryCommenting()
    {
        if (outOfComments)
        {
            Debug.LogWarning("out of comments!");
            return;
        }
        
        // pick random post to comment on
        
        var randomPost = PickRandom(Posts, -1);
        if (randomPost == -1)
        {
            return;
        }

        if (!Posts[randomPost]._approved)
        {
            return;
        }
        // pick random comment 
        var randomComment = PickRandom(Posts[randomPost].possibleComments, -1);
        // comment

        if (randomPost > Posts.Count || randomComment > Posts[randomPost].possibleComments.Count())
        {
            return;
        }

        var newComment = new Comment();
        
        try
        {
            newComment = Posts[randomPost].possibleComments[randomComment];
        }
        catch (Exception e)
        {
            return;
        }

        if (CheckIfSuchCommentWasMade(newComment))
        {
            return;
        }

        if (Comments.Count == _allCommentCount)
        {
            outOfComments = true;
            return;
        }
        
        newComment._uniqueId = uniqueId;
        uniqueId++;
        Comments.Add(newComment);
        GameObject instantiatedComment = Poster.GetComponent<Poster>().Comment(InstantiatedPosts[randomPost], Posts[randomPost], newComment);
        InstantiatedComments.Add(instantiatedComment);
        
        Debug.Log($"post count {Posts.Count}");
        Debug.Log($"randompost {randomPost}");
        
        Debug.Log($"{Posts[randomPost].possibleComments[randomComment].commentingGroup} comment  '{Posts[randomPost].possibleComments[randomComment].comment}' " +
                  $" under {Posts[randomPost].postContent}");
    }

    private int PickRandom<T>(IReadOnlyCollection<T> objects, int lastIndex)
    {
        if (objects.Count == 0)
        {
            Debug.Log("should be out of posts!");
            return -1;
        }
        
        var rand = Random.Range(0, objects.Count);
        while (rand == lastIndex && objects.Count > 1)
        {
            rand = Random.Range(0, objects.Count);
        }

        return rand;
    }
}
