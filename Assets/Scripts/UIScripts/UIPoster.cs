using TMPro;
using UnityEngine;

public class UIPoster : MonoBehaviour
{
    public Post post;
    private TMP_Text title, body;
    public void UpdateFields(Post post){    
        this.post = post;

        var TMPs = GetComponentsInChildren<TMP_Text>();
        title = TMPs[0];
        body = TMPs[1];

        title.text = post.user;
        body.text = post.postContent;
    }

    public void onApproveClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        this.transform.SetSiblingIndex(this.transform.parent.gameObject.transform.Find("Official News Box").GetSiblingIndex());
   
        Destroy(this.transform.Find("Buttons").gameObject);

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
