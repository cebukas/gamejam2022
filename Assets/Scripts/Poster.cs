using UnityEngine;
using TMPro;

public class Poster : MonoBehaviour
{
    public GameObject quotePrefab, postPrefab, commentPrefab;
    private GameObject instantiatedQuote, instantiatedPost, instantiatedComment;

    public void Quote(Quote quoteData)
    {
        if (instantiatedQuote == null){
            instantiatedQuote = Instantiate(quotePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        TMP_Text quoteTMPComponent = instantiatedQuote.GetComponent<TMP_Text>();
        quoteTMPComponent.text = quoteData.statement;
    }
    public GameObject Post(Post post)
    {
        instantiatedPost = Instantiate(postPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        TMP_Text postTMPComponent = instantiatedPost.GetComponent<TMP_Text>();
        postTMPComponent.text = post.postContent;

        return instantiatedPost;
    }
    public GameObject Comment(GameObject post, Comment comment)
    { 
        instantiatedComment = Instantiate(commentPrefab, post.transform);

        TMP_Text commentTMPComponent = instantiatedComment.GetComponent<TMP_Text>();
        commentTMPComponent.text = comment.comment;

        return instantiatedComment;
    }
}
