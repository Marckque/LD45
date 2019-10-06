using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class SectionSituation : CustomUpdateUser
{
    public GameObject situationUI;

    float timeElapsed;
    float duration = 2f;

    public UnityAction OnSituationEnded;

    public void Initialise()
    {
        gameObject.SetActive(true);
        situationUI.SetActive(true);
        OnSituationEnded += End;
    }

    public void End()
    {
        situationUI.SetActive(false);
    }

    public override void CustomUpdate()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= duration)
        {
            OnSituationEnded();
        }
    }
}