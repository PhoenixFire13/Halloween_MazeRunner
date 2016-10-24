using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameCaptions : MonoBehaviour {

    Animator anim;
    Text subtitles;
    string txt;
    int count;

    public float nextLetterDelay;
    public float nextSentenceDelay;

    IEnumerator Start()
    {
        anim = GetComponentInParent<Animator>();
        subtitles = GetComponent<Text>();
        subtitles.text = "";

        // set initial text
        count = 0;
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

        yield return new WaitForSeconds(2f);
        ClearText();
    }

    void ClearText()
    {
        subtitles.text = "";
    }

    // changes text according to sentence count
    void ChangeText()
    {
        switch (count)
        {
            case 0:
                txt = "So dark ... Maybe I should have brought a flashlight after all.";
                break;
        }
    }
}
