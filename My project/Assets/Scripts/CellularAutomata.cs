using UnityEngine;
using UnityEngine.Tilemaps;

public class CellularAutomata : MonoBehaviour
{
    public void ApplyCellularAutomata(Tilemap levelMap, int count, int height, int width, TileBase floor, TileBase wall)
    {
        for (int i = 0; i < count; i++)
        {
            var tempMap = Instantiate(levelMap);
            tempMap.gameObject.SetActive(false);
            
            //if u want just expand -- uncomment
            //var tempMap = levelMap;
            for (int j = 0; j < height; j++)
            {
                for (int k = 0; k < width; k++)
                {
                    int neighborWallCount = 0;
                    for (int x = j - 1; x <= j + 1; x++)
                    {
                        for (int y = k - 1; y <= k + 1; y++)
                        {
                            if (isWithinMapBounds(x, y, levelMap))
                            {
                                if (x != j || y != k)
                                    if (tempMap.GetTile(new Vector3Int(y,x,0)) == wall)
                                        neighborWallCount++;
                            }
                            else
                            { 
                                neighborWallCount++;
                            }
                        }
                    }
                    int minimumWallCount = 4;
                    if (neighborWallCount > minimumWallCount)
                        levelMap.SetTile(new Vector3Int(j, k, 0), wall);
                    else
                        levelMap.SetTile(new Vector3Int(j, k, 0), floor);
                }
            }
        }
    }
    
    private bool isWithinMapBounds(int x, int y, Tilemap map)
    {
        if (map.GetTile(new Vector3Int(x, y, 0)) == null)
            return false;
        return true;
    }
    
}