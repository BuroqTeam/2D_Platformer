using ScriptableObjectArchitecture;
using UnityEngine;

public class SchoolGateTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public GameEvent PopUpEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player entered the school gate!");
            OnPlayerEnterSchool(other.gameObject);
        }
    }

    private void OnPlayerEnterSchool(GameObject player)
    {
        PopUpEvent.Raise();
        // TODO: Call popup, load scene, play animation, etc.
        // Example:
        // UIManager.Instance.ShowSchoolPopup();
    }
}
