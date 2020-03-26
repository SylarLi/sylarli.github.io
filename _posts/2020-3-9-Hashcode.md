---
layout: post
tags: [hashcode map integer]
---
计算两个正整数的hashcode的方法：
1. [Elegant Pairing Function]({{ site.url }}/assets/pdf/ElegantPairing.pdf), 将两个正整数映射到一个正整数。可扩展到多个正整数。
{% highlight c# %}
return x >= y ? (x * x + x + y) : (y * y + x)
{% endhighlight %}
