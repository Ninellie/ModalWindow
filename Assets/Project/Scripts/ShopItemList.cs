using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShopItemList : ScriptableObject
{
    [SerializeField] private List<ShopItemProperties> items;
    
    public List<ShopItemProperties> Items => items;
}