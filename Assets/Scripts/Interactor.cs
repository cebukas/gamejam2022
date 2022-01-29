using System;

public class PostInteractionEventArgs : EventArgs
{
    public int status { get; set; } // 0 - discard 1 - approve 2 - embrace
    public int objectId { get; set; } // an index of a post
}

public class CommentInteractionEventArgs : EventArgs
{
    public int status { get; set; } // 0 - discard 1 - approve 2 - embrace
    public int postId { get; set; } // an index of a post
    public int commentId { get; set; } // an index of a comment
}

public class Interactor
{
    public static event EventHandler<PostInteractionEventArgs> PostInteractionEvent;
    public static event EventHandler<CommentInteractionEventArgs> CommentInteractionEvent;
    
    public static void PostApprove(int postId)
    {
        PostInteractionEvent?.Invoke(null, new PostInteractionEventArgs {status = 1, objectId = postId});
    }
    
    public static void PostDiscard(int postId)
    {
        PostInteractionEvent?.Invoke(null, new PostInteractionEventArgs {status = 0, objectId = postId});
    }
    
    public static void PostEmbrace(int postId)
    {
        PostInteractionEvent?.Invoke(null, new PostInteractionEventArgs {status = 2, objectId = postId});
    }
    
    public static void CommentApprove(int postId, int commentId)
    {
        CommentInteractionEvent?.Invoke(null, new CommentInteractionEventArgs {status = 1, postId = postId, commentId = commentId});
    }
    
    public static void CommentDiscard(int postId, int commentId)
    {
        CommentInteractionEvent?.Invoke(null, new CommentInteractionEventArgs() {status = 0, postId = postId, commentId = commentId});
    }
    
    public static void CommentEmbrace(int postId, int commentId)
    {
        CommentInteractionEvent?.Invoke(null, new CommentInteractionEventArgs() {status = 2, postId = postId, commentId = commentId});
    }
    public static Stats StatCaster(string stat)
    {
        stat = stat.ToLower();
        
        if (stat == "crypto")
        {
            return Stats.CryptoKopek;
        }
        if (stat == "citizen")
        {
            return Stats.CitizenSupport;
        }
        if (stat == "dictator")
        {
            return Stats.DictatorApproval;
        }
        if (stat == "foreign")
        {
            return Stats.ForeignAffairs;
        }
        else throw new Exception();
    }
}

