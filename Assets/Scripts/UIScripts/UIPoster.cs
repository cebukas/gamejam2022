using TMPro;
using UnityEngine;

public class UIPoster : MonoBehaviour
{
    public Post post;

    public void UpdateFields(Post post){                    // TODO Karolis  update when UI comes
        this.post = post;

        TMP_Text postTMPComponent = GetComponent<TMP_Text>();
        postTMPComponent.text = post.postContent;
    }

    public void onApproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.PostApprove(post._uniqueId);
    }
    public void onDisapproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.PostDiscard(post._uniqueId);
    }
    public void onPostEmbrace()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.PostEmbrace(post._uniqueId);
    }
}
