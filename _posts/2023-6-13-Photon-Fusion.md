---
layout: post
tags: [photon fusion]
---
Two Mode
1. Hosted Mode
	* server has full and exclusive State Authority over all objects.
2. Shared Mode
	* each client initially has State Authority over objects they spawn, but are free to release that State Authority to other clients.

The Basics
1. NetworkRunner
	* for networking and simulation
2. NetworkObject
	* assign a network identity in runtime for unity prefab or scene object, and let it be part of the synchronized tick-based simulation
3. NetworkBehaviour
	* hold the properties that can be serialized

Each client simulation ticks is slightly different, so dont sync Runner.Ticks to other clients.

~~如果声明了sessionName，photon会忽略连接参数的中的lobbyName~~并不是，是因为没有声明lobbyName，导致匹配时忽略了这个条件

CS模式，如果Server断开会导致Client Connection时间过长，解决方法：
1. Client增加连接超时机制
2. Server延长无连接断开时间

客户端A进行某种操作时
1. A立即响应，播放特效或者音效
2. 同步服务器S，S处理同步给所有客户端
3. 客户端收到包后进行处理，注意A与其他客户端的表现不同，因为A的某些特效或着音效先行播放了