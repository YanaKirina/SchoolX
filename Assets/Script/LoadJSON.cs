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
    private string pathChoise;
    private string pathIssue;

    private string Issue;
    private int JOPA;

    [SerializeField]
    private Image backgroundImage;

    public int indexRound = 16;
    int indexRoundChoise = 0;
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
    GameObject back;

    void Start()
    {
        path = Application.streamingAssetsPath + "/Scene.json";
        string jsonData = File.ReadAllText(path);
        listOfJSON.listOfJSON = JsonConvert.DeserializeObject<List<JsonFile>>(jsonData);

        pathChoise = Application.streamingAssetsPath + "/Choise.json";
        string jsonDataChoise = File.ReadAllText(pathChoise);
        jsonListChoise.listOfJSONChoise = JsonConvert.DeserializeObject<List<JsonFileChoise>>(jsonDataChoise);
    }

    void Update()
    {
        if (listOfJSON.listOfJSON[indexRound].condition != "No")
        {
            character.text = listOfJSON.listOfJSON[indexRound].name;
            dialog.text = listOfJSON.listOfJSON[indexRound].text;
            pathImage = listOfJSON.listOfJSON[indexRound].image;
            backgroundImage.sprite = Resources.Load<Sprite>("Background/" + pathImage);
        }
        else
        {
            pathIssue = Application.streamingAssetsPath + "/Choise" + indexRoundChoise + ".json";
            string jsonDataIssue = File.ReadAllText(pathIssue);
            jsonIssue.listOfJSONIssue = JsonConvert.DeserializeObject<List<JsonIssue>>(jsonDataIssue);

            if (indexIssue == -1)
            {
                then.SetActive(false);
                back.SetActive(false);
                button1.SetActive(true);
                button2.SetActive(true);
                if (jsonListChoise.listOfJSONChoise[indexRoundChoise].quantity == 3)
                {
                    button3.SetActive(true);
                }
                else if (jsonListChoise.listOfJSONChoise[indexRoundChoise].quantity == 4)
                {
                    button3.SetActive(true);
                    button4.SetActive(true);
                }
                
                
                character.text = " ";
                dialog.text = " ";
                Text text1 = button1.transform.GetChild(0).GetComponent<Text>();
                text1.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise1;
                Text text2 = button2.transform.GetChild(0).GetComponent<Text>();
                text2.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise2;
                Text text3 = button3.transform.GetChild(0).GetComponent<Text>();
                text3.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise3;
                Text text4 = button4.transform.GetChild(0).GetComponent<Text>();
                text4.text = jsonListChoise.listOfJSONChoise[indexRoundChoise].choise4;

            }
            else if (indexIssue == jsonIssue.listOfJSONIssue.Count)
            {
                indexRound++;
                indexIssue = -1;
                indexRoundChoise++;
            }
            else if (indexIssue < jsonIssue.listOfJSONIssue.Count)
            {
                if (JOPA == 1)
                {
                    if (jsonIssue.listOfJSONIssue[indexIssue].issue1 == "") 
                    {
                        indexIssue = jsonIssue.listOfJSONIssue.Count;
                    }
                    dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue1;
                }
                else if (JOPA == 2)
                {
                    if (jsonIssue.listOfJSONIssue[indexIssue].issue2 == "")
                    {
                        indexIssue = jsonIssue.listOfJSONIssue.Count;
                    }
                    dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue2;
                }
                else if(JOPA == 3)
                {
                    if (jsonIssue.listOfJSONIssue[indexIssue].issue3 == "")
                    {
                        indexIssue = jsonIssue.listOfJSONIssue.Count;
                    }
                    dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue3;
                }
                else if(JOPA == 4)
                {
                    if (jsonIssue.listOfJSONIssue[indexIssue].issue4 == "")
                    {
                        indexIssue = jsonIssue.listOfJSONIssue.Count;
                    }
                    dialog.text = jsonIssue.listOfJSONIssue[indexIssue].issue4;
                }
            }
        }


    }
    //public void ButtonBack()
    //{
    //    if (indexRound > 0)
    //    {
            
    //        if (listOfJSON.listOfJSON[indexRound].condition != "No")
    //        {
    //            indexRound--;
    //        }
    //        else
    //        {
    //            if (indexIssue > 0)
    //            {
    //                indexIssue--;
    //            }
    //            else
    //            {
    //                back.SetActive(false);
    //            }
                
    //        }
    //    }
    //}
    public void ButtonThen()
    {
        if (indexRound < listOfJSON.listOfJSON.Count)
        {
            
            if (listOfJSON.listOfJSON[indexRound].condition == "No")
            {
                if (indexIssue == -1)
                {
                    
                }
                else
                {
                    indexIssue++;
                    back.SetActive(true);
                }
                
            }
            else
            {
                indexRound++;
                back.SetActive(true);
            }
        }
    }
    public void Button1()
    {
        then.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        indexIssue++;
        JOPA = 1;

    }
    public void Button2()
    {
        then.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        indexIssue++;
        JOPA = 2;

    }
    public void Button3()
    {
        then.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        indexIssue++;
        JOPA = 3;

    }
    public void Button4()
    {
        then.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        indexIssue++;
        JOPA = 4;

    }
}
