using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkBlob : MonoBehaviour
{
    [SerializeField] private ColorSO colorSO;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colorSO.color;
    }

    public bool HasColorSO()
    {
        return colorSO != null;
    }
    public void SetKitchenObject(ColorSO colorSO)
    {
        this.colorSO = colorSO;
    }
    public ColorSO GetColorSO()
    {
        return colorSO;
    }
}
