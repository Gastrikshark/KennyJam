using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Sprite[] numberSprites;
    public Image[] timerImages;

    public float countdownTime = 60f; // counts down in seconds

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            UpdateTimerDisplay(countdownTime);
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        UpdateTimerDisplay(0); // Ensure the timer shows 00:00 when finished
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        // Update the timer images
        timerImages[0].sprite = numberSprites[minutes / 10];
        timerImages[1].sprite = numberSprites[minutes % 10];
        timerImages[2].sprite = numberSprites[seconds / 10];
        timerImages[3].sprite = numberSprites[seconds % 10];
    }
}
