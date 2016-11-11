using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroSubtitles : MonoBehaviour {

    Animator anim;
    Text subtitles;
    string txt;
    int count;

    public float nextLetterDelay;
    public float nextSentenceDelay;
    public static bool introEnded = false;

    GameCaptions captions;

	IEnumerator Start () {
        anim = GetComponentInParent<Animator>();
        captions = GetComponent<GameCaptions>();
        subtitles = GetComponent<Text>();
        subtitles.text = "";

        // set initial text
        count = 0;
        ChangeText();

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(LetterTyper());
	}
	
	IEnumerator LetterTyper() {
        foreach (char letter in txt.ToCharArray()) {
            subtitles.text += letter;
            yield return new WaitForSeconds(nextLetterDelay);
        }

        count++;
        if (count <= 3)
        {
            StartCoroutine(NextSentence());
        }
        else
        {
            yield return new WaitForSeconds(3f);
            introEnded = true;
            ClearText();

            StartCoroutine(EndLoadingScene());
            anim.SetTrigger("EndCutScene");
        }
    }

    IEnumerator NextSentence()
    {
        yield return new WaitForSeconds(nextSentenceDelay);
        ClearText();

        ChangeText();
        StartCoroutine(LetterTyper());
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
                txt = "So this is the haunted house everyone's been talking about... \n It's creepier than I thought.";
                break;
            case 1:
                txt = "The gates are opened. It's like the house is inviting me in.";
                break;
            case 2:
                txt = "The treasure must be inside, I just know it... I have to get it.";
                break;
            case 3:
                txt = "Haunted house or not, I'll find out once I go in.";
                break;
        }
    }

    IEnumerator EndLoadingScene()
    {
        yield return new WaitForSeconds(5f);

        if (GameManager.mazeGenerated)
        {
            anim.SetTrigger("MazeGenerated");
            ActivateCaptions();
        }

        StartCoroutine(EndLoadingScene());
    }

    void ActivateCaptions()
    {
        captions.enabled = true;
        StopAllCoroutines();
    }
}
