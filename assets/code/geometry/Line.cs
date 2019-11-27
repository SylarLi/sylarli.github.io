public struct Line
{
    public Vector normal;

    public float distance;

    public Line(Vector normal, Vector point)
    {
        this.normal = normal;
        distance = Vector.Dot(point, normal);
    }

    public Line(Vector normal, float distance) 
    {
        this.normal = normal;
        this.distance = distance;
    }
}