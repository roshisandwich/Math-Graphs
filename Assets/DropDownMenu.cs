using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class DropDownMenu : MonoBehaviour
{
    public TMP_Text resolutionValueText;
    public Slider resolutionSlider;
    public Graph graph;

    public void SelectFunction(int function) {
        graph.SetFunction(function);
    }
    
    public void Quit() {
        Application.Quit();
    }
    void Update()
    {
        resolutionValueText.text = resolutionSlider.value.ToString();
    }
}
