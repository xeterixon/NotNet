#NotNet.Core

Bells and whistles-less IoC-thingy.

##Service location examples

**Register an interface with an implementing class**

`NotNet.Core.Container.Default.Register<ITest,Test>();`

**Resolve it...**

`var test = NotNet.Core.Container.Default.Resolve<ITest>();`


**Register a class as a singleton**

`NotNet.Core.Container.Default.RegisterSingleton<Test>();`

**Resolve it...**

`var test = NotNet.Core.Container.Resolve<Test>();`

**Resolve it again and it will be the same instance.**

##Basic constructor injection

```
using NotNet.Core;
public class Test1{}
public class Test2
{
	public Test2(Test1 test1){}
}

public static void Main(string[] args)
{
	Container.Default.Register<Test1>();
	Container.Default.Register<Test2>();
	
	// Create an instance of Test2. The constructor argument will 
	// be resolved and injected
	var t2 = Container.Default.Resolve<Test2>();
	
}
```
##More

Have a look in the test-project for more examples