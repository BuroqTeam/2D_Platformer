using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text CoinCountText;
    public IntReference CoinCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountText.text = CoinCount.Value.ToString();


    }
}
