using TMPro;
using UnityEngine;

public class UIComment : MonoBehaviour
{
    public Comment comment;
    public Post post;
     private TMP_Text title, body;

    public void UpdateFields(Post post, Comment comment){               
        this.comment = comment;
        this.post = post;
        
        var TMPs = GetComponentsInChildren<TMP_Text>();
        title = TMPs[0];
        body = TMPs[1];

        title.text = comment.commentingGroup;
        body.text = comment.comment;
    }

    public void onApproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.CommentApprove(post._uniqueId, comment._uniqueId);
    }
    public void onDisapproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Destroy(this.transform.Find("Buttons").gameObject);

        Interactor.CommentDiscard(post._uniqueId, comment._uniqueId);
    }
    public void onPostEmbrace()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.CommentEmbrace(post._uniqueId, comment._uniqueId);
    }
}
