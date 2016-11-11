using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//责任链模式:某个请求需要多个对象进行处理，从而避免请求的发送者和接收之间的耦合关系。
//将这些对象连成一条链子，并沿着这条链子传递该请求，直到有对象处理它为止。
namespace DesignPatterns.Patterns._19_ChainOfResponsibility {

	/// <summary>
	/// 采购请求
	/// </summary>
	public class PurchaseRequest {
		public double Amount { get; set; }
		public string ProductName { get; set; }
		public PurchaseRequest(double amount, string productName) {
			Amount = amount;
			ProductName = productName;
		}
	}

	/// <summary>
	/// 抽象审批人 Handler
	/// </summary>
	public abstract class Approver {
		public Approver NextApprover { get; set; }
		public string Name { get; set; }
		public Approver(string name) {
			this.Name = name;
		}
		public abstract void ProcessRequest(PurchaseRequest request);
	}

	/// <summary>
	/// ConcreteHandler 经理
	/// </summary>
	public class Manager : Approver {
		public Manager(string name) : base(name) { }
		public override void ProcessRequest(PurchaseRequest request) {
			if (request.Amount < 10000.0) {
				Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
			}
			else if (NextApprover != null) {
				NextApprover.ProcessRequest(request);
			}
		}
	}
	/// <summary>
	/// ConcreteHandler 副总
	/// </summary>
	public class VicePresident : Approver {
		public VicePresident(string name)
			: base(name) {
		}
		public override void ProcessRequest(PurchaseRequest request) {
			if (request.Amount < 25000.0) {
				Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
			}
			else if (NextApprover != null) {
				NextApprover.ProcessRequest(request);
			}
		}
	}


	/// <summary>
	/// ConcreteHandler 总经理
	/// </summary>
	public class President : Approver {
		public President(string name)
			: base(name) { }
		public override void ProcessRequest(PurchaseRequest request) {
			if (request.Amount < 100000.0) {
				Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
			}
			else {
				Console.WriteLine("Request需要组织一个会议讨论");
			}
		}
	}

	class ChainOfResponsibilityTest : IMain {
		public void AppMain() {
			PurchaseRequest requestTelphone = new PurchaseRequest(4000.0, "Telphone");
			PurchaseRequest requestSoftware = new PurchaseRequest(10000.0, "Visual Studio");
			PurchaseRequest requestComputers = new PurchaseRequest(40000.0, "Computers");

			Approver manager = new Manager("LearningHard");
			Approver Vp = new VicePresident("Tony");
			Approver Pre = new President("BossTom");

			// 设置责任链
			manager.NextApprover = Vp;
			Vp.NextApprover = Pre;

			// 处理请求
			manager.ProcessRequest(requestTelphone);
			manager.ProcessRequest(requestSoftware);
			manager.ProcessRequest(requestComputers);
		}
	}
}
