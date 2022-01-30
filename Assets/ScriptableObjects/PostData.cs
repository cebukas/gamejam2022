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

    public StatChange[] statChanges;
    public Comment[] possibleComments;
    [HideInInspector]
    public int _uniqueId;
    [HideInInspector]
    public bool _approved;
}

[Serializable]
public class Comment
{
    public string commentingGroup;
    public string comment;
    public StatChange[] statChanges;
    public int _uniqueId;
    public bool _approved;
}

[Serializable]
public class StatChange
{
    public int statType;

    public int approvalStatChange;

    public int disapprovalStatChange;
}