using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PostData", order = 1)]
public class PostData : ScriptableObject
{
    public List<Post> posts;
}

[Serializable]
public class Post
{
    public int postType;
    public string postContent;
    public int statType;
    public int statChangeValue;
    public Comment[] possibleComments;
}

[Serializable]
public class Comment
{
    public string commentingGroup;
    public string comment;
    public int statType;
    public int statChangeValue;
}