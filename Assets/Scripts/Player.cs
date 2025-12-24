using UnityEngine;
using Mirror;
public class Player : NetworkBehaviour
{
    [SyncVar] public string name1;
    [SerializeField] int speed;
    Rigidbody rb;
    public static event System.Action<Player> OnPlayerEnter;
    public static event System.Action<Player> OnPlayerExit;
    private void Start()
    {
        name1 = connectionToClient.connectionId.ToString();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public override void OnStartServer()
    {
        OnPlayerEnter?.Invoke(this); 
    }
    private void Update()
    {
        if (isLocalPlayer)
        {
            rb.AddForce(Vector3.forward * Input.GetAxis("Horizontal") * speed, ForceMode.Acceleration);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("BadThing"))
        {
            OnPlayerExit?.Invoke(this);
            NetworkServer.Destroy(gameObject);
        }
    }
    
}
