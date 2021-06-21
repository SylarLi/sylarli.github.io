---
layout: post
tags: [unity3d post process camera universal urp transparent overlay]
---
URP支持Base相机之间进行叠加，只需要将上层相机的*Background Type*设置为*Unitialized*即可，此参数对应*CameraClearFlag.Nothing*，相当于不清理所有的*renderer buffer*（交由下层相机进行清理）。由于上层相机进行渲染时*depth buffer*亦未被清理，可能会导致*depth test*出现问题。建议一般用于3d模型叠加在ui之上的场景。

如果上层相机需要开启后处理，以上叠加方式可能就不适用了。因为后处理也会对下层相机的渲染结果产生影响（*color buffer*未被清理）。例如下图，主相机的bloom效果对ui也产生了影响：

<img src="{{ site.url }}/assets/images/urp_camera_overlay_post_effect_issue_1.png" width="100%">

如果想要规避这种情形，可以使用RenderTexture的渲染方式。将3d相机的内容渲染到一张RenderTexture上，再以贴图的形式嵌入到ui之中（例如UGUI的RawImage）。但是这样又会出现另外一个问题：URP开启后处理就不支持渲染到半透明贴图了。表现如下：

<img src="{{ site.url }}/assets/images/urp_camera_overlay_post_effect_issue_2.png" width="100%">

这是因为3d相机单独渲染之后，不能将*Background Type*设置为*Unitialized*（如果设置会导致*render buffer*不被清理，渲染出现问题）。修改为*SolidColor*后半透明就没有效果了，并且设置alpha值为0也不起效。这是因为URP开启后处理之后本身不支持渲染到半透明贴图。只能通过修改URP源码的方式使其支持。最终效果如下：

<img src="{{ site.url }}/assets/images/urp_camera_overlay_post_effect_issue_3.png" width="100%">

可以看到后处理只对3d相机产生效果，不会影响ui并且和ui正确叠加。
但是因为引入alpha通道之后，会存在一些问题：
1. bloom后处理的视觉效果与原生不相同；
2. alpha通道锯齿（FXAA不对alpha通道做抗锯齿）。

注:
1. 测试版本unity2019.4.27f1，URP7.6.0
2. 测试源码<https://github.com/SylarLi/TestURP.git>
