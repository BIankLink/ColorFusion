using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;
    [SerializeField] private ColorSO currentColorSO;
    [SerializeField] private ColorMixRecipeSO[] colorMixRecipeSOArray;
    [SerializeField] private LineColider lineColider;

    private readonly List<Vector2> _points = new List<Vector2>();
    void Start()
    {
       _collider.transform.position -= transform.position;
       _renderer.startColor=currentColorSO.color;
       _renderer.endColor=currentColorSO.color;
    }

    

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos)) return;

        _points.Add(pos);

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);

        _collider.points = _points.ToArray();
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;

        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public ColorSO GetColorSO()
    {
        return currentColorSO;
    }
    public void SetColorSO(ColorSO colorSO)
    {
        this.currentColorSO = colorSO;
        _renderer.endColor = currentColorSO.color;
        WaitingToChangeGradient(5f);

    }
    IEnumerator WaitingToChangeGradient(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _renderer.startColor = currentColorSO.color;
    }
    public ColorMixRecipeSO GetColorMixRecipeSOWithInput(ColorSO input1ColorSO,ColorSO input2ColorSO)
    {
        foreach (ColorMixRecipeSO colorMixRecipeSO in colorMixRecipeSOArray)
        {
            if ((colorMixRecipeSO.input1 == input1ColorSO && colorMixRecipeSO.input2 == input2ColorSO)||colorMixRecipeSO.input1 == input2ColorSO && colorMixRecipeSO.input2 == input1ColorSO)
            {
                return colorMixRecipeSO;
            }
        }
        return null;
    }
    public ColorSO GetOutputForInput(ColorSO input1ColorSO,ColorSO input2ColorSO)
    {
        ColorMixRecipeSO colorMixRecipeSO = GetColorMixRecipeSOWithInput(input1ColorSO,input2ColorSO);
        if (colorMixRecipeSO != null)
        {
            return colorMixRecipeSO.output;
        }
        return null;
    }
    public bool HasRecipeWithInput(ColorSO input1ColorSO,ColorSO input2ColorSO)
    {
        ColorMixRecipeSO cuttingRecipeSO = GetColorMixRecipeSOWithInput(input1ColorSO,input2ColorSO);
        return cuttingRecipeSO != null;
    }

    
}

