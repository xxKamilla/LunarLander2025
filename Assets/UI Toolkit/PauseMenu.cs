using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool EscPressed = false;
    public bool GamePause = false;

    //private VisualElement _pauseMenuFrame;
    private Button _continueButton;
    private Button _mainmenuButton;
    private Button _quitButton;
    private Button _optionsButton;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        _continueButton = root.Q<Button>("ContinueButton");
        _mainmenuButton = root.Q<Button>("MainMenuButton");
        _quitButton = root.Q<Button>("QuitButton");
        _optionsButton = root.Q<Button>("OptionsButton");
        //_pauseMenuFrame = root.Q<VisualElement>("Frame")
        
        //_pauseMenuFrame.style.display = DisplayStyle.None;
        _continueButton.clicked += OnContinueButtonClick;
        _mainmenuButton.clicked += OnMainMenuButtonClick;
        _quitButton.clicked += OnQuitButtonclick;
        _optionsButton.clicked += OnOptionsButtonClick;

    }

    // Update is called once per frame
    void Update()
    {
        EscPressed = Input.GetKeyDown(KeyCode.Escape);

        if (EscPressed)
        {
            if (GamePause)
            {
                Debug.Log("Game is now unpaused");
                Time.timeScale = 1;
                GamePause = false;
                //_pauseMenuFrame.style.display = DisplayStyle.None;
            }

            else
            {
                Debug.Log("You are now Paused");
                Time.timeScale = 0;
                GamePause = true;
                //_pauseMenuFrame.style.display = DisplayStyle.Flex;
            }
        }
    }



    private void OnContinueButtonClick()
    {
        Debug.Log("Game is now unpaused");
        Time.timeScale = 1;
        GamePause = false;
        //_pauseMenuFrame.style.display = DisplayStyle.None;
    }

    private void OnOptionsButtonClick()

    {

    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Back to main menu");
    }

    private void OnQuitButtonclick()
    {
        Debug.Log("You have clicked Quit");
        Application.Quit();
    }
}
