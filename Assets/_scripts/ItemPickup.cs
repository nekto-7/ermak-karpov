using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour
{
    public bool hasKey = false;  // Переменная для ключа
    public GameObject go;
    private bool isPlayerNear = false;
    // игрок вошел
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }
    // игрок вышел
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
    // при нажатии кнопки е вызываем метод
    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PickUpKey();
        }
    }
    // поднимаем ключ
    private void PickUpKey()
    {
        hasKey = true;  // Установка ключа
        Destroy(go.gameObject);  // Удаление ключа
    }
}
