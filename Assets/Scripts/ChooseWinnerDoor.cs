using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWinnerDoor : MonoBehaviour
{
    public Transform winnerDoor;

    void Start()
    {
        // Get the parent object's Transform component
        Transform parentTransform = transform;


        winnerDoor = parentTransform.GetChild(new System.Random().Next(parentTransform.childCount));
        //Debug.Log($"Winning transform is {winnerDoor}");
    }
}
