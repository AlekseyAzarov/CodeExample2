using UnityEngine;
using UnityEngine.UI;

public class TimerLine : MonoBehaviour
{

    [SerializeField] private Image image = null;
    [SerializeField] private float maxTime = 0;

    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        image.fillAmount = currentTime / maxTime;
    }
}
