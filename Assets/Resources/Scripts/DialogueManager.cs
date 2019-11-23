using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    public int money = 0;
    private Story story;
    public Text textPrefab;
    public Button buttonPrefab;
    public bool talking = false;
    public bool flag = false;
    // Start is called before the first frame update
    public void PlayDialogue(string name)
    {
        talking = true;
        TextAsset inkJSON = Resources.Load<TextAsset>("Ink/" + name);
        story = new Story(inkJSON.text);
        story.BindExternalFunction("check_money", (string value) =>
        {
            int number = int.Parse(value);
            if(money > number)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        });
        refreshUI();
    }

    void refreshUI()
    {
        eraseUI();

        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = loadStoryChunk();
        storyText.transform.SetParent(this.transform, false);
        storyText.transform.position = new Vector3(0, 60);

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(this.transform, false);

            // Gets the text from the button prefab
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = choice.text;

            // Set listener
            choiceButton.onClick.AddListener(delegate
            {
                chooseStoryChoice(choice);
            });
        }
        if (story.currentChoices.Count == 0)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            choiceButton.transform.SetParent(this.transform, false);
            Text choiceText = choiceButton.GetComponentInChildren<Text>();
            choiceText.text = "Exit";
            choiceButton.onClick.AddListener(delegate
            {
                ExitStory();
            });
        }
    }
    void ExitStory()
    {
            if ((string)story.variablesState["flag"] == "true")
            {
                flag = true;
                Debug.Log("AAAAAAAAAAAAAAAAHHHHHHHHHHHHHHHHHHH");
            }
        if ((string)story.variablesState["item_purchase"] != "")
        {

            //giveItem((string)story.variablesState["item_purchase"])
            //money -= getItem((string)story.variablesState["item_purchase"]).value;
        }
        if ((string)story.variablesState["item_sell"] != "")
        {

            //removeItem((string)story.variablesState["item_sell"])
            //money += getItem((string)story.variablesState["item_sell"]).value *.75;
        }
        talking = false;
        eraseUI();
    }

    void eraseUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    string loadStoryChunk()
    {
        string text = "";
        text = story.ContinueMaximally();
        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        return text;
    }
}