using UnityEngine;

public class RandomObjectColor : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0, 1f, 0.75f, 1f, 0.5f, 1f);
    }
}
