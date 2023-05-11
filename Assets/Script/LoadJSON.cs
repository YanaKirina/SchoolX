using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
public class LoadJSON : MonoBehaviour
{
    [SerializeField]

    public Text character;
    public Text dialog;
    private JsonFile jsonFile = new JsonFile();
    private JSONList listOfJSON = new JSONList();
    private string path;
    [SerializeField]
    private Image backgroundImage;
    private string pathImage;
    //public KeyCode switchKey;
    public int indexRound = 0;
    void Start()
    {
        path = Application.streamingAssetsPath + "/Scene.json";
        string jsonData = File.ReadAllText(path);
        listOfJSON.listOfJSON = JsonConvert.DeserializeObject<List<JsonFile>>(jsonData);
    }

    void Update()
    {
        if (indexRound < listOfJSON.listOfJSON.Count)
        {
            character.text = listOfJSON.listOfJSON[indexRound].name;
            dialog.text = listOfJSON.listOfJSON[indexRound].text;
            pathImage = listOfJSON.listOfJSON[indexRound].image;
            backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
        }
    }
    public void ButtonBack()
    {
        indexRound--;
    }
    public void ButtonThen()
    {
        indexRound++;
    }
}
