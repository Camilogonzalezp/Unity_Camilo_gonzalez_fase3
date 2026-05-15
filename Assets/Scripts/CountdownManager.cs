using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public static bool countdownFinished = false;

    IEnumerator Start()
    {
        countdownFinished = false;

        Time.timeScale = 0f;

        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "START";

        Time.timeScale = 1f;
        countdownFinished = true;

        yield return new WaitForSecondsRealtime(1f);

        countdownText.gameObject.SetActive(false);
    }
}