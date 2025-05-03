using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerCarry : MonoBehaviour
{
    public GameEvent PickupTrash;
    public GameEvent DropTrashTrue;
    public GameEvent DropTrashFalse;


    private Trash nearbyTrash;
    private Trash carriedTrash;
    private TrashBin bin;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedTrash == null && nearbyTrash != null)
            {
                PickUpTrash(nearbyTrash);
            }
            else if (carriedTrash != null)
            {
                DropTrash(bin);
            }
        }
    }


    public void PickUpTrash(Trash trash)
    {
        carriedTrash = trash;
        trash.transform.SetParent(this.transform); // Trash playerga yopishadi
        trash.transform.localPosition = new Vector3(0, 1.2f, 0); // Player ustida ko‘rsatish
        PickupTrash.Raise();
    }

    public void DropTrash(TrashBin bin)
    {               
        if (carriedTrash.trashType == bin.acceptedType)
        {
            Debug.Log("Correctly sorted!");
            Destroy(carriedTrash.gameObject); // Axlat yo‘q qilinadi
            DropTrashTrue.Raise();
          
        }
        else
        {
            Debug.Log("Wrong bin!");          
            // Penalty yoki xato effekt
            DropTrashFalse.Raise();
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            nearbyTrash = other.GetComponent<Trash>();
        }
        else if (other.CompareTag("Bin"))
        {
            bin = other.GetComponent<TrashBin>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            if (nearbyTrash == other.GetComponent<Trash>())
            {
                nearbyTrash = null;
            }
        }
        else if (other.CompareTag("Bin"))
        {
            if (bin == other.GetComponent<Trash>())
            {
                bin = null;
            }            
        }
    }



}
