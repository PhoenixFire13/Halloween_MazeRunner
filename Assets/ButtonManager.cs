using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    private PageNumber page;
    private Button button;
    private Text txt;
    private string[] pageText;

	// Use this for initialization
	void Start () {
        page = gameObject.GetComponentInParent<PageNumber>();
        button = gameObject.GetComponent<Button>();
        txt = button.GetComponentInParent<Text>();
        pageText = new string[3];
        pageText[0] = "\n\n\nControls: \n\nUse the WASD or arroy keys to control the player and navagate the maze";
        pageText[1] = "\n\nHeart Rate: \n\nYour character's heart rate is displayed at the bottom left hand corner.\nIf you're heart rate raises too high, you might die from heart attack.";
        pageText[2] = "Objective: \n\nFind the key on the third floor to open the exit\n\nExtra Objective:\n\nGo to the third level of the basement to find a hidden treasure, but beware, the basement is full of hidden dangers";
        //Debug print(txt);
        txt.text = pageText[page.getPageNum()];
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (button.CompareTag("Next"))
            button.onClick.AddListener(nextPage);
        if (button.CompareTag("Back"))
            button.onClick.AddListener(backPage);
        */
	}

    void nextPage ()
    {
        //pageNum++;
        page.increasePage();
        txt.text = pageText[page.getPageNum()];

        /*
        if (page.getPageNum() == pageMax)
        {
            button.gameObject.SetActive(false);
        }
        */

    }

    void backPage()
    {
        if (page.getPageNum() == 0)
        {
            SceneManager.LoadScene("GameMenu");
            return;
        }

        //button.gameObject.SetActive(true);
        //pageNum--;
        page.decreasePage();
        txt.text = pageText[page.getPageNum()];
    }
}
