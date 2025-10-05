using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fill : MonoBehaviour
{
    private int value;
    [SerializeField] private TMP_Text valueDisplay;

    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        valueDisplay.text = valueIn.ToString();
    }
}
