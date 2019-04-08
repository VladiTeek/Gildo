using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightSystem : MonoBehaviour
{
    public Light sun;
    [Range(1,100)]
    public float speedSun = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        sun.transform.Rotate(Vector3.down, speedSun * Time.deltaTime);
    }
}
