using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//观察者模式:定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象
//这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己的行为。
namespace DesignPatterns.Patterns._15_Observer {
	/// <summary>
	/// 主题接口
	/// </summary>
	interface IObservable {
		void Register(IObserver obj); // 注册IObserver
		void Unregister(IObserver obj);// 取消IObserver的注册
	}

	/// <summary>
	/// 订阅者接口
	/// </summary>
	interface IObserver {
		//使用推模式
		void Update(IMessage msg);      // 事件触发时由Subject调用，更新自身状态
	}

	/// <summary>
	/// 具体订阅者
	/// </summary>
	class WeiXinUser : IObserver {
		public string Name { get; private set; }
		public WeiXinUser(string name) {
			this.Name = name;
			Console.WriteLine("新用户 {0} 加入了微信！",Name);
		}

		public void Update(IMessage msg) {
			Console.WriteLine("公众号 {0} 给 {1} 发来了新的信息。",msg.Name,this.Name);
		}
	}


	/// <summary>
	/// 主题抽象类
	/// </summary>
	abstract class  SubjectBase : IObservable {
		private List<IObserver> container = new List<IObserver>();

		public void Register(IObserver obj) {
			container.Add(obj);
		}

		public void Unregister(IObserver obj) {
			container.Remove(obj);
		}

		/// <summary>
		/// 通知所有注册了的Observer
		/// </summary>
		public virtual void Notify(IMessage msg) {
			foreach (IObserver item in container) {
				item.Update(msg); // 调用Observer的Update()方法
			}
		}
	}

	/// <summary>
	/// 具体主题
	/// </summary>
	class WeiXinOA : SubjectBase {
		public string Name;
		public WeiXinOA(string name) { SetName(name);
		Console.WriteLine("创建 \"{0}\" 公众号!",Name);
		}
		public void SetName(string name, bool notify=true) { 
			this.Name = name;
			if (notify)
				UpdateInfomation();
		}

		public void UpdateInfomation() {
			IMessage msg = new WeiXinMessage(this);
			Notify(msg);
		}
	}


	/// <summary>
	/// 信息接口
	/// </summary>
	interface IMessage {
		 string Name { get;  }
	}

	/// <summary>
	/// 具体信息
	/// </summary>
	class WeiXinMessage : IMessage {
		private WeiXinOA oa;

		public WeiXinMessage(WeiXinOA oa) {
			this.oa = oa;
		}
		public string Name {
			get {
				return oa.Name;
			}
			
		}
	}


	class ObserverTest:IMain {
		public void AppMain() {
			WeiXinOA oa = new WeiXinOA("C#之美");
			WeiXinUser user1 = new WeiXinUser("小王");
			WeiXinUser user2 = new WeiXinUser("小张");

			Console.WriteLine("建立关注...");
			oa.Register(user1);
			oa.Register(user2);
			oa.UpdateInfomation();

			Console.WriteLine("小张取消关注...");
			oa.Unregister(user2);
			oa.SetName("C#编程之美");

		}
	}
}
