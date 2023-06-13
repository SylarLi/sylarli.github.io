---
layout: post
tags: [sky striker optimization]
---
# Optimize 提高同屏人数

## 客户端

### 渲染

角色: 调整shader为`Unlit`，屏蔽非必要半透明渲染，屏蔽部分效果

### MTeamConsole

列表数量过多，且每帧都在刷新: 暂时屏蔽enabled设为false

### MFSM

`FixedUpdateNetwork`调用次数过多: 增加判定在`Resimulation`期间无需执行

### RunClientSidePredictionLoop

`StepSimulation`次数太多: 减小`Simulation Max Prediction`，或者判定无需在`Resimulation`期间执行

### NetworkProjectConfig

1. `Fusion Allocator`分配的堆内存溢出: 调高`Heap Page Size`
2. 调高`Max Networked Object Count`
3. 调高`Hitbox Capacity`

### 当同屏角色数量增加到60时

Profiler

1. `Client Hitbox Manager`: MPlayer的HitBoxRoot.InitHitBox()仅在拥有HasInputAuthority和HasStateAuthority调用
2. `Hand.Update`: 仅在拥有HasInputAuthority是激活AutoHand
3. `VelocityTracker.Update`: 仅在拥有HasInputAuthority和HasStateAuthority时激活
4. `PlayerMaterials.LateUpdate`: 降低执行频率

## 服务器

### MHitter

LagCompensation.OverlapXXX占用过高
