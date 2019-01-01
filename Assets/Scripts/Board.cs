using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int[] possibleNums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[,] box;
    public Row[] rows;
    public Column[] cols;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle();

        box = new int[3, 3];
        rows = new Row[3];
        cols = new Column[3];

        for (int i = 0; i < 3; i++)
        {
            rows[i] = new Row();
            cols[i] = new Column();
        }

        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                box[i, j] = possibleNums[k];
                rows[i].values.Add(possibleNums[k]);
                cols[j].values.Add(possibleNums[k]);
                k++;
            }
        }

        Debug.Log(DisplayBox());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shuffle();
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < possibleNums.Length; i++)
        {
            int randomIndex = Random.Range(0, possibleNums.Length);
            int temp = possibleNums[randomIndex];
            possibleNums[randomIndex] = possibleNums[i];
            possibleNums[i] = temp;
        }
    }

    string DisplayBox()
    {
        string output = "";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                output += box[i,j] + " ";
            }
            output += "\n";
        }

        return output;
    }
}
