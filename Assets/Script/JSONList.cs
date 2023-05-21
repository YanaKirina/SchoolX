using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JsonList
{
    [SerializeField]
    public List<JsonFile> listOfJSON = new List<JsonFile>();
    [SerializeField]
    public List<JsonFileChoise> listOfJSONChoise = new List<JsonFileChoise>();
    [SerializeField]
    public List<JsonIssue> listOfJSONIssue = new List<JsonIssue>();
}
