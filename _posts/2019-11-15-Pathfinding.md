---
layout: post
tags: [pathfinding steering behaviour]
---
下图为类A\*寻路算法伪代码，从左至右分别为A\*, Theta\*, Lazy Theta\*
<img src="{{ site.url }}/assets/images/pathfinding-pesudo-code.png" width="100%">

注: 已知寻路算法(*除1外，其他寻得的结果可能不是最短路径*)
1. Dijkstra
2. A* with post smoothing
3. Theta\*
4. [Lazy Theta\*]({{ site.url }}/assets/pdf/Lazy-Theta.pdf)
5. Field D*
6. B*

使用A\*算法估算寻路路径，在寻路过程中尝试避免碰撞，可用模型如下
1. [Steering Behaviors](http://www.red3d.com/cwr/steer/)
2. [RVO(Reciprocal Velocity Obstacle)](http://gamma.cs.unc.edu/RVO/icra2008.pdf)
3. [ORCA(Optimal Reciprocal Collision Avoidance)](http://gamma.cs.unc.edu/ORCA/publications/ORCA.pdf)