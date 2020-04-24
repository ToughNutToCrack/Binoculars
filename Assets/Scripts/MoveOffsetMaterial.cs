using UnityEngine;

public class MoveOffsetMaterial : MonoBehaviour
{
    public float scrollSpeed = 5;
    public int matIndex = 0;
    Material mat;
    float actualOffset = 0;
    void Start()
    {
        mat = GetComponent<Renderer>().materials[matIndex];
        mat.SetTextureOffset("_BaseMap", new Vector2(actualOffset, 0));
    }

    void Update()
    {
        actualOffset = actualOffset + Time.deltaTime * scrollSpeed;
        mat.SetTextureOffset("_BaseMap", new Vector2(actualOffset, 0));   
    }
}
