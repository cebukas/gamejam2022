using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Poster : MonoBehaviour
{
    public GameObject quotePrefab, postPrefab, commentPrefab;
    private GameObject instantiatedQuote, instantiatedPost, instantiatedComment;
    private List<GameObject> instantiatedPosts = new List<GameObject>();
    private List<GameObject> instantiatedComments = new List<GameObject>();

    public void Quote(Quote quoteData)
    {
        if (instantiatedQuote == null){
            instantiatedQuote = Instantiate(quotePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        TMP_Text quoteTMPComponent = instantiatedQuote.GetComponent<TMP_Text>();
        quoteTMPComponent.text = quoteData.statement;
    }
    public void Post(Post post)
    {
        instantiatedPost = Instantiate(postPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        TMP_Text postTMPComponent = instantiatedPost.GetComponent<TMP_Text>();
        postTMPComponent.text = post.postContent;

        instantiatedPosts.Add(instantiatedPost);
    }
    public void Comment(int postId, Comment comment)
    { 
        Debug.Log(postId);
        instantiatedComment = Instantiate(commentPrefab, instantiatedPosts[postId].transform);

        TMP_Text commentTMPComponent = instantiatedComment.GetComponent<TMP_Text>();
        commentTMPComponent.text = comment.comment;

        instantiatedComments.Add(instantiatedComment);
    }
    
    public void DeleteComment(int commentId)
    {
        instantiatedComments.RemoveAt(commentId);
    }
}
