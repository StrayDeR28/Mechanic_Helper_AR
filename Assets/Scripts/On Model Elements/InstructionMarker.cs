using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionMarker : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private string assemblingNumber;
    [SerializeField] private string disassemblingNumber;

    public void SetAssemblingNumber()
    {
        m_Text.text = assemblingNumber;
    }
    public void SetDisassemblingNumber()
    {
        m_Text.text = disassemblingNumber;
    }
}
