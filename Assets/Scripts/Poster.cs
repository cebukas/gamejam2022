using UnityEngine;
using TMPro;

public class Poster : MonoBehaviour
{
    public GameObject quoteGO, postPrefab, commentPrefab;
    private GameObject instantiatedPost, instantiatedComment;

    public GameObject postParentGO, postAppendingGO;

    private LayoutRefresher layoutRefresher;

    private void Start()
    {
        layoutRefresher = postParentGO.GetComponent<LayoutRefresher>();
    }

    public void Quote(Quote quoteData)
    {
        quoteGO.GetComponent<UIQuote>().UpdateFields(quoteData);
    }
    public GameObject Post(Post post)
    {
        FindObjectOfType<AudioManager>().Play("notification"); 

        instantiatedPost = Instantiate(postPrefab, postParentGO.transform);

        instantiatedPost.transform.SetSiblingIndex(postAppendingGO.transform.GetSiblingIndex() + 1);

        instantiatedPost.GetComponent<UIPoster>().UpdateFields(post);

        StartCoroutine(layoutRefresher.UpdateLayoutGroup());
        return instantiatedPost;
    }
    public GameObject Comment(GameObject postGO, Post post, Comment comment)
    { 
        FindObjectOfType<AudioManager>().Play("notification");

        //instantiatedComment = Instantiate(commentPrefab, postParentGO.transform);
        instantiatedComment = Instantiate(commentPrefab, postGO.transform.GetChild(1).transform);

        //instantiatedComment.transform.SetSiblingIndex(postGO.transform.GetSiblingIndex() + 1);

        instantiatedComment.GetComponent<UIComment>().UpdateFields(post, comment);

        StartCoroutine(layoutRefresher.UpdateLayoutGroup());
        return instantiatedComment;
    }
}
