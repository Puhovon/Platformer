using UnityEngine;

public class ParalaxController : MonoBehaviour
{

    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coef;

    private float layersCount;
   
    void Start()
    {
        layersCount = layers.Length;
    }
    void Update()
    {
        for (int i = 0; i < layersCount; i++)
        {
            layers[i].position = transform.position * coef[i];
        }
    }
}
