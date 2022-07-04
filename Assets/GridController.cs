using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridController : MonoBehaviour
{
    public Text[] gridSpots;
    public List<string> syllables = new List<string>();


    private void Start()
    {
        ShuffleGrid();
        AddToGrid();
    }
    void ShuffleGrid()
    {
        System.Random rnd = new System.Random();
        List<string> shuffledList = new List<string>();
        int randomIndex = 0;

        while(syllables.Count>0)
        {
            randomIndex = rnd.Next(0, syllables.Count);
            shuffledList.Add(syllables[randomIndex]);
            syllables.RemoveAt(randomIndex);

        }
        syllables = shuffledList;
    }

    void AddToGrid()
    {
        for (int i = 0; i < syllables.Count; i++)
        {
            gridSpots[i].text = syllables[i];
        }
    }

}
