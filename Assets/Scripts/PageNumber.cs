<<<<<<< HEAD:Assets/Scripts/PageNumber.cs
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PageNumber : MonoBehaviour {

    private int pageNum;
    public int pageMax;
    private Button[] buttons;

	// Use this for initialization
	void Start () {
        pageNum = 0;
        pageMax--;
        buttons = gameObject.GetComponentsInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getPageNum()
    {
        return pageNum;
    }

    public void increasePage()
    {
        pageNum++;
        if (pageNum == pageMax)
        {
            buttons[0].gameObject.SetActive(false);
        }
    }

    public void decreasePage()
    {
        pageNum--;
        //debug print(buttons[0].gameObject);
        buttons[0].gameObject.SetActive(true);
    }
}
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PageNumber : MonoBehaviour
{

    private int pageNum;
    public int pageMax;
    private Button[] buttons;

    // Use this for initialization
    void Start()
    {
        pageNum = 0;
        pageMax--;
        buttons = gameObject.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getPageNum()
    {
        return pageNum;
    }

    public void increasePage()
    {
        pageNum++;
        if (pageNum == pageMax)
        {
            buttons[0].gameObject.SetActive(false);
        }
    }

    public void decreasePage()
    {
        pageNum--;
        //debug print(buttons[0].gameObject);
        buttons[0].gameObject.SetActive(true);
    }
}
>>>>>>> origin/master:Assets/Scripts/PageNumber.cs
