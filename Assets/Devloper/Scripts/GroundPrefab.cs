using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPrefab : MonoBehaviour
{
    public bool IsColored = false;

    public void ChangesColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        IsColored = true;

    }
}
