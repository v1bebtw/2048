using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell right;
    public Cell left;
    public Cell up;
    public Cell down;

    public Fill fill;

    private void OnEnable()
    {
        GameController.slide += OnSlide;
    }
    
    private void OnDisable()
    {
        GameController.slide -= OnSlide;
    }
    
    private void OnSlide(string whereToMove)
    {
        CellCheck();
        if (whereToMove == "up")
        {
            if (up != null)
                return;

            Cell currentCell = this;
            SlideUp(currentCell);
        }
        if (whereToMove == "down")
        {
            if (down != null)
                return;

            Cell currentCell = this;
            SlideDown(currentCell);
        }
        if (whereToMove == "left")
        {
            if (left != null)
                return;

            Cell currentCell = this;
            SlideLeft(currentCell);
        }
        if (whereToMove == "right")
        {
            if (right != null)
                return;

            Cell currentCell = this;
            SlideRight(currentCell);
        }
        
        GameController.ticker++;
        if (GameController.ticker == 4 && GameController.isMoved) 
        {
            GameController.instance.StartCoroutine(GameController.instance.WaitForAnimationsAndSpawn());
        }
    }

    private void SlideUp(Cell currentCell)
    {
        if (currentCell.down == null)
            return;
        
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
                else if (currentCell.down.fill != nextCell.fill)
                {
                    nextCell.fill.transform.parent = currentCell.down.transform;
                    currentCell.down.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.down;
            while (nextCell.down != null && nextCell.fill == null)
            {
                nextCell = nextCell.down;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                GameController.isMoved = true;
                SlideUp(currentCell);
            }
        }
        
        SlideUp(currentCell.down);
    }
    
    private void SlideDown(Cell currentCell)
    {
        if (currentCell.up == null)
            return;
        
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
                else if (currentCell.up.fill != nextCell.fill)
                {
                    nextCell.fill.transform.parent = currentCell.up.transform;
                    currentCell.up.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.up;
            while (nextCell.up != null && nextCell.fill == null)
            {
                nextCell = nextCell.up;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                GameController.isMoved = true;
                SlideDown(currentCell);
            }
        }
        
        SlideDown(currentCell.up);
    }
    
    private void SlideLeft(Cell currentCell)
    {
        if (currentCell.right == null)
            return;
        
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
                else if (currentCell.right.fill != nextCell.fill)
                {
                    nextCell.fill.transform.parent = currentCell.right.transform;
                    currentCell.right.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.right;
            while (nextCell.right != null && nextCell.fill == null)
            {
                nextCell = nextCell.right;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                GameController.isMoved = true;
                SlideLeft(currentCell);
            }
        }
        
        SlideLeft(currentCell.right);
    }
    
    private void SlideRight(Cell currentCell)
    {
        if (currentCell.left == null)
            return;
        
        if (currentCell.fill != null)
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
                else if (currentCell.left.fill != nextCell.fill)
                {
                    nextCell.fill.transform.parent = currentCell.left.transform;
                    currentCell.left.fill = nextCell.fill;
                    nextCell.fill = null;
                    GameController.isMoved = true;
                }
            }
        }
        else
        {
            Cell nextCell = currentCell.left;
            while (nextCell.left != null && nextCell.fill == null)
            {
                nextCell = nextCell.left;
            }

            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                GameController.isMoved = true;
                SlideRight(currentCell);
            }
        }
        
        SlideRight(currentCell.left);
    }

    private void CellCheck()
    {
        if (fill == null)
            return;

        if (up != null)
        {
            if (up.fill == null)
                return;
            if (up.fill.value == fill.value)
                return;
        }
        if (down != null)
        {
            if (down.fill == null)
                return;
            if (down.fill.value == fill.value)
                return;
        }
        if (right != null)
        {
            if (right.fill == null)
                return;
            if (right.fill.value == fill.value)
                return;
        }
        if (left != null)
        {
            if (left.fill == null)
                return;
            if (left.fill.value == fill.value)
                return;
        }
        GameController.instance.GameOverCheck();
    }
}