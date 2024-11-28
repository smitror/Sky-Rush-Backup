using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetMenuButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public GameObject completeScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ResetMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ResetMenu()
    {
        gameManager.ResetTitleScreen();
        completeScreen.gameObject.SetActive(false);
    }
}
