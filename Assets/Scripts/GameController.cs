using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public static GameController instance;
    public static int ticker;
    public static bool isMoved;
    
    [SerializeField] private GameObject fillPrefab;
    [SerializeField] private Cell[] allCells;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    
    public static Action<string> slide;

    public int myScore;
    [SerializeField] private TMP_Text scoreDisplay;

    public int gameOverCounter;
    [SerializeField] private GameObject gameOverPanel;
    
    private List<Fill> _allFills = new List<Fill>();

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    private void Start()
    {
        StartSpawnFill();
        StartSpawnFill();
    }

    private void Update()
    {
        // Отслеживание свайпов
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     switch (touch.phase)
        //     {
        //         case TouchPhase.Began:
        //             _startPosition = touch.position;
        //             break;
        //         case TouchPhase.Ended:
        //             _endPosition = touch.position;
        //             calcMove();
        //             break;
        //     }
        // }
        
        if (Input.GetMouseButtonDown(0))
            _startPosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            _endPosition = Input.mousePosition;
            calcMove();
        }
    }
    
    public void RegisterFill(Fill fill)
    {
        if (!_allFills.Contains(fill))
            _allFills.Add(fill);
    }
    
    public void UnregisterFill(Fill fill)
    {
        if (_allFills.Contains(fill))
            _allFills.Remove(fill);
    }
    
    private bool AreAllFillsStationary()
    {
        foreach (Fill fill in _allFills)
        {
            if (fill.IsMoving)
                return false;
        }
        return true;
    }
    
    public IEnumerator WaitForAnimationsAndSpawn()
    {
        yield return new WaitUntil(AreAllFillsStationary);
        
        yield return new WaitForSeconds(0.01f);
        
        SpawnFill();
    }
    
    public void SpawnFill()
    {
        bool isFull = true;
        for (int i = 0; i < allCells.Length; i++)
        {
            if (allCells[i].fill == null)
            {
                isFull = false;
            }
        }
        
        if (isFull)
            return;
        
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            Debug.Log("Already filled");
            SpawnFill();
            return;
        }
        
        float chance = UnityEngine.Random.Range(0f, 1f);
        if (chance < 0.8f)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Fill tempFillValue = tempFill.GetComponent<Fill>();
            allCells[whichSpawn].GetComponent<Cell>().fill = tempFillValue;
            tempFillValue.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform);
            Fill tempFillValue = tempFill.GetComponent<Fill>();
            allCells[whichSpawn].GetComponent<Cell>().fill = tempFillValue;
            tempFillValue.FillValueUpdate(4);
        }
    }
    
    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        
        if (allCells[whichSpawn].transform.childCount != 0)
        {
            Debug.Log("Already filled");
            SpawnFill();
            return;
        }
        
        GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn].transform); 
        Fill tempFillValue = tempFill.GetComponent<Fill>();
        allCells[whichSpawn].GetComponent<Cell>().fill = tempFillValue; 
        tempFillValue.FillValueUpdate(2);
        
    }
    
    private void calcMove()
    {
        Vector2 delta = _endPosition - _startPosition;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (delta.x > 0)
            {
                ticker = 0;
                isMoved = false;
                gameOverCounter = 0;
                slide("right");
            }
            else
            {
                ticker = 0;
                isMoved = false;
                gameOverCounter = 0;
                slide("left");
            }
        }
        else
        {
            if (delta.y > 0)
            {
                ticker = 0;
                isMoved = false;
                gameOverCounter = 0;
                slide("up");
            }
            else
            {
                ticker = 0;
                isMoved = false;
                gameOverCounter = 0;
                slide("down");
            }
        }
    }

    public void ScoreUpdate(int score)
    {
        myScore += score;
        scoreDisplay.text = myScore.ToString();
    }

    public void GameOverCheck()
    {
        gameOverCounter++;
        if (gameOverCounter >= 16)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
