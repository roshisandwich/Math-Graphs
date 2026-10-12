using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class DropDownMenu : MonoBehaviour
{
    public TMP_Text resolutionValueText;
    public Slider resolutionSlider;

    public void SelectFunction(int function) {
        FunctionLibrary.SelectFunction(function);
    }

    void Awake()
    {
        resolutionSlider.value = 100f;
    }

    public void Quit() {
        Application.Quit();
    }
    void Update()
    {
        resolutionValueText.text = resolutionSlider.value.ToString();
    }
}
