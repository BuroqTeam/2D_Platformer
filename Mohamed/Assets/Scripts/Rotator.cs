using DG.Tweening;
using UnityEngine;


public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
