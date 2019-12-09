---
layout: post
tags: [geometry math]
---
1. 判断圆和矩形是否(部分)重叠
{% highlight c# linenos %}
// rect定义矩形，center为圆心，radius为半径
bool CheckIntersection(Rect rect, Vector center, float radius) {
	var dx = MathS.Clamp(center.x, rect.minX, rect.maxX) - center.x;
	var dy = MathS.Clamp(center.y, rect.minY, rect.maxY) - center.y;
	var rr = radius * radius;
	return dx * dx + dy * dy <= rr;
}
{% endhighlight %}