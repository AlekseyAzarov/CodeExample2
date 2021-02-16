using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private ItemsData itemsData;
    [SerializeField] private int id;

    private enum State { OutOfBag, Moving, Stopped, InBag}
    private State currentState = State.OutOfBag;
    private bool inBag;

    private void OnMouseDrag()
    {
        if (currentState != State.InBag)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentState = State.Moving;
        }
    }

    private void OnMouseUp()
    {
        currentState = inBag == false ? State.Stopped : State.InBag;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<NeededItems>())
        {
            inBag = collision.GetComponent<NeededItems>().ItemEnteredBag(id);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<NeededItems>())
        {
            inBag = false;
        }
    }
}
