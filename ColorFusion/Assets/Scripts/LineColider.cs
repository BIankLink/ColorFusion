using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineColider : MonoBehaviour
{
    [SerializeField] Line line;
    public class OnChangedEventArgs : EventArgs
    {
        public ColorSO output;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.GetComponent<InkBlob>()&&other.GetComponent<InkBlob>().HasColorSO() && line.HasRecipeWithInput(line.GetColorSO(), other.GetComponent<InkBlob>().GetColorSO()))
        {
            //ColorMixRecipeSO colorMixRecipeSO = GetColorMixRecipeSOWithInput(GetColorSO(),other.GetComponent<InkBlob>().GetColorSO());
            ColorSO output = line.GetOutputForInput(line.GetColorSO(), other.GetComponent<InkBlob>().GetColorSO());
            line.SetColorSO(output);
            Debug.Log(output.colorName);
        }
    }
}
