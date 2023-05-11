using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JSONList
{
    [SerializeField]
    public List<JsonFile> listOfJSON = new List<JsonFile>();
}
