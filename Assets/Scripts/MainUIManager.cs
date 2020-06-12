using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private Button startBtn;

    private void OnEnable()
    {
        startBtn.onClick.AddListener(OnClickStartGame);
    }

    private void OnDisable()
    {
        startBtn.onClick.RemoveListener(OnClickStartGame);
    }

    private void OnClickStartGame()
    {
        GameManager.Instance.GameStart();
    }
}
