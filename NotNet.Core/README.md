#NotNet.Core

Bells and whistles-less IoC-thingy.

##Service location examples

Register an interface with an implementing class

`NotNet.Core.Container.Default.Register<ITest,Test>();`

Resolve it...

`var test = NotNet.Core.Container.Default.Resolve<ITest>();`


Register a class as a singleton**

`NotNet.Core.Container.Default.RegisterSingleton<Test>();`

Resolve it...

`var test = NotNet.Core.Container.Resolve<Test>();`

Resolve it again and it will be the same instance.

It is possible to to register and resolve multiple implementations for one interface. Resolve them with `ResolveAll<T>()`.
Using `Resolve<T>()` for an interface with multiple implementations will resolve the implementation that was registered first.




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
It's possible to pass "non-resolvable" objects to the constructor as well.
`Container.Default.Resolve<ISomeInterface>(arg);`

**Restriction:** The "non-resolvable" object(s) must be the last arguments in the constructor. Resolvable objects are injected first.

##Notes

* The container itself is resolvable as IContainer (it's not possible to roll your own container yet)

##More

Have a look in the test-project for more examples
