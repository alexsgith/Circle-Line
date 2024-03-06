using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playResetButton;
    [SerializeField] private TMP_Text playResetText;
    [SerializeField] private CircleManager circleManager;
    public UIState currentState;

    public enum UIState
    {
        StartGameMenuState,
        ResetGameMenuState,
        GameState
    }

    private void OnEnable()
    {
        playResetButton.onClick.AddListener(OnClickPlayResetButton);
    }

    private void OnDisable()
    {
        playResetButton.onClick.RemoveListener(OnClickPlayResetButton);
    }

    private void OnClickPlayResetButton()
    {
        if (currentState != UIState.GameState)
        {
            ChangeState(UIState.GameState);
        }
    }

    public void ChangeState(UIState state)
    {
        switch (state)
        {
            case UIState.StartGameMenuState:
                playResetText.text = "Start Game";
                playResetButton.gameObject.SetActive(true);
                currentState = UIState.StartGameMenuState;
                break;
            case UIState.ResetGameMenuState:
                GameManager.isGameStarted = false;
                playResetText.text = "Reset Game";
                playResetButton.gameObject.SetActive(true);
                currentState = UIState.ResetGameMenuState;
                break;
            case UIState.GameState:
                GameManager.isGameStarted = true;
                circleManager.Spawn();
                playResetButton.gameObject.SetActive(false);
                currentState = UIState.GameState;
                break;
            default:
                Debug.Log("State not defined");
                break;
        }
    }
}
