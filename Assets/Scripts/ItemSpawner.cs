using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] ItemsData itemsKeeper;
    [SerializeField] private int maxItemsOnScene = 0;
    [SerializeField] private RectTransform roomZone = null;

    private Vector3[] cornersOfRoomZone = new Vector3[4];
    private GameObject[] items;

    private void Start()
    {
        roomZone.GetWorldCorners(cornersOfRoomZone);
        items = itemsKeeper.GetItems();

        Spawn();
    }

    public void Spawn()
    {
        foreach (GameObject item in items)
        {
            GameObject obj = Instantiate(item);
            float xPos = Random.Range(cornersOfRoomZone[0].x, cornersOfRoomZone[3].x);
            float yPos = Random.Range(cornersOfRoomZone[0].y, cornersOfRoomZone[1].y);
            obj.transform.position = new Vector3(xPos, yPos);
        }
    }
}
