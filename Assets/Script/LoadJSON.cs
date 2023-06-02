using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
public class LoadJSON : MonoBehaviour
{
    private JsonList listOfJSON = new JsonList();
    private JsonList jsonListChoise = new JsonList();
    private JsonList jsonIssue = new JsonList();

    private string path;
    private string pathImage;
    private string pathHuman;
    private string pathChoise;
    private string pathIssue;

    private string Issue;
    private int alternative;

    [SerializeField]
    private Image backgroundImage;
    [SerializeField]
    private Image human;

    public int indexRound = 1;
    public int indexRoundChoise = 1;
    int indexIssue = -1;

    [SerializeField]
    Text character;
    [SerializeField]
    Text dialog;
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
    GameObject aaa;
    [SerializeField]
    GameObject humanImage;
    [SerializeField]
    GameObject gerasin;
    //fbgb vfgz
    void Start()
    {
        path = Application.streamingAssetsPath + "/Scene.json";
        string jsonData = File.ReadAllText(path);
        listOfJSON.listOfJSON = JsonConvert.DeserializeObject<List<JsonFile>>(jsonData);

        pathChoise = Application.streamingAssetsPath + "/Choise.json";
        string jsonDataChoise = File.ReadAllText(pathChoise);
        jsonListChoise.listOfJSONChoise = JsonConvert.DeserializeObject<List<JsonFileChoise>>(jsonDataChoise);
        character.text = listOfJSON.listOfJSON[0].name;
        dialog.text = listOfJSON.listOfJSON[0].text;
        pathImage = listOfJSON.listOfJSON[0].image;
        backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
        pathHuman = listOfJSON.listOfJSON[0].human;
        human.sprite = Resources.Load<Sprite>("Students/" + pathHuman);
    }

