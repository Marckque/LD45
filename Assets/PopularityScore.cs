using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopularityScore : MonoBehaviour
{
    [Header("Score")]
    public Text tScore;
    public float avatarPopularityTarget;
    private float avatarPopularity;

    public float opponentPopularityTarget;
    private float opponentPopularity;

    [Header("Score Update")]
    public float lowIncrement;
    public float mediumIncrement;
    public float highIncrement;

    public float scoreUpdateSpeed;

    protected void Start()
    {
        avatarPopularity = avatarPopularityTarget;
        opponentPopularity = opponentPopularityTarget;
    }

    protected void Update()
    {
        avatarPopularity = Mathf.MoveTowards(avatarPopularity, avatarPopularityTarget, scoreUpdateSpeed * Time.deltaTime);
        opponentPopularity = Mathf.MoveTowards(opponentPopularity, opponentPopularityTarget, scoreUpdateSpeed * Time.deltaTime);

        int avatarPop = (int)avatarPopularity;
        int opponentPop = (int)opponentPopularity;

        tScore.text = avatarPop.ToString() + " - " + opponentPop.ToString();
    }

    public void LowPopularityDecrement()
    {
        UpdatePopularity(-lowIncrement);
    }

    public void MediumPopularityDecrement()
    {
        UpdatePopularity(-mediumIncrement);
    }

    public void HighPopularityDecrement()
    {
        UpdatePopularity(-highIncrement);
    }

    public void LowPopularityIncrement()
    {
        UpdatePopularity(lowIncrement);
    }

    public void MediumPopularityIncrement()
    {
        UpdatePopularity(mediumIncrement);
    }

    public void HighPopularityIncrement()
    {
        UpdatePopularity(highIncrement);
    }

    private void UpdatePopularity(float inc)
    {
        avatarPopularityTarget = Mathf.Clamp(avatarPopularityTarget + inc, 0f, 100f);
        opponentPopularityTarget = Mathf.Clamp(opponentPopularityTarget - inc, 0f, 100f);
    }
}