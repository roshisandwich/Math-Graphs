using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;

    Transform[] points;

    enum functionName {
        None, Equal, Quadratic, Cubic, Sine, Cosine, Tan
    }

    functionName selectedFunction;

    public void SetFunction(int function) {
        selectedFunction = (functionName)function;
    }

    public void SetResolution(float set) {
        resolution = (int)set;
        GetXCoords();
    }

    float GetYCoordinate(float x, float t = 0) {
        switch (selectedFunction)
        {
            case functionName.None:
                return 0;
            case functionName.Equal:
                return x;
            case functionName.Quadratic:
                return x * x;
            case functionName.Cubic:
                return x * x * x;
            case functionName.Sine:
                return Mathf.Sin(Mathf.PI * (x + t));
            case functionName.Cosine:
                return Mathf.Cos(Mathf.PI * (x + t));
            case functionName.Tan:
                return Mathf.Tan(Mathf.PI * (x + t));
            default:
                return 0;
        }
    }

    public void GetXCoords() {

        if (points != null) {
            foreach (Transform point in points)
            {
                Destroy(point.gameObject);
            }
        }
        
        float step = 2f / resolution;
        Vector3 position = Vector3.zero;
        var scale = Vector3.one / 5f * step;

        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++) {
			Transform point = points[i] = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.transform.SetParent(transform, false);
		}
    }

    void Awake() {
        GetXCoords();
    }
    void Update() {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = GetYCoordinate(position.x, time);
            point.localPosition = position;
        }
    }
}
