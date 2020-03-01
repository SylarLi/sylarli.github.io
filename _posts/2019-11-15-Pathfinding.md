---
layout: post
tags: [pathfinding steering behaviour collision avoidance]
---
下图为类A\*寻路算法伪代码，从左至右分别为A\*, Theta\*, Lazy Theta\*
<img src="{{ site.url }}/assets/images/pathfinding-pesudo-code.png" width="100%">

注: 已知寻路算法(*除1外，其他寻得的结果可能不是最短路径*)
1. Dijkstra
2. A*
3. [[Lazy] Theta\*]({{site.url}}/assets/pdf/Lazy-Theta.pdf)
4. D\*(Dynamic A\*)
5. [ARA\*]({{site.url}}/assets/pdf/ARA_-Anytime-A_-with-Provable-Bounds-on-Sub-Optimality.pdf)
6. [Block A\*]({{site.url}}/assets/pdf/Block-A_-Database-Driven-Search-with-Applications-in-Any-angle-Path-Planning.pdf)

使用A\*算法估算寻路路径，在寻路过程中尝试避免碰撞，可用模型如下
1. [Steering Behaviors](http://www.red3d.com/cwr/steer/)
2. [RVO(Reciprocal Velocity Obstacle)](http://gamma.cs.unc.edu/RVO/icra2008.pdf)
3. [ORCA(Optimal Reciprocal Collision Avoidance)](http://gamma.cs.unc.edu/ORCA/publications/ORCA.pdf)

寻路算法的优化，摘抄自<https://www.ituring.com.cn/article/21938>

	人们已经提出了许多提高寻路速度的技术。其中大多数可以被分为三类：

	1. 通过抽象缩小搜索区域：这种类型的算法速度快、内存占用小，但得到的路径通常都不是最优的，需要通过进一步的搜索进行改善。典型例子：HPA*，MM-Abstraction。

	2. 改进引导搜索的启发式函数的精确度：这种类型的算法通常会预先计算并保存区域中的一些关键节点之间的距离。虽然它们的速度很快而且得到的解是最优的，但常常会消耗过多的内存。典型例子：地标法，True Distance Heuristics。

	3. 歧路检测和其他状态空间的剪枝(state-space pruning)算法：这种类型的算法大都会通过识别地图上无需探索的区域来最优化的到达目的地。虽然速度不及抽象式或是基于内存的启发式搜索，但此类算法消耗的内存还是很低，并能将寻路性能提高若干倍。典型例子：Dead-end Heuristic，Swamps，Portal Heuristic。

	4. Rectangular Symmetry Reduction与文章所介绍的Jump Point Search，以在网格地图上识别并消除对称路径的方式来提高寻路性能。

1. [JPS(Jump Point Search)]({{site.url}}/assets/pdf/Online_Graph_Pruning_for_Pathfinding_On_Grid_Maps.pdf)(仅只用于代价均匀的格子寻路)