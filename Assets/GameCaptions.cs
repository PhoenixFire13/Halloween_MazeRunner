using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCaptions : MonoBehaviour {

    Text subtitles;
    string txt;
    int txtCount;

    public float nextLetterDelay;
    public float nextSentenceDelay;

    public static int guideCount;

    GameGuideText guide;

    IEnumerator Start()
    {
        subtitles = GetComponent<Text>();
        guide = GetComponentInChildren<GameGuideText>();
        subtitles.text = "";

        guideCount = 0;
        txtCount = 0;
        ChangeText();

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(LetterTyper());
    }

    IEnumerator LetterTyper()
    {
        foreach (char letter in txt.ToCharArray())
        {
            subtitles.text += letter;
            yield return new WaitForSeconds(nextLetterDelay);
        }

        txtCount++;
        if (txtCount <= 1)
        {
            StartCoroutine(NextSentence());
        }
        else
        {
            yield return new WaitForSeconds(nextSentenceDelay);
            ClearText();

            // placed here temporarily
            // set condition to when guideCount == 2 when more text are added
            yield return new WaitForSeconds(1f);
            guide.enabled = true;

            StopAllCoroutines();
        }
    }

    void ClearText()
    {
        subtitles.text = "";
    }

    IEnumerator NextSentence()
    {
        yield return new WaitForSeconds(nextSentenceDelay);
        ClearText();

        ChangeText();
        StartCoroutine(LetterTyper());
    }

    void ChangeText()
    {
        switch (txtCount)
        {
            case 0:
                txt = "So dark ... Maybe I should have brought a flashlight after all.";
                break;
            case 1:
                txt = "I should look around.\nMaybe I'll be able to find some sort of hint to the treasure.";
                guideCount++;
                break;
        }
    }
}
