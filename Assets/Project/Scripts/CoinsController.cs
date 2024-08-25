using UnityEngine;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private IntVariable coins;
    [SerializeField] private int initialValue;
    [SerializeField] private bool setOnStart;

    private void Start()
    {
        if (setOnStart)
        { 
            SetCoinsToInitialValue();   
        }
    }

    private void SetCoinsToInitialValue()
    {
        coins.SetValue(initialValue);
    }
}