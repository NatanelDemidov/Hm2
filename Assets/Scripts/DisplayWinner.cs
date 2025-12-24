using UnityEngine;
using Mirror;
using TMPro;
public class DisplayWinner : NetworkBehaviour
{
    [SerializeField] TMP_Text winnerText;
    [SerializeField] GameObject canvas;
    void Start()
    {
        WinnerShow.ClienOnGameOver += DisplayTheWinner;
    }
    private void OnDestroy()
    {
        WinnerShow.ClienOnGameOver -= DisplayTheWinner;
    }
    void DisplayTheWinner(string winner)
    {
        canvas.SetActive(true);
        winnerText.text = winner;   
    }
}
