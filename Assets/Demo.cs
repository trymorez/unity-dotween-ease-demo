using UnityEngine;
using System;
using DG.Tweening;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    [SerializeField] int easeLength = 35;

    void Start()
    {
        Type easeEnumType = typeof(DG.Tweening.Ease);

        string[] easeNames = Enum.GetNames(easeEnumType);

        for (int i = 1; i < easeLength; i++)
        {
            Debug.Log("Ease Value: " + i + ", Ease Name: " + easeNames[i]);
        }
    }
}
