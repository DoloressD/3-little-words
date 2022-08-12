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
        int randomIndex = 0;
        string tempSyllable = "";

        for(int i=0; i<syllables.Count-1; i++)
		{
            randomIndex = rnd.Next(i+1, syllables.Count);
            tempSyllable = syllables[i];
            syllables[i] = syllables[randomIndex];
            syllables[randomIndex] = tempSyllable;
		}
    }

    void AddToGrid()
    {
        for (int i = 0; i < syllables.Count; i++)
        {  
            gridSpots[i].text = syllables[i].ToUpper();

        }
    }

}
