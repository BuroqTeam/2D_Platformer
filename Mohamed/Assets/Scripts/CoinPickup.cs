using ScriptableObjectArchitecture;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
   
    public GameEvent PickupCoin;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // faqat Player tegsa ishlasin
        if (other.CompareTag("Player"))
        {
            // score yoki coin counterni shu yerda oshirasiz
            // Masalan:
            // GameManager.Instance.AddCoins(value);

            // Hozircha oddiy log:
           
            PickupCoin.Raise();

            // Tangani yo‘q qilamiz
            Destroy(gameObject);
        }
    }
}
