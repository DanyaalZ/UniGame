using UnityEngine;
using System.Collections;

public class ScrollingUVs_Layers : MonoBehaviour 
{
	public Terrain terrain; 
    public Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);

    private Material terrainMaterial;
    private Vector2 uvOffset = Vector2.zero;

    void Start()
    {
        // Assuming the terrain material is the first material of the terrain
        terrainMaterial = terrain.materialTemplate;
    }

    void Update()
    {
        uvOffset += (scrollSpeed * Time.deltaTime);
        if (terrainMaterial != null)
        {
            terrainMaterial.SetTextureOffset("_MainTex", uvOffset);
        }
    }
}

