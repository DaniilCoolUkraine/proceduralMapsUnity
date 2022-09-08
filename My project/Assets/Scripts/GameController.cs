using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    private NoiseGenerator _noiseGenerator;

    //tilemap to apply noise
    [SerializeField] private Tilemap levelMap;
    
    //needed size of generate map
    [SerializeField] private int height;
    [SerializeField] private int width;
    
    //density of walls
    [SerializeField] private int density;
    
    //awake to get noise generator
    private void Awake()
    {
        _noiseGenerator = gameObject.GetComponent<NoiseGenerator>();
    }

    void Start()
    {
        DrawNoise();
    }

    void Update()
    {
        
    }

    //function to draw noise tiles on map
    void DrawNoise()
    {
        //temp array to store generated noise
        TileBase[,] tempTilebaseArray = _noiseGenerator.MakeNoiseMap(density, height, width);
        
        //again loop to iterate through 2-dimension array
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //copy tiles from noise to map and shift it to the center
                levelMap.SetTile(new Vector3Int(i - height / 2, j - width / 2, 0), tempTilebaseArray[i, j]);
            }
        }
    }
    
}
