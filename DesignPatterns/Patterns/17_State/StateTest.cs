using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._17_State {

	/// <summary>
	/// 账户
	/// </summary>
	public class Account {
		public AccountState State { get; set; }
		public string Owner { get; set; }
		public Account(string owner) {
			this.Owner = owner;
			this.State = new SilverState(0.0, this);
		}

		public double Balance { get { return State.Balance; } } // 余额
		// 存钱
		public void Deposit(double amount) {
			State.Deposit(amount);
			Console.WriteLine("存款金额为 {0:C}——", amount);
			Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
			Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
			Console.WriteLine();
		}

		// 取钱
		public void Withdraw(double amount) {
			State.Withdraw(amount);
			Console.WriteLine("取款金额为 {0:C}——", amount);
			Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
			Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
			Console.WriteLine();
		}

		// 获得利息
		public void PayInterest() {
			State.PayInterest();
			Console.WriteLine("Interest Paid --- ");
			Console.WriteLine("账户余额为 =:{0:C}", this.Balance);
			Console.WriteLine("账户状态为: {0}", this.State.GetType().Name);
			Console.WriteLine();
		}
	}

	/// <summary>
	/// 抽象状态类
	/// </summary>
	public abstract class AccountState {
		/// <summary>
		/// 账户归属
		/// </summary>
		public Account Account { get; set; }
		/// <summary>
		/// 余额
		/// </summary>
		public double Balance { get; set; }
		/// <summary>
		/// 利率
		/// </summary>
		public double Interest { get; set; }
		public double LowerLimit { get; set; }
		public double UpperLimit { get; set; }

		/// <summary>
		/// 存款
		/// </summary>
		/// <param name="amount"></param>
		public abstract void Deposit(double amount);
		/// <summary>
		/// 取钱
		/// </summary>
		/// <param name="amount"></param>
		public abstract void Withdraw(double amount);
		/// <summary>
		/// 获得的利息
		/// </summary>
		public abstract void PayInterest();
		/// <summary>
		/// 状态检查
		/// </summary>
		protected abstract void StateChangeCheck();
	}

	/// <summary>
	/// Red State意味着Account透支了
	/// </summary>
	public class RedState : AccountState {
		public RedState(AccountState state) {
			// Initialize
			this.Balance = state.Balance;
			this.Account = state.Account;
			Interest = 0.00;
			LowerLimit = -100.00;
			UpperLimit = 0.00;
		}

		public override void Deposit(double amount) {
			Balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount) {
			Console.WriteLine("没有钱可以取了！");
		}

		public override void PayInterest() {
			// 没有利息
		}

		protected override void StateChangeCheck() {
			if (Balance > UpperLimit) {
				Account.State = new SilverState(this);
			}
		}
	}

	/// <summary>
	/// Silver State意味着没有利息得
	/// </summary>
	public class SilverState : AccountState {
		public SilverState(AccountState state) : this(state.Balance, state.Account) { }
		public SilverState(double balance, Account account) {
			this.Balance = balance;
			this.Account = account;
			this.Interest = 0.00;
			this.LowerLimit = 0.00;
			this.UpperLimit = 1000.00;
		}

		public override void Deposit(double amount) {
			Balance += amount;
			StateChangeCheck();
		}

		public override void Withdraw(double amount) {
			Balance -= amount;
			StateChangeCheck();
		}

		public override void PayInterest() {
			Balance += Interest * Balance;
			StateChangeCheck();
		}

		protected override void StateChangeCheck() {
			if (Balance < LowerLimit) {
				Account.State = new RedState(this);
			}
			else if (Balance > UpperLimit) {
				Account.State = new GoldState(this);
			}
		}
	}

	public class GoldState : AccountState {
		public GoldState(AccountState state) {
			this.Balance = state.Balance;
			this.Account = state.Account;
			this.Interest = 0.05;
			this.LowerLimit = 1000.00;
			this.UpperLimit = 1000000.00;
		}
		// 存钱
		public override void Deposit(double amount) {
			Balance += amount;
			StateChangeCheck();
		}
		// 取钱
		public override void Withdraw(double amount) {
			Balance -= amount;
			StateChangeCheck();
		}
		public override void PayInterest() {
			Balance += Interest * Balance;
			StateChangeCheck();
		}

		protected override void StateChangeCheck() {
			if (Balance < 0.0) {
				Account.State = new RedState(this);
			}
			else if (Balance < LowerLimit) {
				Account.State = new SilverState(this);
			}
		}
	}


	class StateTest : IMain {
		public void AppMain() {
			// 开一个新的账户
			Account account = new Account("Learning Hard");

			// 进行交易
			// 存钱
			account.Deposit(1000.0);
			account.Deposit(200.0);
			account.Deposit(600.0);

			// 付利息
			account.PayInterest();

			// 取钱
			account.Withdraw(2000.00);
			account.Withdraw(500.00);
		}
	}
}
