﻿using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//装饰者模式:以对客户透明的方式动态地给一个对象附加上更多的责任，装饰者模式相比生成子类可以更灵活地增加功能。
namespace DesignPatterns.Patterns._07_Decorator {
	/// <summary>
	/// 手机抽象类，即装饰者模式中的抽象组件类
	/// </summary>
	public abstract class Phone {
		public abstract void Print();
	}

	/// <summary>
	/// 苹果手机，即装饰着模式中的具体组件类
	/// </summary>
	public class ApplePhone : Phone {
		public override void Print() {
			Console.WriteLine("开始执行具体的对象——苹果手机");
		}
	}

	/// <summary>
	/// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自Photo
	/// </summary>
	public abstract class Decorator : Phone {
		private Phone phone;
		public Decorator(Phone p) { this.phone = p; }

		public override void Print() {
			if (phone != null) phone.Print();
		}
	}

	/// <summary>
	/// 贴膜，即具体装饰者
	/// </summary>
	public class Sticker : Decorator {
		public Sticker(Phone p) : base(p) { }
		public override void Print() {
			base.Print();

			// 添加新的行为
			AddSticker();      
		}

		private void AddSticker() {
			Console.WriteLine("现在手机有贴膜了");
		}
	}

	/// <summary>
	/// 手机挂件
	/// </summary>
	public class Accessories : Decorator {
		public Accessories(Phone p)
			: base(p) {
		}

		public override void Print() {
			base.Print();

			// 添加新的行为
			AddAccessories();
		}

		public void AddAccessories() {
			Console.WriteLine("现在手机有漂亮的挂件了");
		}
	}


	class DecoratorTest:IMain {
		public void AppMain() {
			//我买了个苹果手机
			Phone phone = new ApplePhone();

			//想贴膜
			Decorator applePhoneWithSticker = new Sticker(phone);
			// 扩展贴膜行为
			applePhoneWithSticker.Print();
			Console.WriteLine("----------------------\n");

			// 现在我想有挂件了
			Decorator applePhoneWithAccessories = new Accessories(phone);
			// 扩展手机挂件行为
			applePhoneWithAccessories.Print();
			Console.WriteLine("----------------------\n");

			// 现在我同时有贴膜和手机挂件了
			Sticker sticker = new Sticker(phone);
			Accessories applePhoneWithAccessoriesAndSticker = new Accessories(sticker);
			applePhoneWithAccessoriesAndSticker.Print();
		}
	}
}
