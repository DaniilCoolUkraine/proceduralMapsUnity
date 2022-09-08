using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    private NoiseGenerator _noiseGenerator;
    private CellularAutomata _cellularAutomata;
    
    private TileBase floorTile;
    private TileBase wallTile;

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
        _cellularAutomata = gameObject.GetComponent<CellularAutomata>();

        floorTile = _noiseGenerator.floorTile;
        wallTile = _noiseGenerator.wallTile;
    }

    void Start()
    {
        (height, width) = (width, height);
        DrawNoise();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(levelMap.WorldToCell(pos));
        }
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
                levelMap.SetTile(new Vector3Int(i, j, 0), tempTilebaseArray[i, j]);
            }
        }
    }

    public void ApplyButton()
    {
        _cellularAutomata.ApplyCellularAutomata(levelMap, 1, height, width, floorTile, wallTile);
    }
    
}
