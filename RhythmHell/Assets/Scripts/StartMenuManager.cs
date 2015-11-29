using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour {

    public Button startButton;
    public Button helpButton;
    public Button backButton;
    public Text helpText;
    public SpriteRenderer title;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /***
     * Event triggered when 'Start' button is clicked
     * Loads Level 1 of the current build
    ***/
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    /***
     * Event triggered when 'Help' button is clicked
     * Hides the 'Start' and 'Help' buttons
     * Shows Help text and 'Back' button
    ***/
    public void ShowHelp()
    {
        // Hide start and help buttons, and game title
        startButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        // Show help text and back button
        helpText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    /***
     * Event triggered when 'Back' button is clicked
     * Hides the Help text and 'Back' button
     * Shows 'Help' and 'Start' buttons
    ***/
    public void HideHelp()
    {
        // Show start and help buttons, and game title
        startButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
        // Hide help text and back button
        helpText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
}
