﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HoverActions : MonoBehaviour, IPointerEnterHandler
{

    public GameObject TextToChange;
    public string TextToInsert;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        TextToChange.GetComponent<Text>().text = "Function description: " + TextToInsert;
    }
}
