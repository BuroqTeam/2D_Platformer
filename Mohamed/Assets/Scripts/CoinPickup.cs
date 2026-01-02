using ScriptableObjectArchitecture;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
   
    public GameEvent PickupCoin;
    public IntReference CoinCount;
    public GameObject particlePrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // faqat Player tegsa ishlasin
        if (other.CompareTag("Player"))
        {
            // score yoki coin counterni shu yerda oshirasiz
            // Masalan:
            // GameManager.Instance.AddCoins(value);

            // Hozircha oddiy log:
            CoinCount.Value++;
            PickupCoin.Raise();
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
            // Tangani yo‘q qilamiz
            Destroy(gameObject);
        }
    }
}
