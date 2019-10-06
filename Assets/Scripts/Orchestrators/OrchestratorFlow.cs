using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

public enum FlowState
{
    Cinematic = 0,
    Situation = 1,
    WordSelection = 2,
    Speech = 3,
    OpponentSpeech = 4
};
  
public class OrchestratorFlow : MonoBehaviour
{
    [Header("Header")]
    public bool debug = true;

    [Header("States")]
    public FlowState defaultState;
    private FlowState currentState;

    public SectionCinematic cinematic;
    public SectionSituation situation;
    public SectionWordSelection wordSelection;
    public SectionSpeech speech;
    public SectionSpeech opponentSpeech;

    protected void Start()
    {
        currentState = defaultState;

        // Start intro cinematic
        if (!debug)
        {
            cinematic.PlayIntroduction();
        }
        else
        {
            SetCurrentStateToWordSelection();
        }

        // On word selection ending, make it so that we switch to switch
        situation.OnSituationEnded += SetCurrentStateToWordSelection;
        wordSelection.OnWordSelectionEnded += SetCurrentStateToSpeech;
        speech.OnSpeechEnded += SetCurrentStateToOpponentSpeech;
        opponentSpeech.OnSpeechEnded += SetCurrentStateToCinematic;
    }

    protected void Update()
    {
        switch (currentState)
        {
            case FlowState.Situation:
                situation.CustomUpdate();
                break;

            case FlowState.WordSelection:
                wordSelection.CustomUpdate();
                break;

            case FlowState.Speech:
                speech.CustomUpdate();
                break;

            case FlowState.OpponentSpeech:
                opponentSpeech.CustomUpdate();
                break;

            default:
                break;
        }
    }

    public void SetCurrentStateToCinematic()
    {
        currentState = FlowState.Cinematic;
    }

    public void SetCurrentStateToSituation()
    {
        currentState = FlowState.Situation;

        situation.gameObject.SetActive(true);
        situation.Initialise();
    }

    public void SetCurrentStateToWordSelection()
    {
        currentState = FlowState.WordSelection;

        wordSelection.gameObject.SetActive(true);
    }

    public void SetCurrentStateToSpeech()
    {
        currentState = FlowState.Speech;
    }

    public void SetCurrentStateToOpponentSpeech()
    {
        currentState = FlowState.OpponentSpeech;
    }

    private void OnDestroy()
    {
        situation.OnSituationEnded -= SetCurrentStateToWordSelection;
        wordSelection.OnWordSelectionEnded -= SetCurrentStateToSpeech;
        speech.OnSpeechEnded -= SetCurrentStateToOpponentSpeech;
        opponentSpeech.OnSpeechEnded -= SetCurrentStateToCinematic;
    }
}