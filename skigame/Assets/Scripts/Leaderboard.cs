using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List <float> bestTimes = new();
    [SerializeField] private TextMeshProUGUI leaderboardText; 

    private void Awake()
    {
        bestTimes.Clear();
        for (int i = 0; i < 5; i++)
        {
            bestTimes.Add(PlayerPrefs.GetFloat("time"+i, 99999));
        }
         UpdateLeaderboardUI();

    }
    // Start is called before the first frame update
    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveData();
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
            PlayerPrefs.SetFloat("time"+i, bestTimes[i]);
        }
       
        PlayerPrefs.Save();
    }

    private void UpdateLeaderboardUI()
        {
            leaderboardText.text = "Best Times:\n";
            for (int i = 0; i < Mathf.Min(5, bestTimes.Count); i++)
            {
                leaderboardText.text += $"{i + 1}. {bestTimes[i]:F2} sec\n";
            }
        }

}
