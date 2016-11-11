using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//在软件系统中，有时需要创建一个复杂对象，并且这个复杂对象由其
//各部分子对象通过一定的步骤组合而成。
//例如一个采购系统中，如果需要采购员去采购一批电脑时，在这个实
//际需求中，电脑就是一个复杂的对象，它是由CPU、主板、硬盘、显
//卡、机箱等组装而成的，如果此时让采购员一台一台电脑去组装的话
//真是要累死采购员了，这里就可以采用建造者模式来解决这个问题.
//我们可以把电脑的各个组件的组装过程封装到一个建造者类对象里，
//建造者只要负责返还给客户端全部组件都建造完毕的产品对象就可以
//了。然而现实生活中也是如此的，如果公司要采购一批电脑，此时采
//购员不可能自己去买各个组件并把它们组织起来，此时采购员只需要
//像电脑城的老板说自己要采购什么样的电脑就可以了，电脑城老板自
//然会把组装好的电脑送到公司。下面就以这个例子来展开建造者模式的介绍。

/// <summary>
/// 以组装电脑为例子
/// 每台电脑的组成过程都是一致的，但是使用同样的构建过程可以创建不同的表示(即可以组装成不一样的电脑，配置不一样)
/// 组装电脑的这个场景就可以应用建造者模式来设计
/// </summary>
namespace DesignPatterns.Patterns._03_Builder {
	/// <summary>
	/// 小王师傅和小李师傅难道会自愿地去组装嘛，谁不想休息的，这必须有一个人叫他们去组装才会去的
	/// 这个人当然就是老板了，也就是建造者模式中的指挥者
	/// 指挥创建过程类
	/// </summary>
	class Director {
		public void Construct(IBuildComputer builder) {
			Console.WriteLine(builder.Name);
			builder.BuildPartCPU();
			builder.BuildPartMainBoard();
		}
	}

	/// <summary>
	/// 建造者接口
	/// </summary>
	interface IBuildComputer {
		string Name { get; set; }

		void BuildPartCPU();
		void BuildPartMainBoard();
		Computer GetComputer();
	}

	/// <summary>
	/// 具体创建者，具体的某个人为具体创建者，例如：装机小王啊
	/// </summary>
	class BuilderXW : IBuildComputer {
		public string Name { get; set; }
		public BuilderXW() { Name = "小王师傅"; }

		Computer computer = new Computer();
		public void BuildPartCPU() {
			computer.Add("CPU1");
		}

		public void BuildPartMainBoard() {
			computer.Add("Main board1");
		}

		public Computer GetComputer() {
			return computer;
		}
	}

	/// <summary>
	/// 具体创建者，具体的某个人为具体创建者，例如：装机小李啊
	/// </summary>
	class BuilderXL : IBuildComputer {
		public string Name { get; set; }

		public BuilderXL() { Name = "小李师傅"; }
		Computer computer = new Computer();
		public void BuildPartCPU() {
			computer.Add("CPU2");
		}

		public void BuildPartMainBoard() {
			computer.Add("Main board2");
		}

		public Computer GetComputer() {
			return computer;
		}
	}

	/// <summary>
	/// 电脑类
	/// </summary>
	public class Computer {
		// 电脑组件集合
		private IList<string> parts = new List<string>();

		// 把单个组件添加到电脑组件集合中
		public void Add(string part) {
			parts.Add(part);
		}

		public void Show() {
			Console.WriteLine("电脑开始在组装.......");
			foreach (string part in parts) {
				Console.WriteLine("组件" + part + "已装好");
			}

			Console.WriteLine("电脑组装好了");
		}
	}

	/// <summary>
	/// 客户
	/// </summary>
	class BuilderTest : IMain {
		public void AppMain() {
			// 客户找到电脑城老板说要买电脑，这里要装两台电脑
			// 创建指挥者和构造者
			Director director = new Director();
			IBuildComputer b1 = new BuilderXW();
			IBuildComputer b2 = new BuilderXL();

			// 老板叫员工去组装第一台电脑
			director.Construct(b1);

			// 组装完，组装人员搬来组装好的电脑
			Computer computer1 = b1.GetComputer();
			computer1.Show();

			// 老板叫员工去组装第二台电脑
			director.Construct(b2);
			Computer computer2 = b2.GetComputer();
			computer2.Show();

		}
	}
}