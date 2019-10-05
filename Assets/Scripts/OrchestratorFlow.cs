using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

public enum FlowState
{
    Cinematic = 0,
    Situation = 1,
    SelectWords = 2,
    Speech = 3,
    OpponentSpeech = 4
};
  
public class OrchestratorFlow : MonoBehaviour
{
    [Header("States")]
    public FlowState currentState;

    public SectionCinematic cinematic;
    public SectionWordSelection wordSelection;
    public SectionSpeech speech;

    protected void Start()
    {
        cinematic.PlayIntroduction();
    }

    protected void Update()
    {
        switch (currentState)
        {
            case FlowState.SelectWords:
                wordSelection.CustomUpdate();
                break;

            case FlowState.Speech:
                speech.CustomUpdate();
                break;

            default:
                break;
        }
    }

    public void SetCurrentStateTo(FlowState newState)
    {
        currentState = newState;
    }
}