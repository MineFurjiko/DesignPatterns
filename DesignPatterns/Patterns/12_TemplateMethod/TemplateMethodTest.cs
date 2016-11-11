using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//模板方法模式:在一个抽象类中定义一个操作中的算法骨架（对应于生活中的大家下载的模板）
//而将一些步骤延迟到子类中去实现（对应于我们根据自己的情况向模板填充内容）。
//模板方法使得子类可以不改变一个算法的结构前提下，重新定义算法的某些特定步骤
//模板方法模式把不变行为搬到超类中，从而去除了子类中的重复代码。

namespace DesignPatterns.Patterns._12_TemplateMethod {

	public abstract class Vegetabel {
		// 模板方法，不要把模版方法定义为Virtual或abstract方法，避免被子类重写，防止更改流程的执行顺序
		public void CookVegetabel() {
			Console.WriteLine("炒蔬菜的一般做法");
			this.pourOil();
			this.HeatOil();
			this.pourVegetable();
			this.stir_fry();
		}

		// 第一步倒油
		public void pourOil() {
			Console.WriteLine("倒油");
		}

		// 把油烧热
		public void HeatOil() {
			Console.WriteLine("把油烧热");
		}

		// 油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
		public abstract void pourVegetable();

		// 翻炒蔬菜
		public void stir_fry() {
			Console.WriteLine("翻炒");
		}
	}

	// 菠菜
	public class Spinach : Vegetabel {

		public override void pourVegetable() {
			Console.WriteLine("倒菠菜进锅中");
		}
	}

	// 大白菜
	public class ChineseCabbage : Vegetabel {
		public override void pourVegetable() {
			Console.WriteLine("倒大白菜进锅中");
		}
	}

	class TemplateMethodTest:IMain {
		public void AppMain() {
			// 创建一个菠菜实例并调用模板方法
			Spinach spinach = new Spinach();
			spinach.CookVegetabel();
		}
	}
}
