using UnityEngine;
using UnityEngine.UI;

public class KeypadPuzzle : MonoBehaviour
{
    public Text codeDisplay;
    public string correctCode = "1234";  // Правильный код
    private string enteredCode = "";

    public GameObject door;  // Ссылка на дверь или объект, который должен активироваться

    public void AddDigit(string digit)
    {
        if (enteredCode.Length < 4)  // Ограничение на количество цифр
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
        // Здесь логика открытия двери (например, запуск анимации)
        door.GetComponent<Animator>().SetTrigger("Open");
    }
}
