using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    public Transform center;   // sfera centrale
    public float radius = 3f;  // distanza dal centro
    public float speed = 60f;  // gradi al secondo

    private float angle;

    void Update()
    {
        if (center == null) return;

        angle += speed * Time.deltaTime;

        // sin e cos (in radianti)
        float rad = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * radius;
        float z = Mathf.Sin(rad) * radius;

        transform.position = center.position + new Vector3(x, 0f, z);
    }


}
