public struct Vector
{
    public float x;

    public float y;

    public Vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", x, y);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return this == (Vector) obj;
    }

    public void Normalize()
    {
        if (this != zero)
        {
            float size = magnitude;
            x /= size;
            y /= size;
        }
    }

    public float Dot(Vector v)
    {
        return Dot(this, v);
    }

    public float Cross(Vector v)
    {
        return Cross(this, v);
    }

    public static Vector operator -(Vector a)
    {
        return new Vector(-a.x, -a.y);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.x - b.x, a.y - b.y);
    }

    public static bool operator ==(Vector lhs, Vector rhs)
    {
        return lhs.x == rhs.x && lhs.y == rhs.y;
    }

    public static bool operator !=(Vector lhs, Vector rhs)
    {
        return lhs.x != rhs.x || lhs.y != rhs.y;
    }

    public static Vector operator *(float d, Vector a)
    {
        return a * d;
    }

    public static Vector operator *(Vector a, float d)
    {
        return new Vector(a.x * d, a.y * d);
    }

    public static Vector operator /(Vector a, float d)
    {
        return new Vector(a.x / d, a.y / d);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.x + b.x, a.y + b.y);
    }

    public float sqrMagnitude
    {
        get { return x * x + y * y; }
    }

    public float magnitude
    {
        get { return MathS.Sqrt(sqrMagnitude); }
    }

    public Vector normalized
    {
        get
        {
            if (this == zero)
            {
                return zero;
            }

            return this / magnitude;
        }
    }

    public static Vector one
    {
        get { return new Vector(1, 1); }
    }

    public static Vector right
    {
        get { return new Vector(1, 0); }
    }

    public static Vector up
    {
        get { return new Vector(0, 1); }
    }

    public static Vector zero
    {
        get { return new Vector(); }
    }

    public static float Distance(Vector p1, Vector p2)
    {
        return (p1 - p2).magnitude;
    }

    public static float Dot(Vector lhs, Vector rhs)
    {
        return lhs.x * rhs.x + lhs.y * rhs.y;
    }

    public static float Cross(Vector lhs, Vector rhs)
    {
        return lhs.x * rhs.y - lhs.y * rhs.x;
    }

    public static Vector Project(Vector vec, Vector on)
    {
        return vec.Dot(on) / on.sqrMagnitude * on;
    }

    public static Vector Lerp(Vector from, Vector to, float t)
    {
        return (1 - t) * from + t * to;
    }
}