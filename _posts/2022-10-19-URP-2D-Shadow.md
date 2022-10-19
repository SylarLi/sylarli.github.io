---
layout: post
tags: [unity3d urp 2d shadow]
---
URP2D中生成Sprite阴影的步骤：
1. 添加2D光源；
2. 为SpriteRenderer添加ShadowCaster2D对象，并定义ShapePath(即渲染阴影的多边形)，运行时会采用[^LibTessDotNet]生成mesh；
3. 生成的mesh数据结构如下：
	: vertex		顶点
	: tangent		顶点所在边缘的垂线，用来判断是否做Raycasting
	: extrusion		xy为当前顶点，zw为所在边缘相连的另一个顶点

渲染阴影使用GPU Shadow Raycasting的方式。如果判断当前顶点所在边缘的垂线与光源方向反向，则将其向光源反方向位移一定的距离(由ShadowRadius控制)，如果同向则不移动。最终渲染出来的图形就是阴影。
当然，URP过程中还是用了其他的优化方式，以获得较为平滑的阴影。例如计算顶点位移方向时，没有直接使用当前顶点进行计算，而是取当前顶点和其相连的另一个顶点计算的光源方向的中间值。

实际使用过程中，每一个caster平均要产生3\~4个额外的DC，开销不小。但是估计可以通过阉割效果最少减少到1个DC，不过即使这样渲染大量实时阴影时对移动设备仍然不太友好，而且目前URP尚不支持2D的光照烘焙，要想支持的话只有魔改URP了。


[^LibTessDotNet]: <https://github.com/speps/LibTessDotNet>