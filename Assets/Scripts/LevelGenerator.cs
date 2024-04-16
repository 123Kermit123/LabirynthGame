using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] ColorMap;
    public float offset = 5;

    public void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        foreach (ColorToPrefab colorToPrefab in ColorMap)
        {
            if (colorToPrefab.color == pixelColor)
            {
                var pos = new Vector3(x, 0, z) * offset;
                Instantiate(colorToPrefab.prefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
