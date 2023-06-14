using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;


public class WinOnTouch : MonoBehaviour
{
    public string playerTag = "Player";

    public GameObject doorSelector;
    
    public TextMeshProUGUI winnerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            //Debug.Log($"TouchDoor -- {transform} == {doorSelector.GetComponent<ChooseWinnerDoor>().winnerDoor}");
            if (doorSelector.GetComponent<ChooseWinnerDoor>().winnerDoor == transform){
                //Debug.Log("Winner!!");
                winnerText.gameObject.SetActive(true);
                float resetTimer = 5f;
                Invoke("ResetGame", resetTimer);
            }
        }
    }

    private void ResetGame()
	{
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
	}
}
