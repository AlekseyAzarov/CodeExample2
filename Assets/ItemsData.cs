using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/ItemsManager", order = 1)]
public class ItemsData : ScriptableObject
{
    [SerializeField] private GameObject[] items = null;

    public GameObject[] GetItems()
    {
        return items;
    }

    public Sprite[] GetSpritesOfItems()
    {
        Sprite[] sprites = new Sprite[items.Length];
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i] = items[i].GetComponent<SpriteRenderer>().sprite;
        }
        return sprites;
    }

    public List<int> GetIdsOfItems()
    {
        List<int> allIds = new List<int>();
        for (int i = 0; i < items.Length; i++)
        {
            allIds.Add(i);
        }
        return allIds;
    }
}
