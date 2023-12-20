using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLog : MonoBehaviour
{
    private string consoleText = "";

    void OnEnable()
    {
        // ���� �ܼ� �α׸� �޾ƿ��� ���� �ݹ� �޼��� ���
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        // �ܼ� �α� �ݹ� ��� ����
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logText, string stackTrace, LogType type)
    {
        // �ܼ� �α׸� �޾ƿͼ� ������ ����
        consoleText += logText + "\n";
    }

    void OnGUI()
    {
        // GUI.TextArea�� ����Ͽ� �ܼ� �α׸� ���� ȭ�鿡 ǥ��
        GUI.TextArea(new Rect(10, 100, 200, 100), consoleText);
    }
}
