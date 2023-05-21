using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class JOPA : MonoBehaviour
{
    [SerializeField]
    Text character;
    [SerializeField]
    Text dialog;

    private JsonList listOfJSON = new JsonList();
    private JsonList jsonListChoise = new JsonList();
    private JsonList jsonIssue = new JsonList();
}
