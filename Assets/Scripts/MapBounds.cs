using UnityEngine;
using UnityEngine.Tilemaps;

public class MapBounds : MonoBehaviour
{
    public Tilemap tilemap; // arrastra tu Tilemap aquí
    public Bounds mapBounds;

    void Start()
    {
        mapBounds = tilemap.localBounds;
        Debug.Log("Mapa min: " + mapBounds.min + " | max: " + mapBounds.max);
    }
}
