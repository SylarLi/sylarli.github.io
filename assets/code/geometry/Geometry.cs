public static class Geometry
{
    /// <summary>
    /// 两点求直线
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="line"></param>
    /// <returns></returns>
    public static bool CalcLine(Vector p1, Vector p2, out Line line)
    {
        var dir = p1 - p2;
        var sqr_d = dir.sqrMagnitude;
        if (sqr_d == 0)
        {
            line = default(Line);
            return false;
        }
        var d = (float) MathS.Sqrt(sqr_d);
        var normal = new Vector(-dir.y, dir.x) / d;
        line = new Line(normal, p1);
        return true;
    }

    /// <summary>
    /// 求圆外某点和圆的切线
    /// </summary>
    /// <param name="c"></param>
    /// <param name="r"></param>
    /// <param name="p"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <returns></returns>
    public static int CalcCirclePointTangentLines(Vector c, float r, Vector p, out Line t1, out Line t2)
    {
        var d = Vector.Distance(c, p);
        Vector p1, p2;
        var count = CalcCirclePointTangentPoints(c, r, p, out p1, out p2);
        if (count == 0)
        {
            t1 = default(Line);
            t2 = default(Line);
            return 0;
        }
        CalcLine(p, p1, out t1);
        if (count == 1)
        {
            t2 = default(Line);
            return 1;
        }
        CalcLine(p, p2, out t2);
        return 2;
    }

    /// <summary>
    /// 求圆外某点和圆的切点
    /// </summary>
    /// <param name="c"></param>
    /// <param name="r"></param>
    /// <param name="p"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static int CalcCirclePointTangentPoints(Vector c, float r, Vector p, out Vector p1, out Vector p2)
    {
        p1 = new Vector();
        p2 = new Vector();
        var sqr_d = (c - p).sqrMagnitude;
        var sqr_r = r * r;
        if (sqr_d <= sqr_r)
            return 0;
        return CalcCircleCircleIntersections(c, r, p, (float) MathS.Sqrt(sqr_d - sqr_r), out p1, out p2);
    }

    /// <summary>
    /// 求圆和圆的交点
    /// </summary>
    /// <param name="c1"></param>
    /// <param name="r1"></param>
    /// <param name="c2"></param>
    /// <param name="r2"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static int CalcCircleCircleIntersections(Vector c1, float r1, Vector c2, float r2, out Vector p1,
        out Vector p2)
    {
        p1 = new Vector();
        p2 = new Vector();
        var sqr_d = (c1 - c2).sqrMagnitude;
        var sqr_r1r2 = (r1 + r2) * (r1 + r2);
        var sqr_r1r2_m = (r1 - r2) * (r1 - r2);
        if (sqr_d > sqr_r1r2 ||
            sqr_d < sqr_r1r2_m ||
            (sqr_d == 0 && r1 == r2))
            return 0;
        var d = MathS.Sqrt(sqr_d);
        var sqr_r1 = r1 * r1;
        var sqr_r2 = r2 * r2;
        var a = (sqr_r1 - sqr_r2 + sqr_d) / (d + d);
        var h = MathS.Sqrt(sqr_r1 - a * a);
        var px = c1.x + a * (c2.x - c1.x) / d;
        var py = c1.y + a * (c2.y - c1.y) / d;
        if (h == 0)
        {
            p1.x = px;
            p1.y = py;
            return 1;
        }

        var hdx = h / d * (c2.y - c1.y);
        var hdy = h / d * (c2.x - c1.x);
        p1.x = px + hdx;
        p1.y = py - hdy;
        p2.x = px - hdx;
        p2.y = py + hdy;
        return 2;
    }
}