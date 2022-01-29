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
        instantiatedQuote.GetComponent<UIQuote>().UpdateFields(quoteData);
    }
    public GameObject Post(Post post)
    {
        instantiatedPost = Instantiate(postPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        instantiatedPost.GetComponent<UIPoster>().UpdateFields(post);

        return instantiatedPost;
    }
    public GameObject Comment(GameObject postGO, Post post, Comment comment)
    { 
        instantiatedComment = Instantiate(commentPrefab, postGO.transform);

        instantiatedComment.GetComponent<UIComment>().UpdateFields(post, comment);

        return instantiatedComment;
    }
}
