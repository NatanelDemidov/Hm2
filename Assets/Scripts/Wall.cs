using System;
using UnityEngine;
using Mirror;
public class Wall : NetworkBehaviour
{
    public static event Action<Player> OnPlayerCollided;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnPlayerCollided?.Invoke(collision.gameObject.GetComponent<Player>());           
        }
    }
}
