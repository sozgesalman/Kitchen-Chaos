using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualEffect;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterEventArgs e)
    {
        if(e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualEffect.SetActive(true);
    }

    private void Hide()
    {
        visualEffect.SetActive(false);
    }
}
