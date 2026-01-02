using DG.Tweening;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text CoinCountText;
    public IntReference CoinCount;

    private void Awake()
    {
        CoinCount.Value = 0;
    }





    // Update is called once per frame
    void Update()
    {
        CoinCountText.text = CoinCount.Value.ToString();
    }
}
