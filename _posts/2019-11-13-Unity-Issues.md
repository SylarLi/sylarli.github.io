---
layout: post
tags: [unity3d issues]
---
#### Unity2017.4.5

1. TextMesh默认的Material始终会显示在最上层，原因是其Shader开启了`ZTest Always`。如果需要显示正确的遮挡关系，则需修改Shader为`ZTest On`，并且在运行时重新设定Material的Shader。

#### Unity2018.4.10

1. 使用AssetPostprocessor的一些注意事项

	> * 如果导入的UnityPackage中有脚本文件，OnPostprocessAllAssets会被触发两次，第一次导入脚本资源，第二次导入其他资源;

	> * 如果导入的UnityPackage中有工程中已经存在的Shader，则会把工程中已经存在的Shader删除，保留新导入的相同Shader。

#### Unity2018.4.14

1. 导入unitypackage时，unity会自动判断资源是否存在(估计是通过hash值方式进行判断，因为即使资源路径不同也只是提示刷新资源)。这样会出现某种意义上的副作用，例如在不同的prefab依赖相同的资源的情况下，根据prefab分别导出两个包，再导入unity之后相同的资源只会存在一份。