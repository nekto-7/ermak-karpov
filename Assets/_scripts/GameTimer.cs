using UnityEngine;
using UnityEngine.UI;  // Для управления UI текстом или элементами
using TMPro;
public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;  // 1 минута
    public TextMeshProUGUI timerText;
    public AudioClip deathSound;       // Звук смерти
    public AudioSource backgroundMusic;
    public GameObject deathScreen;     // Экран затемнения при смерти

    private bool isTimerRunning = true;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusic.Play();
        deathScreen.SetActive(false);
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
                IncreaseMusicVolume();
            }
            else
            {
                EndGame();
            }
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void IncreaseMusicVolume()
    {
        backgroundMusic.volume = Mathf.Lerp(0.5f, 1.0f, 1 - (timeRemaining / 60f));  // Увеличение громкости
    }

    private void EndGame()
    {
        isTimerRunning = false;
        backgroundMusic.Stop();  // Остановка фоновой музыки
        audioSource.PlayOneShot(deathSound);  // Воспроизвести страшный звук
        deathScreen.SetActive(true);  // Показать экран смерти
    }
}