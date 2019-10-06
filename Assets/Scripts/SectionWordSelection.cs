using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SectionWordSelection : CustomUpdateUser
{
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

    public UnityAction OnWordSelectionEnded;

    private void Start()
    {
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

    private void ActivateSpeech()
    {
        
    }

    public void OnWordSelectionStarting()
    {
        
    }

    public void OnWordSelectionEnding()
    {
        // Activate Speech
        speech.OnSpeechSectionStarting(selectedWordsIndexes.ToArray());
        speech.ToggleSectionSpeechTo(true);

        // Deactivate Word Selection
        gameObject.SetActive(false);
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

    public void OnDestroy()
    {
        OnWordSelectionEnded -= ActivateSpeech;
    }
}