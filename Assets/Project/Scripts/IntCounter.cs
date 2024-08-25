using TMPro;
using UnityEngine;

public class IntCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private IntVariable value;

    private void Start()
    {
        value.OnChange.AddListener(UpdateCounter);
        UpdateCounter();
    }

    private void UpdateCounter()
    {
        text.text = value.GetValue().ToString();
    }
}