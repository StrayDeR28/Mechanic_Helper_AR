using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchCommandsButton : MonoBehaviour
{
    //пока не используется, из-за голосового управления, тк оно при старте заоминает кнопки
    [SerializeField] private GameObject commandsTextBlock;
    [SerializeField] private string showCommandsText = "Показать голосовые команды";
    [SerializeField] private string hideCommandsText = "Скрыть голосовые команды";
    [SerializeField] private bool isCommandsShown = false;

    public void SwitchText()
    {
        if (gameObject.GetComponentInChildren<TMP_Text>().text == showCommandsText) gameObject.GetComponentInChildren<TMP_Text>().text = hideCommandsText;
        else if (gameObject.GetComponentInChildren<TMP_Text>().text == hideCommandsText) gameObject.GetComponentInChildren<TMP_Text>().text = showCommandsText;
    }
    public void SwitchCommandsActivity()
    {
        if (isCommandsShown)
        {
            isCommandsShown = false;
            commandsTextBlock.SetActive(false);
        }
        else 
        {
            isCommandsShown = true;
            commandsTextBlock.SetActive(true);
        }
    }
}
