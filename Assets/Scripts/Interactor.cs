using System;

public class PostInteractionEventArgs : EventArgs
{
    public int Status { get; set; } // 0 - discard 1 - approve 2 - embrace
    public int ObjectId { get; set; } // an index of a post
}

public class CommentInteractionEventArgs : EventArgs
{
    public int Status { get; set; } // 0 - discard 1 - approve 2 - embrace
    public int PostId { get; set; } // an index of a post
    public int CommentId { get; set; } // an index of a comment
}

public class PerkInteractionEventArgs : EventArgs
{
    public PerkEnum Perk { get; set; }
    public int PostId { get; set; }
}

public class Interactor
{
    public static event EventHandler<PostInteractionEventArgs> PostInteractionEvent;
    public static event EventHandler<CommentInteractionEventArgs> CommentInteractionEvent;
    public static event EventHandler<PerkInteractionEventArgs> PerkInteractionEvent;
    
    public static void PostApprove(int postId)
    {
        PostInteractionEvent?.Invoke(null, new PostInteractionEventArgs {Status = 1, ObjectId = postId});
    }
    
    public static void PostDiscard(int postId)
    {
        PostInteractionEvent?.Invoke(null, new PostInteractionEventArgs {Status = 0, ObjectId = postId});
    }
    
    public static void PostEmbrace(int postId)
    {
        PostInteractionEvent?.Invoke(null, new PostInteractionEventArgs {Status = 2, ObjectId = postId});
    }
    
    public static void CommentApprove(int postId, int commentId)
    {
        CommentInteractionEvent?.Invoke(null, new CommentInteractionEventArgs {Status = 1, PostId = postId, CommentId = commentId});
    }
    
    public static void CommentDiscard(int postId, int commentId)
    {
        CommentInteractionEvent?.Invoke(null, new CommentInteractionEventArgs() {Status = 0, PostId = postId, CommentId = commentId});
    }
    
    public static void CommentEmbrace(int postId, int commentId)
    {
        CommentInteractionEvent?.Invoke(null, new CommentInteractionEventArgs() {Status = 2, PostId = postId, CommentId = commentId});
    }

    public static void ActivatePerk(PerkEnum perk, int postId = -1)
    {
        PerkInteractionEvent?.Invoke(null, new PerkInteractionEventArgs(){Perk = perk, PostId = postId});
    }
}

