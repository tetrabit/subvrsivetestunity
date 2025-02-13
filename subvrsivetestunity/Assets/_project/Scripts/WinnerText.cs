using System;
using UnityEngine;
using TMPro;

public class WinnerText : MonoBehaviour
{
    private const string WINNER_TEXT_BEGINNING = "WINNER: ";

    [SerializeField]
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text.text = WINNER_TEXT_BEGINNING;
    }

    private void OnEnable()
    {
        Events.Winner += OnWinnerText;
    }

    private void OnDisable()
    {
        Events.Winner -= OnWinnerText;
    }

    private void OnWinnerText(string text)
    {
        _text.text = WINNER_TEXT_BEGINNING + text;
    }

    public static class Events
    {

        public static event Action<string> Winner;

        public static void RaiseWinner(string winner)
        {
            Winner?.Invoke(winner);
        }
    }
}
