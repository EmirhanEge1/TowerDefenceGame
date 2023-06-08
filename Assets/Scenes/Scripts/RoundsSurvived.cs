using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoundsSurvived : MonoBehaviour
{
    public Text roundsCount;
    void OnEnable()
    {

        roundsCount.text = PlayerStats.rounds.ToString();
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText ()
    {
        roundsCount.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.rounds)
        {
            round++;
            roundsCount.text = round.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }

}
