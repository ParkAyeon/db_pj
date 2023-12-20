using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour
{
    public Button button;
    private bool isChoose = false;

    public void ColorChange()
    {
        ColorBlock colorBlock = button.colors;

        isChoose = !isChoose; // 상태 토글

        // 선택 여부에 따라 색상 설정
        colorBlock.normalColor = isChoose ? new Color(1f, 0, 0, 1f) : Color.white;
        colorBlock.selectedColor = isChoose ? new Color(1f, 0, 0, 1f) : Color.white;

        button.colors = colorBlock;
    }
}
