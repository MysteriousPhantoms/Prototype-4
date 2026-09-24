using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject dayBackground;
    public GameObject nightBackground;
    public Transform startPoint;
    public GameObject winScreen;

    [HideInInspector] public bool isDay = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(DayNightCycle());
    }

    IEnumerator DayNightCycle()
    {
        while (true)
        {
            isDay = !isDay;
            dayBackground.SetActive(isDay);
            nightBackground.SetActive(!isDay);

            float waitTime = Random.Range(2f, 6f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void RestartPlayer(GameObject player)
    {
        player.transform.position = startPoint.position;
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
}