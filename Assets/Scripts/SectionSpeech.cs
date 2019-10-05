using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectionSpeech : CustomUpdateUser
{
    public Text[] speechesText;
    public string[] allSpeeches;

    public void OnSpeechSectionStarting(int[] indexes)
    {
        speechesText[0].text = allSpeeches[indexes[0]];
        speechesText[1].text = allSpeeches[indexes[1]];
        speechesText[2].text = allSpeeches[indexes[2]];
    }

    public override void CustomUpdate()
    {
        
    }
}