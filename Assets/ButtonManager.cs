using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    private PageNumber page;
    private Button button;
    private Text txt;
    public string[] pageText;

	// Use this for initialization
	void Start () {
        page = gameObject.GetComponentInParent<PageNumber>();
        button = gameObject.GetComponent<Button>();
        txt = button.GetComponentInParent<Text>();
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
            EditorSceneManager.LoadScene("GameManager");
        }

        //button.gameObject.SetActive(true);
        //pageNum--;
        page.decreasePage();
        txt.text = pageText[page.getPageNum()];
    }
}
