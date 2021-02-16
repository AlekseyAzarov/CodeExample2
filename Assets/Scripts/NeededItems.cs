using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NeededItems : MonoBehaviour
{
    [SerializeField] private GameObject[] allNeededItems = null;
    [SerializeField] private ItemsData itemsKeeper;

    private int[] idsOfNeededItems;

    private void Start()
    {
        Sprite[] sprites = itemsKeeper.GetSpritesOfItems();

        int countOfNeededItems = 3;
        idsOfNeededItems = IdsOfNeededItems(countOfNeededItems);
        for (int i = 0; i < countOfNeededItems; i++)
        {
            allNeededItems[i].SetActive(true);
            allNeededItems[i].GetComponent<Image>().sprite = sprites[idsOfNeededItems[i]];
        }
    }

    public bool ItemEnteredBag(int id)
    {
        for (int i = 0; i < idsOfNeededItems.Length; i++)
        {
            if (idsOfNeededItems[i] == id)
            {
                return true;
            }
        }
        return false;
    }

    private int[] IdsOfNeededItems(int countOfNeededItems)
    {
        List<int> allIds = itemsKeeper.GetIdsOfItems();

        int[] ids = new int[countOfNeededItems];
        for (int i = 0; i < ids.Length; i++)
        {
            ids[i] = allIds[Random.Range(0, allIds.Count)];
            allIds.Remove(ids[i]);
        }

        return ids;
    }
}
