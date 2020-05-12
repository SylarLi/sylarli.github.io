---
layout: post
tags: [war fog]
---
战争迷雾的实现方式
1. 计算迷雾Mask贴图
> 将整体地图抽象成为2D贴图，每个像素点对应一个迷雾区域。每个区域的可见性（是否被迷雾遮盖）通过[FOV](http://roguebasin.roguelikedevelopment.org/index.php?title=Category:FOV)的方式进行计算。

2. (为了得到更好的效果，可对Mask贴图做模糊处理), 将Mask贴图投影到场景上