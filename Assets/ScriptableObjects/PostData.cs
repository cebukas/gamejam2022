using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PostData", order = 1)]
public class PostData : ScriptableObject
{
    public List<Post> posts;
}

[Serializable]
public class Post
{
    public string user;
    public int postType; // correlates with quote type -- if quote is angery -- make angery posts
    public string postContent;
    public int statType; // What kind of stat post is changing
    public int statChangeValue; // how much of a stat is changed
    public Comment[] possibleComments;
    public int uniqueId;
    public bool approved;
}

[Serializable]
public class Comment
{
    public string commentingGroup;
    public string comment;
    public int statType; // What kind of stats are changed by this comment
    public int statChangeValue; // How strong is the stat change
    public int uniqueId;
}