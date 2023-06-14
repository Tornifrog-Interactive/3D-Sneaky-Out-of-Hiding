using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KillOnCollide : MonoBehaviour
{
    public TextMeshProUGUI loserText;
    
    public string killTagName = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(killTagName))
        {
            //Debug.Log("Kill");
            loserText.gameObject.SetActive(true);
            float resetTimer = 5f;
            Invoke("ResetGame", resetTimer);
        }
    }
    private void ResetGame()
	{
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
	}
}
