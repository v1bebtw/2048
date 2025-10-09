using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fill : MonoBehaviour
{
    public int value;
    [SerializeField] private TMP_Text valueDisplay;
    [SerializeField] private float speed;
    private bool _hasMerge;
    private void Update()
    {
        if (transform.localPosition != Vector3.zero)
        {
            _hasMerge = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed * Time.deltaTime);
        }
        else if (_hasMerge == false)
        {
            if (transform.parent.GetChild(0) != this.transform)
                Destroy(transform.parent.GetChild(0).gameObject);
            _hasMerge = true;
        }
    }
    
    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        valueDisplay.text = valueIn.ToString();
    }

    public void Double()
    {
        value *= 2;
        GameController.instance.ScoreUpdate(value);
        valueDisplay.text = value.ToString();
    }
}
