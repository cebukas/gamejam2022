using UnityEngine;
using System.Collections.Generic;
using System;
using System.Xml;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 3)]
public class Settings : ScriptableObject
{
    public string country = "";
}