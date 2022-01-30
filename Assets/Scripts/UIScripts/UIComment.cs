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
        FindObjectOfType<AudioManager>().Play("approve"); 

        this.transform.Find("Image").gameObject.transform.Find("Buttons").gameObject.SetActive(false);

        Interactor.CommentApprove(post._uniqueId, comment._uniqueId);
    }
    public void onDisapproveClick()
    {
        FindObjectOfType<AudioManager>().Play("decline"); 

        Interactor.CommentDiscard(post._uniqueId, comment._uniqueId);
    }
    public void onPostEmbrace()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        Interactor.CommentEmbrace(post._uniqueId, comment._uniqueId);
    }
    
    public void OnBribeClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        this.transform.Find("Image").gameObject.transform.Find("Buttons").gameObject.SetActive(false);
      
        Interactor.ActivatePerk(PerkEnum.Bribery, post._uniqueId);
    }
    
    public void OnReshuffleClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        this.transform.Find("Image").gameObject.transform.Find("Buttons").gameObject.SetActive(false);
      
        Interactor.ActivatePerk(PerkEnum.Reshuffle, post._uniqueId);
    }
    
    public void OnWaitClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        this.transform.Find("Image").gameObject.transform.Find("Buttons").gameObject.SetActive(false);
      
        Interactor.ActivatePerk(PerkEnum.Wait, post._uniqueId);
    }
    
    public void OnEmbraceClick()
    {
        FindObjectOfType<AudioManager>().Play("click"); 

        this.transform.Find("Image").gameObject.transform.Find("Buttons").gameObject.SetActive(false);
      
        Interactor.ActivatePerk(PerkEnum.Embrace, post._uniqueId);
    }
}
