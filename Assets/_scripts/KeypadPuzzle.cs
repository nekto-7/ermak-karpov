using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeypadPuzzle : MonoBehaviour
{
    public TextMeshProUGUI codeDisplay;
    public string correctCode = "1234"; // Правильный код
    private string enteredCode = "";
    public TextMeshProUGUI press;
    public GameObject door; // Ссылка на дверь
    public GameObject keypadUI; // UI панели с кнопкам
    private bool isPlayerNearby = false; // Флаг для определения близости игрока
    
    void Update()
    {
        // Проверяем нажатие кнопки "E", если игрок рядом
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleKeypadUI();
        }
    }

    // Метод для добавления цифры
    public void AddDigit(string digit)
    {
        if (enteredCode.Length < 4) // Ограничение на количество цифр
        {
            enteredCode += digit;
            codeDisplay.text = enteredCode;
        }
    }

    public void ClearCode()
    {
        enteredCode = "";
        codeDisplay.text = "";
    }

    public void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("Код верный!");
            OpenDoor();
        }
        else
        {
            Debug.Log("Неверный код");
            ClearCode();
        }
    }

    private void OpenDoor()
    {
        door.GetComponent<Animator>().SetTrigger("Open");
        keypadUI.SetActive(false); // Закрываем UI после открытия двери
    }

    private void ToggleKeypadUI()
    {
        keypadUI.SetActive(!keypadUI.activeSelf); // Включаем/выключаем UI
        Cursor.lockState = keypadUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked; // Управление курсором
        Cursor.visible = keypadUI.activeSelf;
    }

    // Обработка входа игрока в триггер
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Убедитесь, что у игрока тег "Player"
        {
            isPlayerNearby = true;
            press.text = "Взаимодействие на кнопку E";
        }
    }

    // Обработка выхода игрока из триггера
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            keypadUI.SetActive(false); // Закрыть UI, если игрок уходит
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
