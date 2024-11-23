using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string pickupMessage = "Нажмите E, чтобы подобрать ключ";
    public GameObject actionIndicator;  // UI элемент (иконка или текст)
    public AudioClip pickupSound;       // Звук подбора предмета

    private bool isPlayerNear = false;
    private AudioSource audioSource;

    public static bool hasKey = false;  // Переменная для хранения состояния ключа

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        actionIndicator.SetActive(false);  // Скрыть индикатор при старте
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            actionIndicator.SetActive(true);  // Показать индикатор
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            actionIndicator.SetActive(false);  // Скрыть индикатор
        }
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PickUpKey();
        }
    }

    private void PickUpKey()
    {
        audioSource.PlayOneShot(pickupSound);  // Воспроизвести звук
        hasKey = true;  // Игрок подобрал ключ
        actionIndicator.SetActive(false);  // Скрыть индикатор
        Destroy(gameObject, pickupSound.length);  // Удалить объект ключа
    }
}
