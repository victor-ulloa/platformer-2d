using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Image[] coinsArray;

    [SerializeField] TMP_Text AttemptsValue;


    private void Start()
    {
        if (AttemptsValue)
        {
            GameManager.instance.OnAttemptsValueChanged.AddListener((value) => UpdateAttempts(value));
        }

        if (coinsArray.Length > 0)
        {
            GameManager.instance.OnScoreValueChanged.AddListener((value) => UpdateCoins(value));
        }
    }

    void UpdateCoins(int value)
    {
        Debug.Log(value);
        for (int i = 0; i < coinsArray.Length; i++)
        {
            if (i < value)
            {
                coinsArray[i].enabled = true;
            }
            else
            {
                coinsArray[i].enabled = false;
            }
        }
    }

    void UpdateAttempts(int value)
    {
        AttemptsValue.text = value.ToString();
    }
}
