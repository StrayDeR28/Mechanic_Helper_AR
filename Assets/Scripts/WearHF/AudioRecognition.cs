using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WearHFPlugin;

public class AudioRecognition : MonoBehaviour
{
    [SerializeField] private GameObject wearHFManager;
    [SerializeField] private List<string> buttonsNames = new List<string>();
    [SerializeField] private List<Button> buttons = new List<Button>();

    private void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttonsNames.Add(buttons[i].GetComponentInChildren<TMP_Text>().text);
        }
        if (wearHFManager != null && wearHFManager.GetComponent<WearHF>())
        {
            for(int i = 0; i < buttonsNames.Count; i++)
            {
                wearHFManager.GetComponent<WearHF>().AddVoiceCommand(buttonsNames[i], VoiceCommandCallback);
            }
        }
    }
    public void VoiceCommandCallback(string command)
    {
        for (int i = 0;i < buttonsNames.Count;i++)
        {
            if (buttons[i].GetComponentInChildren<TMP_Text>().text == command)
            {
                buttons[i].onClick.Invoke();
            }
        }
    }
}
