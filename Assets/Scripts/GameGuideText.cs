using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuideText : MonoBehaviour
{
    Text instructions;
    string txt;
    int count;

    void Start()
    {
        instructions = GetComponent<Text>();

        count = GameCaptions.guideCount;
        SetText();

        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        instructions.text = txt;

        yield return new WaitForSeconds(5f);
        ClearText();
    }

    void ClearText()
    {
        instructions.text = "";
    }

    void SetText()
    {
        switch (count)
        {
            case 1:
                txt = "Look around for hints to the treasure";
                break;
        }
    }
}
