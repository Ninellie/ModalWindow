using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ShopItemElement : MonoBehaviour
{
    [SerializeField] private ShopItemProperties properties;
    
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text price;
    [SerializeField] private Image iconImage;
    [SerializeField] private Button button;
    [SerializeField] private Image flapPanelImage;
    
    public ShopItemProperties Properties => properties;
    public UnityEvent<int> OnBuy { get; } = new();
    
    public void Initiate(ShopItemProperties itemProperties)
    {
        properties = itemProperties;
        
        title.text = itemProperties.Title;
        description.text = itemProperties.Description;
        price.text = itemProperties.Price.ToString();
        iconImage.sprite = itemProperties.Icon;
        
        button.onClick.AddListener(Buy);
    }
    
    public void SetAvailable()
    {
        var color = Color.black;
        color.a = 0f;
        
        flapPanelImage.color = color;
        flapPanelImage.enabled = false;
        button.interactable = true;
    }

    public void SetUnavailable()
    {
        var color = Color.black;
        color.a = 0.5f;
        
        flapPanelImage.color = color;
        flapPanelImage.enabled = true;
        button.interactable = false;
    }

    private void Buy()
    {
        OnBuy.Invoke(-properties.Price);
    }
}