using System;
using NUnit.Framework.Constraints;
using Unity.Mathematics;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;

    Transform[] points;

    public enum functionName {
        None, Quadratic, Cubic, Sine, Cosine, Tan
    }

    functionName selectedFunction;

    public void SetFunction(int function) {
        selectedFunction = (functionName)function;
    }

    public void SetResolution(float set) {
        resolution = (int)set;
    }

    float GetYCoordinate(float x, float t = 0) {
        switch (selectedFunction)
        {
            case functionName.None:
                return x;
                break;
            case functionName.Quadratic:
                return x * x;
                break;
            case functionName.Cubic:
                return x * x * x;
                break;
            case functionName.Sine:
                return Mathf.Sin(Mathf.PI * (x + t));
                break;
            case functionName.Cosine:
                return Mathf.Cos(Mathf.PI * (x + t));
                break;
            case functionName.Tan:
                return Mathf.Tan(Mathf.PI * (x + t));
                break;
            default:
                return 0;
        }
    }

    public void GetXCoords() {
        foreach (Transform point in points)
        {
            Destroy(point.gameObject);
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

    void Update() {
        GetXCoords();
        float time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = GetYCoordinate(position.x, time);
            point.localPosition = position;
        }
    }
}
