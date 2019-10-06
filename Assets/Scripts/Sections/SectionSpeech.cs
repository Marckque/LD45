using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.Playables;
using System.Collections.Generic;

public class SectionSpeech : CustomUpdateUser
{
    [Header("Opponent")]
    public bool isOpponentSpeech;
    public SectionSpeech opponentSpeech;
    [Range(1f, 5f)]
    public float slideDuration = 2f;
    private bool opponentCoroutine;

    [Header("Cinematic")]
    public PlayableDirector cinematic;

    [Header("Speeches Game Objects")]
    public Canvas[] speechesCanvas;
    public string[] allSpeeches;

    [Header("Possibles Speeches")]
    public Text[] speechesText;

    [Header("Score Related")]
    public PopularityScore popularityScore;
    public int[] speechesIndexes;
    public int[] validSpeeches;
    public int[] wrongSpeeches;

    private int currentSlideIndex;

    public UnityAction OnSpeechEnded;

    public void OnSpeechSectionStarting(int[] indexes)
    {
        speechesIndexes = indexes;

        speechesText[0].text = allSpeeches[indexes[0]];

        speechesText[1].text = allSpeeches[indexes[1]];
        speechesCanvas[1].gameObject.SetActive(false);

        speechesText[2].text = allSpeeches[indexes[2]];
        speechesCanvas[2].gameObject.SetActive(false);

        gameObject.SetActive(true);
    }

    public override void CustomUpdate()
    {
        if (isOpponentSpeech && !opponentCoroutine)
        {
            StartCoroutine(PlayOpponentSpeech());
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isOpponentSpeech)
            {
                SwitchToNextSpeechSlide();
            }
        }
    }

    private IEnumerator PlayOpponentSpeech()
    {
        opponentCoroutine = true;

        while (currentSlideIndex < speechesText.Length)
        {
            yield return new WaitForSeconds(slideDuration);
            SwitchToNextSpeechSlide();
        }

        opponentCoroutine = false;

        yield return null;
    }

    private void SwitchToNextSpeechSlide()
    {
        int previousIndex = currentSlideIndex;
        currentSlideIndex = Mathf.Clamp(currentSlideIndex + 1, 0, speechesText.Length);

        CalculateScore();

        if (currentSlideIndex >= speechesText.Length)
        {
            EndSpeech();
            return;
        }

        speechesCanvas[previousIndex].gameObject.SetActive(false);
        speechesCanvas[currentSlideIndex].gameObject.SetActive(true);
    }

    public void CalculateScore()
    {
        // Loop through all good/wrong speeches
        for (int i = 0; i < speechesIndexes.Length; i++)
        {
            for (int j = 0; j < validSpeeches.Length; j++)
            {
                // In case valid
                if (speechesIndexes[i] == validSpeeches[j])
                {
                    popularityScore.HighPopularityIncrement();
                    return;
                }
                
                // In case INvalid
                if (speechesIndexes[i] == wrongSpeeches[j])
                {
                    popularityScore.HighPopularityDecrement();
                    return;
                }
            }
        }

        // Else random choice because no time ; not by design.
        float mediumOrLow = Random.Range(0f, 1f);
        float moreOrLess = Random.Range(0f, 1f);
        if (mediumOrLow > 0.5f)
        {
            if (moreOrLess > 0.5f)
            {
                popularityScore.MediumPopularityIncrement();
            }
            else
            {
                popularityScore.MediumPopularityDecrement();
            }
        }
        else
        {
            if (moreOrLess > 0.5f)
            {
                popularityScore.LowPopularityIncrement();
            }
            else
            {
                popularityScore.LowPopularityDecrement();
            }
        }
    }

    public void ToggleSectionSpeechTo(bool value)
    {
        gameObject.SetActive(value);
    }

    private void EndSpeech()
    {
        if (OnSpeechEnded != null)
        {
            OnSpeechEnded.Invoke();
        }

        if (!isOpponentSpeech)
        {
            opponentSpeech.ToggleSectionSpeechTo(true);
        }
        else
        {
            cinematic.Play();
        }

        ToggleSectionSpeechTo(false);
    }
}