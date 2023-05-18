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
    int indexRoundChoise = 0; 
    //private JsonFileChoise jsonFileChoise = new JsonFileChoise();
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
    [SerializeField]
    GameObject then;
    [SerializeField]
    GameObject back;

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
            if (listOfJSON.listOfJSON[indexRound].condition == "No")
            {
                then.SetActive(false);
                back.SetActive(false);
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
                button4.SetActive(true);
                character.text = " ";
                dialog.text = " ";
                indexRoundChoise++;
                Debug.Log(indexRoundChoise);
            }
        }
    }
    public void Button1()
    {

    }
    public void Button2()
    {

    }
    public void Button3()
    {

    }
    public void Button4()
    {

    }
}
