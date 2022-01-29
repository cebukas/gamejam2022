using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PostData", order = 1)]
public class PostData : ScriptableObject
{
    public List<Post> posts;
}
 [Serializable]
public struct Post{
    public int postType;
    public string postContent;
    public int statType;
    public int statChangeValue;
}