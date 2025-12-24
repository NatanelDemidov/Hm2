using UnityEngine;
using Mirror;
public class GameManagerOfThisGame : NetworkManager
{
    [SerializeField] GameObject gameOverPrefab;
    public override void OnStartServer()
    {
        GameObject gameOver = Instantiate(gameOverPrefab);
        NetworkServer.Spawn(gameOver);
    }
}
