---
layout: post
tags: [Shadowsocks 翻墙]
---
docker安装SS方式：
1. mritd/shadowsocks
{% highlight os %}
docker pull mritd/shadowsocks
{% endhighlight %}
{% highlight shell %}
docker run -dt --name ssserver -p 10081:10081 mritd/shadowsocks -m "ss-server" -s "-s 0.0.0.0 -p 10081 -m aes-256-cfb -k password --fast-open"
{% endhighlight %}