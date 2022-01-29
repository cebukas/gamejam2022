using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DictatorQuotes", order = 2)]
public class DictatorQuotes : ScriptableObject
{
    public List<Quote> quotes;
}

[Serializable]
public struct Quote
{
    public int type; // See QuoteMood enum
    public string statement;
}