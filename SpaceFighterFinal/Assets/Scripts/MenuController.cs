using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject GameViewer;
    public GameObject GameController;
    public GameObject help_Window;
    public GameObject ack_Window;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Game_Start()
    {
        this.gameObject.SetActive(false);
        GameViewer.SetActive(true);
        GameController.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void helpWindow()
    {
        this.gameObject.SetActive(false);
        help_Window.SetActive(true);
    }

    public void ackWindow()
    {
        this.gameObject.SetActive(false);
        ack_Window.SetActive(true);
    }
}
