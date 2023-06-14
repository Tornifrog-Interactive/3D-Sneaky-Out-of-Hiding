using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveTextButton : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    Button button;
    public GameObject player;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(startTutorial);
    }

    void startTutorial()
    {
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        player.SetActive(true);
    }
}
