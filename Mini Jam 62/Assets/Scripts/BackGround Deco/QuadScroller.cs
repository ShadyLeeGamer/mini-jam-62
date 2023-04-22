using UnityEngine;

public class QuadScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.1f;
    Material myMaterial;
    Vector2 offset;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(scrollSpeed, 0f);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
