using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//代理模式:就是给某一个对象提供一个代理，并由代理对象控制对原对象的引用。
//在一些情况下，一个客户不想或者不能直接引用一个对象，而代理对象可以在客户端和目标对象之间起到中介的作用。
namespace DesignPatterns.Patterns._11_Proxy {
	/// <summary>
	/// 代购能力接口
	/// </summary>
	public interface IProcurementService {
		void GoAbroad();
		void AcceptOrders(string order);
	}

	// 抽象主题角色
	public abstract class Person {
		public Person(string name) { this.Name = name; Console.WriteLine("我是 "+this.Name); }
		public string  Name { get; set; }
		public bool isAbroad { get; protected set; }
		public abstract void BuyProduct(AbroadShop shop);
	}

	//真实主题角色
	public class RealBuyPerson : Person {
		public RealBuyPerson(string name):base(name) {  }
		public override void BuyProduct(AbroadShop shop) {
			if (!shop.checkAbroad(this)) {
				Console.WriteLine("我无法出国购买奶粉！");
			}
		}
		public void CallProxyBuySomethings(IProcurementService proxy,string ProductName) {
			proxy.AcceptOrders(Name+" 需要代购 "+ProductName);
		}
	}

	// 代理角色
	public class AbroadProxy : Person, IProcurementService {
		private List<string> orders = new List<string>();
		public AbroadProxy(string name) : base(name) { }

		public override void BuyProduct(AbroadShop shop) {
			if (!shop.checkAbroad(this)) {
				Console.WriteLine("我也未出国");
				return;
			}
			Console.WriteLine("我成功到达海外商店!");
			Console.WriteLine("我正在代购清单物品...");
			Console.WriteLine("购买结束！不负众望！");
		}

		public void GoAbroad() {
			Console.WriteLine("我出国了！");
			this.isAbroad = true;
		}

		public void AcceptOrders(string order) {
			orders.Add(order);
		}

		public void PrintOrders() {
			Console.WriteLine("打印代购清单...");
			foreach (var item in orders) {
				Console.WriteLine(item);
			}
			Console.WriteLine("打印完毕 :-)");
		}
	}

	/// <summary>
	/// 真实调用主题
	/// </summary>
	public class AbroadShop {
		public bool checkAbroad(Person p) {
			return p.isAbroad==true;
		}
	}

	class ProxyTest:IMain {
		public void AppMain() {
			AbroadShop ashop = new AbroadShop();

			RealBuyPerson me = new RealBuyPerson("小王");
			me.BuyProduct(ashop); 
			Console.WriteLine();

			AbroadProxy friend = new AbroadProxy("代理小陈");
			me.CallProxyBuySomethings(friend,"奶粉");
			friend.GoAbroad();
			friend.PrintOrders();
			friend.BuyProduct(ashop);
		}
	}
}
