using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class Timer : MonoBehaviour
{
    //Variables
    [SerializeField] TextMeshProUGUI timerText;
    float remainingTime = 300f;

    // Update is called once per frame
    void Update()
    {
        StartCountdown();

        //Set time format
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        //Display the time in the screen
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StartCountdown()
    {
        //check if time has reached 0
        if (remainingTime > 0)
        {
            //Decrease the time
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            //ResetTimer
            remainingTime = 300f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
