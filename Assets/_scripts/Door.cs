using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioClip doorOpenSound;
    private bool isDoorOpen = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDoorOpen)
        {
            TryOpenDoor();
        }
    }

    private void TryOpenDoor()
    {
        if (ItemPickup.hasKey)  // Проверяем, есть ли у игрока ключ
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("Дверь закрыта! Нужен ключ.");  // Сообщение в консоли, если нет ключа
            // Можно добавить визуальное сообщение на экране
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetTrigger("Open");  // Триггер анимации открытия двери
        audioSource.PlayOneShot(doorOpenSound);  // Воспроизвести звук
        isDoorOpen = true;
    }
}
