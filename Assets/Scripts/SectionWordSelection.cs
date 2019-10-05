using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
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
    public SectionSpeech speech;

    [Header("Words")]
    public string[] allWords;

    [Header("Colors")]
    public Color selectedColor;
    public Color unselectedColor;

    private Text[] allTexts;
    private Button[] allButtons;

    private List<int> selectedWordsIndexes = new List<int>();

    private void Start()
    {
        OnWordSelectionStarting();
        InitialiseVariables();

        // Make it so that the validate button does more things
        action += ActivateSpeech;

        // Activates the speech
        validateButton.GetComponent<Button>().onClick.AddListener(action);
    }

    UnityAction action;

    private void ActivateSpeech()
    {
        gameObject.SetActive(false);
        speech.OnSpeechSectionStarting(selectedWordsIndexes.ToArray());
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

    public void UpdateWordList(int index)
    {
        // Add / remove a word
        if (selectedWordsIndexes.Contains(index))
        {
            RemoveWord(index);
        }
        else
        {
            AddWord(index);
        }

        // Update UI
        validateButton.gameObject.SetActive(selectedWordsIndexes.Count >= amountOfWordsToPick);
    }

    private void AddWord(int index)
    {
        if (selectedWordsIndexes.Count >= amountOfWordsToPick)
        {
            return;
        }

        selectedWordsIndexes.Add(index);
        allButtons[index].image.color = selectedColor;
    }

    private void RemoveWord(int index)
    {
        allButtons[index].image.color = unselectedColor;
        selectedWordsIndexes.Remove(index);
    }

    public override void CustomUpdate()
    {
        
    }
}