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
    public Image aaa;
    void Start()
    {
        path = Application.streamingAssetsPath + "/Scene.json";
        string jsonData = File.ReadAllText(path);
        listOfJSON.listOfJSON = JsonConvert.DeserializeObject<List<JsonFile>>(jsonData);
    }

    void Update()
    {
        //if (indexRound < listOfJSON.listOfJSON.Count & indexRound >= 0)
        //{
            character.text = listOfJSON.listOfJSON[indexRound].name;
            dialog.text = listOfJSON.listOfJSON[indexRound].text;
            pathImage = listOfJSON.listOfJSON[indexRound].image;
            backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
        //}
    }
    public void ButtonBack()
    {
        if (indexRound > 0)
        {
            indexRound--;
        }
    }
    public void ButtonThen()
    {
        if (indexRound < listOfJSON.listOfJSON.Count - 1)
        {
            indexRound++;
        }
    }
}
