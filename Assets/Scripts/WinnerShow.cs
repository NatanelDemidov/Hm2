using UnityEngine;
using System.Collections.Generic;
using Mirror;
using System;
public class WinnerShow : NetworkBehaviour
{
    public List<Player> players = new List<Player>();
    string winner;
    public static event Action<string> ClienOnGameOver;
    void SetWinner(Player loser)
    {
        players.Remove(loser);
    }
    [ClientRpc]
    void RpcGameOver(string winner)
    {
        ClienOnGameOver?.Invoke(winner);
    }
    public override void OnStartServer()
    {
        Wall.OnPlayerCollided += SetWinner;
        Player.OnPlayerEnter += ServerHandlePlayerSpawn;
        Player.OnPlayerExit += ServerHandlePlayerDispawn;
    }
    public override void OnStopServer()
    {
        Player.OnPlayerEnter -= ServerHandlePlayerSpawn;
        Player.OnPlayerExit -= ServerHandlePlayerDispawn;
    }
    void ServerHandlePlayerSpawn(Player p)
    {
        players.Add(p);
    }
    void ServerHandlePlayerDispawn(Player p)
    {
        players.Remove(p);
        if (players.Count == 1)
        {
            winner = players[0].name1;
            RpcGameOver(winner);
        }
        
    }
}
