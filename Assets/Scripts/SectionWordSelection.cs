using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionWordSelection : CustomUpdateUser
{
    public bool debug; // to remove

    public Transform root;

    [Range(1, 4)]
    public int amountOfWordsToPick = 3;
    private int currentAmountOfWordsPicked;

    public CanvasGroup wordSelectionUI;

    [Header("Validate Button")]
    public GameObject validateButton;

    [Header("Words")]
    public string[] allWords;

    [Header("Colors")]
    public Color selectedColor;
    public Color unselectedColor;

    private Text[] allTexts;
    public List<string> selectedWords;

    private Button[] allButtons;
    public List<Button> selectedWordButtons;

    private void Start()
    {
        OnWordSelectionStarting();
        InitialiseVariables();
    }

    private void InitialiseVariables()
    {
        int childrenCount = root.childCount;

        allButtons = new Button[childrenCount];
        allTexts = new Text[childrenCount];

        for (int i = 0; i < childrenCount; i++)
        {
            allButtons[i] = root.GetChild(i).GetComponent<Button>();

            allTexts[i] = root.GetChild(i).GetComponentInChildren<Text>();
            allTexts[i].text = allWords[i];
        }
    }

    public void Update() // to remove
    {
        if (debug)
        {
            CustomUpdate();
        }
    }

    public void OnWordSelectionStarting()
    {
        wordSelectionUI.alpha = 1f;
    }

    public void OnWordSelectionEnding()
    {
        wordSelectionUI.alpha = 0f;
    }

    public void UpdateWordList(Text textComponent)
    {
        string t = textComponent.text;

        // Add / remove a word
        if (selectedWords.Contains(t))
        {
            RemoveWord(t);
        }
        else
        {
            AddWord(t);
        }

        // Update UI
        validateButton.gameObject.SetActive(selectedWordButtons.Count >= amountOfWordsToPick);
    }

    private void AddWord(string word)
    {
        if (selectedWordButtons.Count >= amountOfWordsToPick)
        {
            return;
        }

        foreach (Button b in allButtons)
        {
            if (b.GetComponentInChildren<Text>().text == word)
            {
                selectedWordButtons.Add(b);
            }
        }

        foreach (Button b in selectedWordButtons)
        {
            b.image.color = selectedColor;
        }

        selectedWords.Add(word);
    }

    private void RemoveWord(string word)
    {
        selectedWords.Remove(word);

        foreach (Button b in allButtons)
        {
            if (b.GetComponentInChildren<Text>().text == word)
            {
                selectedWordButtons.Remove(b);
                b.image.color = unselectedColor;
            }
        }
    }

    public override void CustomUpdate()
    {
        
    }
}