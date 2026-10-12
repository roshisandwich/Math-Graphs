using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary {

    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName { None, Equal, Quadratic, Cubic, Wave, MultiWave, Ripple, Sphere, Torus, Knot, Bounce }

    static Function[] functions = { None, Equal, Quadratic, Cubic, Wave, MultiWave, Ripple, Sphere, Torus, Knot, Bounce };
    public static Function selectedFunction = None;

    public static void SelectFunction (int index) {
        selectedFunction = functions[index];
    }

    public static Function GetFunction (FunctionName name) {
		return functions[(int)name];
	}

    public static Vector3 None(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = 0f;
        p.z = 0f;
        return p;
    }

    public static Vector3 Equal(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = u;
        p.z = 0f;
        return p;
    }

    public static Vector3 Quadratic(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = u * u;
        p.z = 0f;
        return p;
    }

    public static Vector3 Cubic(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = u * u * u;
        p.z = 0f;
        return p;
    }

    public static Vector3 Wave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }

    public static Vector3 MultiWave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= (1 / 2.5f);
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t) {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= (1f + 10 * d);
        p.z = v;
        return p;
    }

    public static Vector3 Sphere (float u, float v, float t) {
        float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
		float s = r * Cos(0.5f * PI * v);
		Vector3 p;
		p.x = s * Sin(PI * u);
		p.y = r * Sin(0.5f * PI * v);
		p.z = s * Cos(PI * u);
		return p;
	}

    public static Vector3 Torus (float u, float v, float t) {
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
		float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
		float s = r1 + r2 * Cos(PI * v);
		Vector3 p;
		p.x = s * Sin(PI * u);
		p.y = r2 * Sin(PI * v);
		p.z = s * Cos(PI * u);
		return p;
	}

    public static Vector3 Knot(float u, float v, float t) {
        Vector3 p;
        p.x = (1f + 0.3f * Cos(3f * PI * u + t)) * Cos(2f * PI * u) + 0.2f * Cos(2f * PI * v) * Cos(PI * u);
        p.y = 0.3f * Sin(3f * PI * u + t) + 0.2f * Sin(2f * PI * v);
        p.z = (1f + 0.3f * Cos(3f * PI * u + t)) * Sin(2f * PI * u) + 0.2f * Cos(2f * PI * v) * Sin(PI * u);
        return p;
    }

    public static Vector3 Bounce(float u, float v, float t) {
        float r = 0.6f + 0.2f * Mathf.Sin(Mathf.PI * (u * 4f + v * 4f - t));
        Vector3 p;
        p.x = r * u;
        p.y = v + 0.1f * Mathf.Cos(Mathf.PI * (u * 6f + t));
        p.z = r * Mathf.Sin(Mathf.PI * u * 2f);
        return p;
    }
    
}
