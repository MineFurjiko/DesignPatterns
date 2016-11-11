using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//访问者模式的实现是把作用于某种数据结构上的操作封装到访问者中，使得操作和数据结构隔离。
namespace DesignPatterns.Patterns._20_Vistor {

	/// <summary>
	/// 抽象元素角色
	/// </summary>
	public abstract class Element {
		public abstract void Accept(IVistor vistor);
		public abstract void Print();
	}

	/// <summary>
	/// 具体元素A
	/// </summary>
	public class ElementA : Element {
		public override void Accept(IVistor vistor) {
			// 调用访问者visit方法
			vistor.Visit(this);
		}

		public override void Print() {
			Console.WriteLine("我是元素A");
		}
	}

	/// <summary>
	/// 具体元素B
	/// </summary>
    public class ElementB :Element
    {
        public override void Accept(IVistor vistor)
        {
            vistor.Visit(this);
        }
        public override void Print()
        {
            Console.WriteLine("我是元素B");
        }

    }

	/// <summary>
	/// 访问者接口
	/// </summary>
	public interface IVistor 
	{
		void Visit(Element element);
	}

	public class PrintMethodVistor : IVistor {
		public void Visit(Element element) {
			element.Print();
		}
	}

	/// <summary>
	/// 方便拓展方法
	/// </summary>
	public class AdvPrintMethodVistor : IVistor {
		public void Visit(Element element) {
			element.Print();
			Console.WriteLine("Call time:{0}",DateTime.Now);
		}
	}


	class VistorTest:IMain {
		public void AppMain() {
			const int COUNT = 6;
			Element[] elements = new Element[COUNT];
			for (int i = 0; i < COUNT; i++) {
				if (i % 2 == 0)
					elements[i] = new ElementA();
				else
					elements[i] = new ElementB();
			}

			PrintMethodVistor pmv = new PrintMethodVistor();
			AdvPrintMethodVistor adv_pmv = new AdvPrintMethodVistor();

			foreach (var item in elements) {
				item.Accept(pmv);
			}
			Console.WriteLine();
			foreach (var item in elements) {
				item.Accept(adv_pmv);
			}
		}
	}
}
