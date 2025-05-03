using UnityEngine;


[RequireComponent(typeof(PlayerMovement), typeof(PlayerCarry))]
public class Player : MonoBehaviour
{
   
   
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerCarry playerCarry;

   

    private void Start()
    {                
        playerMovement = GetComponent<PlayerMovement>();
        playerCarry = GetComponent<PlayerCarry>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerMovement.Move(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }
    }


   
}
