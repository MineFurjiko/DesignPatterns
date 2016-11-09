using DesignPatterns.Patterns._01_Factory.Abstract_Factory;
using DesignPatterns.Patterns._01_Factory.Factory_Method;
using DesignPatterns.Patterns._01_Factory.Simple_Factory;
using DesignPatterns.Patterns._02_Singleton;
using DesignPatterns.Patterns._03_Builder;
using DesignPatterns.Patterns._04_Prototype;
using DesignPatterns.Patterns._05_Adapter;
using DesignPatterns.Patterns._06_Bridge;
using DesignPatterns.Patterns._07_Decorator;
using DesignPatterns.Patterns._08_Composite;
using DesignPatterns.Patterns._09_Facade;
using DesignPatterns.Patterns._10_Flyweight;
using DesignPatterns.Patterns._11_Proxy;
using DesignPatterns.Patterns._12_TemplateMethod;
using DesignPatterns.Patterns._13_Command;
using DesignPatterns.Patterns._14_Iterator;
using DesignPatterns.Patterns._15_Observer;
using DesignPatterns.Patterns._16_Mediator;
using DesignPatterns.Patterns._Base;
using System;
using System.Linq;
using System.Text;

namespace DesignPatterns {
	class Program {
		static void Main() {
			IMain program;

			#region 创建型模式

			//01_Factory : http://blog.csdn.net/hguisu/article/details/7505909
			//program = new SimpleFactoryTest();
			//program = new FactoryMethodTest();
			//program = new AbstractFactoryTest();

			//02_Singleton : http://blog.csdn.net/hguisu/article/details/7515416
			//program = new SingletonTest();

			//03_Builder : http://blog.jobbole.com/78069/
			//program = new BuilderTest();

			//04_Prototype : http://blog.jobbole.com/78071/
			//program = new PrototypeTest();

			#endregion

			#region 结构型模式

			//05_Adapter : http://tracefact.net/Design-Pattern/Adapter.aspx
			//program = new AdapterTest();

			//06_Bridge : http://blog.jobbole.com/78075/ & http://www.cnblogs.com/zhenyulu/articles/67016.html
			//program = new BridgeTest1();
			//program = new BridgeTest2();

			//07_Decorator : http://blog.jobbole.com/78077/
			//program = new DecoratorTest();

			//08_Composite : http://blog.jobbole.com/78079/
			//program = new CompositeTest1();
			//program = new CompositeTest2();

			//09_Facade : http://blog.jobbole.com/78081/
			//program = new FacadeTest();

			//10_Flyweight : http://blog.jobbole.com/78083/ & http://www.cnblogs.com/zhenyulu/articles/55793.html
			//program = new FlyweightTest();

			//11_Proxy : http://blog.jobbole.com/78086/
			//program = new ProxyTest();

			#endregion

			#region 行为型模式

			//12_TemplateMethod : http://blog.jobbole.com/78088/
			//program = new TemplateMethodTest();

			//13_Command : http://www.cnblogs.com/zhenyulu/articles/69858.html & http://tracefact.net/Design-Pattern/Command.aspx
			//program = new CommandTest1();
			//program = new CommandTest2();
			//program = new CommandTest3();

			//14_Iterator : http://blog.jobbole.com/78117/
			//program = new IteratorTest();
			//program = new dotNetIteratorTest();

			//15_Observer : http://blog.jobbole.com/78119/
			//program = new ObserverTest();
			//program = new ObserverTest2();
			//program = new ObserverInDotNet();

			//16_Mediator : http://blog.jobbole.com/78124/
			program = new MediatorTest();

			#endregion

			program.AppMain();
		}
	}
}
