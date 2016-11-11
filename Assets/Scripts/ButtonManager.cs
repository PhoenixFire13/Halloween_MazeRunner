using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    private PageNumber page;
    private Button button;
    private Text txt;
    private string[] pageText;
    private string str;

    // Use this for initialization
    void Start()
    {
        page = gameObject.GetComponentInParent<PageNumber>();
        button = gameObject.GetComponent<Button>();
        txt = button.GetComponentInParent<Text>();

        pageText = new string[3];
        pageText[0] = "Controls:\n\nUse WASD or arrow keys to move";

        //Debug print(txt);
        txt.text = pageText[page.getPageNum()];
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (button.CompareTag("Next"))
            button.onClick.AddListener(nextPage);
        if (button.CompareTag("Back"))
            button.onClick.AddListener(backPage);
        */
    }

    void nextPage()
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
        }

        //button.gameObject.SetActive(true);
        //pageNum--;
        page.decreasePage();
        txt.text = pageText[page.getPageNum()];
    }
}