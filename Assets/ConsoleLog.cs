using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLog : MonoBehaviour
{
    private string consoleText = "";

    void OnEnable()
    {
        // 기존 콘솔 로그를 받아오기 위해 콜백 메서드 등록
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        // 콘솔 로그 콜백 등록 해제
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logText, string stackTrace, LogType type)
    {
        // 콘솔 로그를 받아와서 변수에 저장
        consoleText += logText + "\n";
    }

    void OnGUI()
    {
        // GUI.TextArea를 사용하여 콘솔 로그를 게임 화면에 표시
        GUI.TextArea(new Rect(10, 100, 200, 100), consoleText);
    }
}
