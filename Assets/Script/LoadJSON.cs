using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
public class LoadJSON : MonoBehaviour
{
    [SerializeField]
    Text character;
    [SerializeField]
    Text dialog;
    //private JsonFile jsonFile = new JsonFile();
    private JsonList listOfJSON = new JsonList();
    private string path;
    [SerializeField]
    private Image backgroundImage;
    private string pathImage;
    int indexRound = 0;
    private JsonFileChoise jsonFileChoise = new JsonFileChoise();
    private JsonListChoise jsonListChoise = new JsonListChoise();
    private string pathChoise;

    [SerializeField]
    GameObject button1;
    Text textButton1;
    [SerializeField]
    GameObject button2;
    Text textButton2;
    [SerializeField]
    GameObject button3;
    Text textButton3;
    [SerializeField]
    GameObject button4;
    Text textButton4;

    void Start()
    {
        path = Application.streamingAssetsPath + "/Scene.json";
        string jsonData = File.ReadAllText(path);
        listOfJSON.listOfJSON = JsonConvert.DeserializeObject<List<JsonFile>>(jsonData);
        pathChoise = Application.streamingAssetsPath + "/Choise.json";
        string jsonDataChoise = File.ReadAllText(pathChoise);
        jsonListChoise.listOfJSONChoise = JsonConvert.DeserializeObject<List<JsonFileChoise>>(jsonDataChoise);
        //text = button.transform.GetChild(0).GetComponent<Text>();
        //text.text = "fdfvf";
        //button.SetActive(false);



    }

    void Update()
    {
        if (listOfJSON.listOfJSON[indexRound].index == "No")
        {
            
        }
        character.text = listOfJSON.listOfJSON[indexRound].name;
        dialog.text = listOfJSON.listOfJSON[indexRound].text;
        pathImage = listOfJSON.listOfJSON[indexRound].image;
        backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
            
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
