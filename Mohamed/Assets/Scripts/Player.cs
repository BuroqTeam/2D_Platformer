using ScriptableObjectArchitecture;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement), typeof(PlayerCarry))]
public class Player : MonoBehaviour
{
   
   
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerCarry playerCarry;

    public bool CanMove { get; private set; } = true;


    private void Start()
    {                
        playerMovement = GetComponent<PlayerMovement>();
        playerCarry = GetComponent<PlayerCarry>();
    }

    private void Update()
    {
        if (!CanMove)
        {            
            return; // stop all movement logic
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        playerMovement.Move(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();           
        }
    }

    public void EnableMovement() => CanMove = true;
    public void DisableMovement() => CanMove = false;



}
