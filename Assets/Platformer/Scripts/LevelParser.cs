using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParser : MonoBehaviour
{
    public string filename;
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject stonePrefab;
    public GameObject lavaPrebaf;
    public GameObject flagPolePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"Assets/Resources/Test.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }
        int row = 0;
        // Go through the rows from bottom to top
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            char[] letters = currentLine.ToCharArray();
            for (int column = 0; column < letters.Length; column = column  + 1)
            {
                var letter = letters[column];

                if(letter == 'x')
                    Instantiate(rockPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                if(letter == 'b')
                    Instantiate(brickPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                if (letter == 's')
                    Instantiate(stonePrefab, new Vector3(column, row, 0f), Quaternion.identity);
                if (letter == '?')
                    Instantiate(questionBoxPrefab, new Vector3(column, row, 0f), Quaternion.identity);
                if (letter == 'l')
                    Instantiate(lavaPrebaf, new Vector3(column, row, 0f), Quaternion.identity);
                if (letter == 'f')
                    Instantiate(flagPolePrefab, new Vector3(column, row, 0f), Quaternion.identity);


            }
            row++;
        }

      

    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
