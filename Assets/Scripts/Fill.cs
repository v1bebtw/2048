using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class Fill : MonoBehaviour
{
    public int value;
    [SerializeField] private TMP_Text valueDisplay;
    [SerializeField] private Image tileImage;
    [SerializeField] private float speed;
    private bool _hasMerge;
    public bool IsMoving => transform.localPosition != Vector3.zero;

    private void Start()
    {
        GameController.instance.RegisterFill(this);
    }
    
    private void OnDestroy()
    {
        if (GameController.instance != null)
            GameController.instance.UnregisterFill(this);
    }
    
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
        UpdateAppearance();
    }

    public void Double()
    {
        value *= 2;
        GameController.instance.ScoreUpdate(value);
        valueDisplay.text = value.ToString();
        UpdateAppearance();
    }

    private void UpdateAppearance()
    {
        if (tileImage == null)
            return;

        tileImage.color = GetColorForValue(value);

        // Цвет текста как в оригинале: тёмный для маленьких значений, светлый для больших
        if (value <= 4)
        {
            valueDisplay.color = new Color32(119, 110, 101, 255); // #776e65
        }
        else
        {
            valueDisplay.color = new Color32(249, 246, 242, 255); // #f9f6f2
        }
    }

    private Color32 GetColorForValue(int v)
    {
        switch (v)
        {
            case 2:   return new Color32(238, 228, 218, 255); // #eee4da
            case 4:   return new Color32(237, 224, 200, 255); // #ede0c8
            case 8:   return new Color32(242, 177, 121, 255); // #f2b179
            case 16:  return new Color32(245, 149, 99, 255);  // #f59563
            case 32:  return new Color32(246, 124, 95, 255);  // #f67c5f
            case 64:  return new Color32(246, 94, 59, 255);   // #f65e3b
            case 128: return new Color32(237, 207, 114, 255); // #edcf72
            case 256: return new Color32(237, 204, 97, 255);  // #edcc61
            case 512: return new Color32(237, 200, 80, 255);  // #edc850
            case 1024:return new Color32(237, 197, 63, 255);  // #edc53f
            case 2048:return new Color32(237, 194, 46, 255);  // #edc22e
            default:  return new Color32(60, 58, 50, 255);    // >2048 — тёмный
        }
    }
}
