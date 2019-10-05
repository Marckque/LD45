using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Collections.Generic;

public class SectionCinematic : MonoBehaviour
{
    public PlayableDirector introduction;

    public void PlayIntroduction()
    {
        introduction.Play();
    }
}