    void Update()
    {
        
    }
    public void ButtonThen()
    {
        if (indexRound < listOfJSON.listOfJSON.Count)
            Debug.Log(listOfJSON.listOfJSON[indexRound].text);
        {
            if (listOfJSON.listOfJSON[indexRound].condition != "No")
            {

                character.text = listOfJSON.listOfJSON[indexRound].name;
                dialog.text = listOfJSON.listOfJSON[indexRound].text;
                pathImage = listOfJSON.listOfJSON[indexRound].image;
                backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
                if (listOfJSON.listOfJSON[indexRound].human != "" ^ listOfJSON.listOfJSON[indexRound].human != "")
                {
                    humanImage.SetActive(true);
                }
                else
                {
                    pathHuman = listOfJSON.listOfJSON[indexRound].human;
                    human.sprite = Resources.Load<Sprite>("Students/" + pathHuman);
                    humanImage.SetActive(true);
                }
                indexRound++;

            }
            else
            {
                if (indexIssue == -1)
                {
                    pathIssue = Application.streamingAssetsPath + "/Choise" + indexRoundChoise + ".json";
                    string jsonDataIssue = File.ReadAllText(pathIssue);
                    jsonIssue.listOfJSONIssue = JsonConvert.DeserializeObject<List<JsonIssue>>(jsonDataIssue);
                    then.SetActive(false);
                    aaa.SetActive(false);
                    button1.SetActive(true);
                    button2.SetActive(true);
                    character.text = " ";
                    dialog.text = " ";
                    if (jsonListChoise.listOfJSONChoise[indexRoundChoise].quantity == 3)
                    {
                        button3.SetActive(true);
                    }
                    else if (jsonListChoise.listOfJSONChoise[indexRoundChoise].quantity == 4)
                    {
                        button3.SetActive(true);
                        button4.SetActive(true);
                    }
                    pathImage = jsonListChoise.listOfJSONChoise[indexRoundChoise].background;
                    backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
                    Text text1 = button1.transform.GetChild(0).GetComponent<Text>();
                    text1.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise1;
                    Text text2 = button2.transform.GetChild(0).GetComponent<Text>();
                    text2.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise2;
                    Text text3 = button3.transform.GetChild(0).GetComponent<Text>();
                    text3.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise3;
                    Text text4 = button4.transform.GetChild(0).GetComponent<Text>();
                    text4.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise4;
                }
                else if (indexIssue == jsonIssue.listOfJSONIssue.Count - 1)
                {
                    indexIssue = -1;
                    indexRoundChoise++;
                    indexRound++;
                    character.text = listOfJSON.listOfJSON[indexRound].name;
                    dialog.text = listOfJSON.listOfJSON[indexRound].text;
                    pathImage = listOfJSON.listOfJSON[indexRound].image;
                    backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
                    indexRound++;
                }
                else if (indexIssue < jsonIssue.listOfJSONIssue.Count - 1)
                {
                    if (alternative == 1)
                    {
                        if (jsonIssue.listOfJSONIssue[indexIssue + 1].issue1 == "")
                        {

                            indexRound++;
                            character.text = listOfJSON.listOfJSON[indexRound].name;
                            dialog.text = listOfJSON.listOfJSON[indexRound].text;
                            pathImage = listOfJSON.listOfJSON[indexRound].image;
                            backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
                            indexRound++;
                            indexIssue = -1;
                            indexRoundChoise++;
                        }
                        else
                        {
                            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue1;
                            character.text = jsonIssue.listOfJSONIssue[indexIssue].name1;
                            
                            indexIssue++;
                        }
                    }
                    else if (alternative == 2)
                    {
                        if (jsonIssue.listOfJSONIssue[indexIssue + 1].issue1 == "")
                        {

                            indexRound++;
                            character.text = listOfJSON.listOfJSON[indexRound].name;
                            dialog.text = listOfJSON.listOfJSON[indexRound].text;
                            pathImage = listOfJSON.listOfJSON[indexRound].image;
                            indexRound++;
                            indexIssue = -1;
                            indexRoundChoise++;
                        }
                        else
                        {
                            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue2;
                            character.text = jsonIssue.listOfJSONIssue[indexIssue].name2;
                            
                            indexIssue++;
                        }
                    }
                    else if (alternative == 3)
                    {
                        if (jsonIssue.listOfJSONIssue[indexIssue + 1].issue1 == "")
                        {

                            indexRound++;
                            character.text = listOfJSON.listOfJSON[indexRound].name;
                            dialog.text = listOfJSON.listOfJSON[indexRound].text;
                            pathImage = listOfJSON.listOfJSON[indexRound].image;
                            indexRound++;
                            indexIssue = -1;
                            indexRoundChoise++;
                        }
                        else
                        {
                            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue3;
                            character.text = jsonIssue.listOfJSONIssue[indexIssue].name3;
                            
                            indexIssue++;
                        }
                    }
                    else if (alternative == 4)
                    {
                        if (jsonIssue.listOfJSONIssue[indexIssue + 1].issue1 == "")
                        {

                            indexRound++;
                            character.text = listOfJSON.listOfJSON[indexRound].name;
                            dialog.text = listOfJSON.listOfJSON[indexRound].text;
                            pathImage = listOfJSON.listOfJSON[indexRound].image;

                            indexRound++;
                            indexIssue = -1;
                            indexRoundChoise++;
                        }
                        else
                        {
                            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue4;
                            character.text = jsonIssue.listOfJSONIssue[indexIssue].name4;
                            
                            indexIssue++;
                        }
                    }
                }
                
            }
        }
    }
        void Button1()
        {
            then.SetActive(true);
            aaa.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            indexIssue++;
            alternative = 1;
            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue1;
            character.text = jsonIssue.listOfJSONIssue[indexIssue].name1;


    }
        void Button2()
        {
            then.SetActive(true);
            aaa.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            indexIssue++;
            alternative = 2;
            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue2;
            character.text = jsonIssue.listOfJSONIssue[indexIssue].name2;

    }
        void Button3()
        {
            then.SetActive(true);
            aaa.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            indexIssue++;
            alternative = 3;
            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue3; 
            character.text = jsonIssue.listOfJSONIssue[indexIssue].name3;

    }
        void Button4()
        {
            then.SetActive(true);
            aaa.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            indexIssue++;
            alternative = 4;
            dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue4;
            character.text = jsonIssue.listOfJSONIssue[indexIssue].name4;
    }
    }

