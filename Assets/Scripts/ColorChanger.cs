using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{

    public Color[] colors;
    public float speed;
    private Text txt;
    private Color currentColor;
    private float t;
    private int iteration;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.color = colors[0];
        currentColor = colors[0];
        t = 0;
        iteration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Beginning Time: " + Mathf.PingPong(Time.time, 1f));
        //txt.color = Color.Lerp(colors[0], colors[1], Mathf.PingPong(Time.time / speed, 1f));
        //Debug.Log("Ending Time: " + Mathf.PingPong(Time.time, 1f));
        if (currentColor == colors[iteration])
        {
            t += Time.deltaTime / speed;
            if (t > 1f)
                t = 1f;
            txt.color = Color.Lerp(colors[iteration], colors[(iteration + 1) % colors.Length], t);
            if (txt.color == colors[(iteration + 1) % colors.Length])
            {
                t = 0f;
                currentColor = colors[(iteration + 1) % colors.Length];
                iteration = (iteration + 1) % colors.Length;
            }
        }
        /*
        if (currentColor == colors[1])
        {
            t += Time.deltaTime / speed;
            if (t > 1f)
                t = 1f;
            txt.color = Color.Lerp(colors[1], colors[2], t);
            if (txt.color == colors[2])
            {
                t = 0f;
                currentColor = colors[2];
            }
        }
            
        if (currentColor == colors[2])
        {
            t += Time.deltaTime / speed;
            if (t > 1f)
                t = 1f;
            txt.color = Color.Lerp(colors[2], colors[0], t);
            if (txt.color == colors[0])
            {
                t = 0f;
                currentColor = colors[0];
            }
        }
        */

    }
}