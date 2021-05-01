using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Ink.Runtime;
using TMPro;
using UnityEditor;

public class InkManager : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;
    //Variables Declaring 
    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    [SerializeField]
    private Canvas canvas = null;
    public GameObject boxPrefab;
    // UI Prefabs
    [SerializeField]
    private TextMeshProUGUI textPrefab = null;
    [SerializeField]
    private Button buttonPrefab = null;


    void Awake()
    {
        // Remove the default message
        RemoveChildren();
        StartStory();
    }

    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        if (OnCreateStory != null) OnCreateStory(story);
        Bindfunctions(story);
        RefreshView();
    }

    private void Bindfunctions(Story story)
    {
        story.BindExternalFunction("change_background", (int index) =>
        {
            ChangeBackground(index);
        });
       
    }
    //THESE ARE LAMBDA EXPRESSIONS BASICALLY WE WOULD WRITE THEM THIS WAY 
    // private Add_character(int playerIndex, int position)
    //{ 
    //Debug.Log(string.Format("Character Requested with index of {0} and position {1}"));
    //}
    // story.BindExternalFunction("add_character", (int playerIndex, int position) => 
    // Add_character(int playerIndex, int position)
    //Same goes for the changing background function 
    private void ChangeBackground(int index)
    {
        BackgManager.instance.ChangeBackground(index,1);
        CharacterManager.instance.ClearActors();
    }
   
    private void Add_character(int playerIndex, int position)
    {
        CharacterManager.instance.GenerateCharacter(playerIndex, position);
    }
    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.ContinueMaximally();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!

            CreateContentView(text);
        }

        // Display all the choices, if there are any!7
        if (story.currentChoices.Count > 0)
        {
            // Display all the choices, if there are any!
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);

                });
            }
        }

        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate
            {
                StartStory();
            });
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);

        RefreshView();
    }

    // Creates a textbox showing the the line of text
    void CreateContentView(string text)
    {
        GameObject box = Instantiate(boxPrefab) as GameObject;
        //box = (GameObject)PrefabUtility.InstantiatePrefab(boxPrefab);
        box.transform.SetParent(canvas.transform, false);
        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
        storyText.text = text;
        storyText.transform.SetParent(box.transform, false);
        HorizontalLayoutGroup layoutGroup2 = box.GetComponent<HorizontalLayoutGroup>();
        layoutGroup2.childForceExpandHeight = false;
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
            // Creates the button from a prefab
            Button choice = Instantiate(buttonPrefab) as Button;
            choice.transform.SetParent(canvas.transform, false);

            // Gets the text from the button prefab
            Text choiceText = choice.GetComponentInChildren<Text>();
            choiceText.text = text;

            // Make the button expand to fit the text
            HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
            layoutGroup.childForceExpandHeight = false;
        return choice;
    }


    // Destroys all the children of this gameobject (all the UI)
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
           
                GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
            }
        }
    
}

