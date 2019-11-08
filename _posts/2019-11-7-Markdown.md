---
layout: post
tags: [markdown syntax guide]
---
Markdown的语法简单说明

**分隔线**

	***

***

# 一级标题
## 二级标题
### 三级标题
#### 四级标题
##### 五级标题
###### 六级标题 {#ref-id}

	# 一级标题
	## 二级标题
	### 三级标题
	#### 四级标题
	##### 五级标题
	###### 六级标题 {#ref-id}

***

*斜体*  
**粗体**  
***粗斜体***

	*斜体*  
	**粗体**  
	***粗斜体***

***

~~删除线~~  
<u>下划线</u>

	~~删除线~~ 
	<u>下划线</u>

***

正文[^Tips1]正文[^Tips2]

[^Tips1]: 脚注提示1
[^Tips2]: 脚注提示2

```
正文[^Tips1]正文[^Tips2]

[^Tips1]: 脚注提示1
[^Tips2]: 脚注提示2
```

***

**无序列表**

* 第一个
* 第二个
* 第三个

```
*[+][-] 第一个
*[+][-] 第二个
*[+][-] 第三个
```

**有序列表**

1. 第一个
2. 第二个
3. 第三个

```
1. 第一个
2. 第二个
3. 第三个
```

**嵌套列表**

1. 第一个
    * 子第一个
    * 子第二个
    * 子第三个
2. 第二个
    * 子第一个
    * 子第二个
    * 子第三个
3. 第三个
    * 子第一个
    * 子第二个
    * 子第三个

```
1. 第一个
    *[+][-] 子第一个
    *[+][-] 子第二个
    *[+][-] 子第三个
2. 第二个
    *[+][-] 子第一个
    *[+][-] 子第二个
    *[+][-] 子第三个
3. 第三个
    *[+][-] 子第一个
    *[+][-] 子第二个
    *[+][-] 子第三个
```

**定义列表**

第一个
: 子第一个
: 子第二个

第二个
: 子第一个
: 子第二个

```
第一个
: 子第一个
: 子第二个

第二个
: 子第一个
: 子第二个
```

**任务列表**

- [x] 第一项通过
- [ ] 第二项未通过
- [ ] 第三项未通过

```
- [x] 第一项通过
- [ ] 第二项未通过
- [ ] 第三项未通过
```

***

**区块**

> 第一层区块
>> 第二层区块
>>> 第三层区块

	> 第一层区块
	>> 第二层区块
	>>> 第三层区块

**区块中列表**

> 区块
> * 第一个
> * 第二个

	> 区块
	> * 第一个
	> * 第二个

**列表中区块**

* 第一个
	> 区块1

	> 区块2

* 第二个
	> 区块1

	> 区块2

```
* 第一个
	> 区块1

	> 区块2

* 第二个
	> 区块1

	> 区块2
```

***

**代码片段**

`printf()`

	`printf()`

**使用制表符缩进**

	int main() {
		printf("hello world!");
	}

```
	int main() {
		printf("hello world!");
	}
```

**Markdown方式**

```c
int main() {
	printf("hello world!");
}
```

	```c
	int main() {
		printf("hello world!");
	}
	```

**Liquids方式**

{% highlight c linenos %}
int main() {
	printf("hello world!");
}
{% endhighlight %}

	{% raw %}
	{% highlight c linenos %}
	int main() {
		printf("hello world!");
	}
	{% endhighlight %}
	{% endraw %}

***

**直接链接**

<http://www.baidu.com>

	<http://www.baidu.com>

**链接(别名)**

[链接名称](http://www.baidu.com)

```
[链接名称](http://www.baidu.com)
```

**链接(引用)**

[链接名称][Reference]

[Reference]: http://www.baidu.com
```
[链接名称][Reference]

[Reference]: http://www.baidu.com
```

**页面内跳转**

[跳转到六级标题](#ref-id)

**链接文字**

`http://www.baidu.com`

	`http://www.baidu.com`

***

**图片**

![alt替代文字]({{ site.url }}/assets/images/markdown-image-example.png)

	{% raw %}
	![alt替代文字]({{ site.url }}/assets/images/markdown-image-example.png)
	{% endraw %}

**HTML图片**

<img src="{{ site.url }}/assets/images/markdown-image-example.png" width="32px">

	{% raw %}
	<img src="{{ site.url }}/assets/images/markdown-image-example.png" width="40%">
	{% endraw %}

***

**表格**

|表头|表头|表头|
|:-|-:|:-:|
|左对齐|右对齐|居中对齐|
|1|1|1|
|2|2|2|

	|表头|表头|表头|
	|:-|-:|:-:|
	|左对齐|右对齐|居中对齐|
	|1|1|1|
	|2|2|2|

***