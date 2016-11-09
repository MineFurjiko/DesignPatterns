using DesignPatterns.Patterns._Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._10_Flyweight {
	/// <summary>
	///  抽象享元类，提供具体享元类具有的方法
	/// </summary>
	public abstract class Flyweight {
		public abstract void Operation(int extrinsicstate);
	}

	/// <summary>
	/// 具体的享元对象
	/// </summary>
	public class ConcreteFlyweight : Flyweight {
		//内部状态
		private string intrinsicstate;

		public ConcreteFlyweight(string innerState) {
			this.intrinsicstate = innerState;
		}
		/// <summary>
		/// 享元类的实例方法
		/// </summary>
		/// <param name="extrinsicstate">外部状态</param>
		public override void Operation(int extrinsicstate) {
			Console.WriteLine("具体实现类: intrinsicstate {0}, extrinsicstate {1}",
				intrinsicstate, extrinsicstate);

		}
	}

	/// <summary>
	/// 享元工厂，负责创建和管理享元对象
	/// </summary>
	public class FlyweightFactory {
		
		public Hashtable flyweights = new Hashtable();
		public FlyweightFactory() {
			flyweights.Add("A", new ConcreteFlyweight("A"));
			flyweights.Add("B", new ConcreteFlyweight("B"));
			flyweights.Add("C", new ConcreteFlyweight("C"));
		}

		public Flyweight GetFlyweight(string key) {

			Flyweight flyweight = flyweights[key] as Flyweight;
			if (flyweight == null) {
				Console.WriteLine("驻留池中不存在字符串:" + key);
				flyweight = new ConcreteFlyweight(key);
				flyweights.Add(key, flyweight);
			}
			return flyweight;
		}
	}

	class FlyweightTest : IMain {
		public void AppMain() {
			// 定义外部状态，例如字母的位置等信息
			int externalstate = 10;
			// 初始化享元工厂
			FlyweightFactory factory = new FlyweightFactory();

			// 判断是否已经创建了字母A，如果已经创建就直接使用创建的对象A
			Flyweight fa = factory.GetFlyweight("A");
			if (fa != null) {
				// 把外部状态作为享元对象的方法调用参数
				fa.Operation(--externalstate);
			}
			// 判断是否已经创建了字母B
			Flyweight fb = factory.GetFlyweight("B");
			if (fb != null) {
				fb.Operation(--externalstate);
			}
			// 判断是否已经创建了字母C
			Flyweight fc = factory.GetFlyweight("C");
			if (fc != null) {
				fc.Operation(--externalstate);
			}
			// 判断是否已经创建了字母D
			Flyweight fd = factory.GetFlyweight("D");
			if (fd != null) {
				fd.Operation(--externalstate);
			}
			Flyweight fd2 = factory.GetFlyweight("D");
			if (fd != null) {
				fd.Operation(--externalstate);
			}

		}
	}
}