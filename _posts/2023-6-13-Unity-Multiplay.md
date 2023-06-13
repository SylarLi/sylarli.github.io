---
layout: post
tags: [unity multiplay]
---
## Unity multiplay(Game Server Hosting)

自动伸缩计费
* CPU: 0.038/core per hour
* RAM: 0.0051/GB per hour
* Network: 0.14/GB
* Storage: 0.2/GB per month
* OS: Linux free

费用估算(4C 16G 64GB)
* CPU: 4 * 730 * 0.038 = 110.96
* RAM: 4 * 730 * 0.0051 = 14.892
* Network: 按每玩家每帧300B同步数据量，每天游玩1小时，单个玩家300 * 60 * 60 * 60 * 1 * 30 / 1024 / 1024 / 1024 * 0.14 = 0.25346875190734863
* Storage: 64 * 0.2 = 12.8


粒度最小为server(game session server)，运行在配置的machine上，归属于某个region的fleet

一个server就是启动的unity instance，在启动之后会处于Available状态，为保障伸缩性Multiplay会维护一个server pool，按配置保证fleet中状态为Avalible状态的server数量
启动后的server大致会有以下几个状态:
1. Online 刚启动
2. Available 可用，等待玩家匹配连接，存在pool中
3. Allocated 已分配，已被分配使用，会从pool中移除掉

Allocation steps:
* The matchmaker groups players for a game session.
* The matchmaker requests an allocation from the Game Server Hosting (Multiplay) API, and Game Server Hosting queues the allocation request.
* Game Server Hosting asynchronously finds the best server for the game session based on the parameters of the allocation request.
* Game Server Hosting removes the selected server from the available servers pool and marks it as allocated.
* Game Server Hosting applies configurations from the build configuration to the server and ensures the server is ready.
* Game Server Hosting returns the server information to the matchmaker when the server is ready.

Deallocation steps:
* A game session completes, the players disconnect, and any post-session cleanup completes.
* The matchmaker requests a deallocation from the Game Server Hosting API.
* Game Server Hosting queues the deallocation request.
* Game Server Hosting clears the allocation ID from the earlier allocation.
* Game Server Hosting returns the server to the available server pool so it’s available for the next game session.

可通过REST API与Game Server Hosting Service进行交互


## MatchMaking API

* Ticket 玩家的一次匹配请求
* Queue 可以匹配到一起的Tickets会塞到同一个Queue中，一般是按游戏模式区分
* Pool 一个Queue包含了多个Pool，每个Pool能将若干满足过滤条件的Tickets匹配到一起
* BackfillTickets支持游戏运行中实施匹配

连接步骤：
1. client创建Ticket，定时去GetTicket状态
2. server订阅MultiplayService的事件
3. server等待MultiplayService的Allocation
4. server等待Matchmaking的Allocation payload，payload中包含了client的Ticket中的自定义数据
5. server开启Backfill
6. server启动game session server并等待玩家加入
7. client GetTicket成功，拿到MatchMaking返回的数据开始连接game session server（例如使用matchId作为sessionName连接Phonton）

## Authentication
## Economy
## Cloud Save
## Cloud Code

