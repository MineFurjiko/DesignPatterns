using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._18_Stragety {

	#region 封装 UseWeapon() 行为
	/// <summary>
	/// 使用武器接口
	/// </summary>
	public interface IWeaponable {
		void UseWeapon();
	}

	/// <summary>
	/// 使用 剑 的类
	/// </summary>
	public class UseSword : IWeaponable {
		public void UseWeapon() {
			Console.WriteLine("我正在使用 剑 进行攻击.");
		}
	}

	/// <summary>
	///  使用 斧 的类
	/// </summary>
	public class UseAxe : IWeaponable {
		public void UseWeapon() {
			Console.WriteLine("我正在使用 斧 进行攻击.");
		}
	}

	/// <summary>
	/// 不能使用武器的类
	/// </summary>
	public class UseNothing : IWeaponable {
		public void UseWeapon() {
			Console.WriteLine("我没有使用 任何武器 进行攻击.");
		}
	}
	#endregion

	/// <summary>
	/// 角色基类
	/// </summary>
	public abstract class Character {
		protected IWeaponable WeaponBehavior;      // 通过此接口调用实际的 UseWeapon方法。

		// 使用武器，通过接口来调用方法
		public void UseWeapon() {
			WeaponBehavior.UseWeapon();
		}
		// 动态地给角色更换武器
		public void ChangeWeapon(IWeaponable newWeapon) {
			Console.WriteLine("我将更换武器...");
			WeaponBehavior = newWeapon;
		}

		public void Walk() {
			Console.WriteLine("I'm start to walk ...");
		}

		public void Stop() {
			Console.WriteLine("I'm stopped.");
		}

		public abstract void DisplayInfo(); // 显示角色信息
	}

	/// <summary>
	/// 定义野蛮人
	/// </summary>
	public class Barbarian : Character {

		public Barbarian() {
			// 初始化继承自基类的WeaponBehavior变量
			WeaponBehavior = new UseAxe();  // 野蛮人用斧
		}

		public override void DisplayInfo() {
			Console.WriteLine("Display: I'm a Barbarian from northeast.");
		}
	}

	/// <summary>
	/// 定义圣骑士
	/// </summary>
	public class Paladin : Character {

		public Paladin() {
			WeaponBehavior = new UseSword();
		}

		public override void DisplayInfo() {
			Console.WriteLine("Display: I'm a paladin ready to sacrifice.");
		}
	}


	/// <summary>
	/// 定义法师
	/// </summary>
	public class Wizard : Character {

		public Wizard() {
			WeaponBehavior = new UseNothing();
		}

		public override void DisplayInfo() {
			Console.WriteLine("Display: I'm a Wizard using powerful magic.");
		}
	}

	class StragetyTest:IMain {
		public void AppMain() {
			Character barbarian = new Barbarian(); // 默认情况下野蛮人用斧
			barbarian.DisplayInfo();
			barbarian.Walk();
			barbarian.Stop();
			barbarian.UseWeapon();
			Console.WriteLine();

			barbarian.ChangeWeapon(new UseSword());   // 现在也可以使用剑
			barbarian.UseWeapon();

			barbarian.ChangeWeapon(new UseNothing());// 也可以让他什么都用不了，当然一不会这样:)
			barbarian.UseWeapon();          
		}
	}
}
