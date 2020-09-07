---
layout: post
tags: [math fixed point]
---
定点数小数表示法，主要用于早期的计算机中，相对于其他数值表示方法其最节省硬件。但随着性能提升，后来逐渐被浮点数计算单元取代。

定点数一般是一个位数固定的数值，划分某几位表示整数部分，其余部分表示小数部分。
```
i1.i2.i3...i32.f1.f2.f3...f32
```
以上表示了一个Q32.32的无符号位定点数，其中`in`为整数位，共计32位；`fn`为小数位，亦共计32位。每一位对应一个机器字节的比特位(bit)。可以看出小数位的数值存储形式和整数相同，但其实际表达意义不相同。假设小数位表示的整数数值为`fx`，则其表示的小数数值为`fx / 2^32`，精度为`1 / 2^32`。很明显，定点数的小数精度和小数位数呈正相关，小数位数越多，表示的精度范围越精确。

如果需要表示有符号位定点数，可以将首位设置为符号位，即表示为S1Q31.32的有符号位定点数。负数的存储方式和整数相同，使用补码的形式进行编码。

定点数的基础运算（加减乘除求余等）只能进行软件实现，通用计算机基本上没有提供硬件上的支持。
1. 加减法比较简单，注意进位和退位即可；
2. 乘法：需要将乘数拆分为整数部分和小数部分ai、af，将被乘数同样拆分为bi、bf,然后分解计算(ai + af) * (bi + bf)，注意进位；
3. 除法和求余较为复杂，请自行参考网上资料。

定点数的数值运算（例如sqrt，exp，log，三角函数等）有多种方式可以计算，常用的方式有CORDIC，Minimax Polynomial Approximate等，辅以shift and add，Horner method等方式提高计算效率。

CORDIC的计算原理可以参考这篇文章[an-introduction-to-the-cordic-algorithm](https://www.allaboutcircuits.com/technical-articles/an-introduction-to-the-cordic-algorithm/)，代码实现可以参考这里[c-codes-for-cordic](https://cordic-bibliography.blogspot.com/p/c-codes-for-cordic.html)

Minimax Polynomial Approximate是通过多项式的方式，在某个较小范围内无限逼近原函数曲线（其余范围可通过公式转换求得）。下面用以2为底对数(Log2)的求解为示例进行说明：

`log2(x) = log2(2^n * (1 + y)) = log2(2^n) + log2(1 + y) = n + log2(1 + y)` `0 <= y < 1`

最终转换为求值： `log2(1 + y)` `0 <= y < 1`

通过remez算法求解最佳逼近多项式的系数，这里直接使用python的numpy库的polyfit函数进行系数求值：

{% highlight py %}
import numpy as np
func = lambda x: np.log2(1 + x)								# 声明求值函数
range = np.linspace(start, end, 10000)						# 声明逼近范围[start, end)，且平均取10000个采样点
coffs = np.polyfit(range, func(range), 4)					# 逼近的多项式为4阶，求值多项式系数(Horner method形式)
{% endhighlight %}

假设最终得到的系数为`[c0, c1, c2, c3, c4]`(4阶对应5个系数)，可以求得`log2(1 + y)` `0 <= y < 1`的近似解为`c4 + y * (c3 + y * (c2 + y * (c1 + c0 * y)))`

之所以称之为近似解，是因为多项式逼近求解的值与原值存在一定大小的误差，如果我们将最大误差控制在最小(minimax)且最大误差能够符合精度要求，那么逼近就算是成功了。将最大误差最小化的方法有多种，最直接的方式就是提升多项式阶数。另外一种方法是缩小逼近范围，例如将逼近范围平均切分为n份，对每份范围进行多项式逼近求解，把获得的所有系数合并成为一份查找表(lookup table)。当具体求解某个值时，再根据其所在的逼近范围获取对应的多项式系数进行计算。示例代码如下：

{% highlight py %}
import numpy as np
import warnings
warnings.filterwarnings("ignore")

def gen_poly(poly_order, range, func):
	return np.polyfit(range, func(range), poly_order)

func = lambda x: np.log2(1 + x)

# 估算minimax error
# ran = np.linspace(0, 0.125, 1000000)
# reg = gen_poly(5, ran, func)
# val_approx = np.polyval(reg, ran)
# val_raw = func(ran)
# print('maximum error: ' + str(np.max(val_approx - val_raw)))

size = 8
poly_order = 5
for i in range(size):
	start = float(i) / size
	end = float(i + 1) / size
	ran = np.linspace(start, end, 1000000)
	reg = gen_poly(poly_order, ran, func)
	hnr = np.asarray(reg, dtype=np.float64)
	for c in hnr:
		print("" + str(c) + ","),
{% endhighlight %}

以上代码会将范围[0, 1)平均分为8份，求解每份范围的多项式系数，最终打印出系数查找表。

还有一种土方法就是提升计算过程中数值的表示精度。例如将Q32.32的定点数转换为Q64.64，提升精度，减少中间值的误差损失。