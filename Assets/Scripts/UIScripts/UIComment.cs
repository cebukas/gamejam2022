using TMPro;
using UnityEngine;

public class UIComment : MonoBehaviour
{
    public Comment comment;
    public Post post;

    public void UpdateFields(Post post, Comment comment){                    // TODO Karolis  update when UI comes
        this.comment = comment;
        this.post = post;

        TMP_Text commentMPComponent = GetComponent<TMP_Text>();
        commentMPComponent.text = comment.comment;
    }

    public void onApproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.CommentApprove(post._uniqueId, comment._uniqueId);
    }
    public void onDisapproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.CommentDiscard(post._uniqueId, comment._uniqueId);
    }
    public void onPostEmbrace()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.CommentEmbrace(post._uniqueId, comment._uniqueId);
    }
}
