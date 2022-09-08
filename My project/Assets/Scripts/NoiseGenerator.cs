using UnityEngine;
using UnityEngine.Tilemaps;

public class NoiseGenerator : MonoBehaviour
{
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase wallTile;
    
    public TileBase[,] MakeNoiseMap(int density, int height, int width)
    {
        TileBase[,] noiseGrid = new TileBase[height,width];

        int random = Random.Range(1, 100);

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (random > density)
                    noiseGrid[i, j] = floorTile;
                else
                    noiseGrid[i, j] = wallTile;
            }
        }
        return noiseGrid;
    }
}
