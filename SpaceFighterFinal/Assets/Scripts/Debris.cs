using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debris : MonoBehaviour
{
    GameObject SpaceFighter;
    readonly float R = 52.5f; // radius of SF
    readonly float r = 35f; // radius of small balls

    GameObject S;
    GameObject DH;

    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        SpaceFighter = GameObject.FindGameObjectsWithTag("spacefighter")[0];

        S = GameObject.Find("GameViewer/topHUD/S/Stext");
        DH = GameObject.Find("GameViewer/topHUD/DH/DHtext");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(SpaceFighter.transform.position, this.transform.position) <= R + r)
        {
            if (this.transform.position.y - SpaceFighter.transform.position.y >= (R + r) / Mathf.Sqrt(2))
            {
                if (flag)
                {
                    flag = false;

                    GameObject.Destroy(this.gameObject);

                    S.GetComponent<Text>().text = (int.Parse(S.GetComponent<Text>().text) + 5).ToString();
                    DH.GetComponent<Text>().text = (int.Parse(DH.GetComponent<Text>().text) + 1).ToString();
                }

            }
        }
    }
}
