using UnityEngine;
using UnityEngine.Tilemaps;

public class NoiseGenerator : MonoBehaviour
{
    //here we assign two tileBase
    //it will be wall and floor tiles
    public TileBase floorTile;
    public TileBase wallTile;
    
    //create a function, it takes density of noise and size of level map
    public TileBase[,] MakeNoiseMap(int density, int height, int width)
    {
        //temporary array to store tilebase
        TileBase[,] noiseGrid = new TileBase[width,height];
        
        //random value to decide type of next tile 
        int random = Random.Range(1, 100);

        //loop to go through 2-dimension array
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (random > density)
                    noiseGrid[i, j] = floorTile;
                else
                    noiseGrid[i, j] = wallTile;
                
                random = Random.Range(1, 100);
            }
        }
        return noiseGrid;
    }
}
