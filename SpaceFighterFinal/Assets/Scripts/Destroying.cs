using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroying : MonoBehaviour
{
    public bool whether_destroy = false;
    public int index = 0;
    public int circle_index;

    public Transform[] ballsToDestroy;
    public GameObject R;
    public GameObject G;
    public GameObject B;
    public GameObject RGB;
    public GameObject S;
    public GameObject IPG;

    // Start is called before the first frame update
    void Start()
    {
        R = GameObject.Find("bottomHUD/R/Rtext");
        G = GameObject.Find("bottomHUD/G/Gtext");
        B = GameObject.Find("bottomHUD/B/Btext");
        RGB = GameObject.Find("bottomHUD/RGB/RGBtext");
        S = GameObject.Find("topHUD/S/Stext");
        IPG = GameObject.Find("topHUD/IPG/IPGtext");
    }

    // Update is called once per frame
    void Update()
    {
        if (whether_destroy)
        {
            try
            {
                if (Vector3.Distance(Circles.circles[circle_index].position, ballsToDestroy[index].position) <= 0.5f)
                {
                    string[] tags = new string[ballsToDestroy.Length];

                    for (int i = 0; i < tags.Length; i++) tags[i] = ballsToDestroy[i].tag;
                    

                    for (int i = 0; i < ballsToDestroy.Length; i++) GameObject.DestroyImmediate(ballsToDestroy[i].gameObject);

                    if (tags.Length == 5)
                    {
                        S.GetComponent<Text>().text = (int.Parse(S.GetComponent<Text>().text) + 25).ToString();
                        RGB.GetComponent<Text>().text = (int.Parse(RGB.GetComponent<Text>().text) + 1).ToString();
                        IPG.GetComponent<Text>().text = (int.Parse(IPG.GetComponent<Text>().text) + 2).ToString();

                        if (tags[3].Equals("red")) R.GetComponent<Text>().text = (int.Parse(R.GetComponent<Text>().text) + 1).ToString();
                        if (tags[3].Equals("blue")) B.GetComponent<Text>().text = (int.Parse(B.GetComponent<Text>().text) + 1).ToString();
                        if (tags[3].Equals("green")) G.GetComponent<Text>().text = (int.Parse(G.GetComponent<Text>().text) + 1).ToString();
                    }

                    else if (!tags[0].Equals(tags[1]))
                    {
                        S.GetComponent<Text>().text = (int.Parse(S.GetComponent<Text>().text) + 15).ToString();
                        RGB.GetComponent<Text>().text = (int.Parse(RGB.GetComponent<Text>().text) + 1).ToString();
                        IPG.GetComponent<Text>().text = (int.Parse(IPG.GetComponent<Text>().text) + 1).ToString();
                    }

                    else
                    {
                        if (tags[0].Equals("red")) R.GetComponent<Text>().text = (int.Parse(R.GetComponent<Text>().text) + 1).ToString();
                        if (tags[0].Equals("blue")) B.GetComponent<Text>().text = (int.Parse(B.GetComponent<Text>().text) + 1).ToString();
                        if (tags[0].Equals("green")) G.GetComponent<Text>().text = (int.Parse(G.GetComponent<Text>().text) + 1).ToString();

                        S.GetComponent<Text>().text = (int.Parse(S.GetComponent<Text>().text) + 10).ToString();
                        IPG.GetComponent<Text>().text = (int.Parse(IPG.GetComponent<Text>().text) + 1).ToString();
                    }
                    whether_destroy = false;
                }
            }
            catch
            {
                whether_destroy = false;
            }
        }
        Destroy(this.gameObject);
    }
}
