using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._13_Command {
	interface IAdvCommand {
		void Execute();
		void UnExecute();
	}

	class CalculatorCommand : IAdvCommand {
		private Calculator calculator;
		private float operand;
		char @operator;

		public CalculatorCommand(Calculator calculator,char @operator, float operand) {
			this.calculator = calculator;
			this.@operator = @operator;
			this.operand = operand;
		}

		public void SetCalculator(Calculator calculator){this.calculator = calculator;}
		public void SetOperator(char @operator){this.@operator=@operator;}
		public void SetOperand(float operand){this.operand=operand;}

		public void Execute() {
			calculator.Operation(@operator, operand);
		}

		public void UnExecute() {
			calculator.Operation(Undo(@operator), operand);
		}

		private char Undo(char @operator) {
			char undo = ' ';
			switch (@operator) {
				case '+': undo = '-'; break;
				case '-': undo = '+'; break;
				case '*': undo = '/'; break;
				case '/': undo = '*'; break;
			}
			return undo;
		} 
	}

	class Calculator {
		private float result = 0;

		public void InputFirstOperand(float f) { this.result = 0; }
		public void CE() { this.result = 0; }
		public void Operation(char @operator, float operand) {
			var temp = result;
			switch (@operator) {
				case '+': result += operand; break;
				case '-': result -= operand; break;
				case '*': result *= operand; break;
				case '/': result /= operand; break;
			}
			Console.WriteLine("result = {0} (following {1} {2} {3})",
				result, temp, @operator, operand);
		}
	}

	class User {
		private Calculator calculator = new Calculator();
		private List<IAdvCommand> cmdList = new List<IAdvCommand>();
		private int current = 0;

		public void Compute(char @operator,float operand) {
			IAdvCommand cmd = new CalculatorCommand(this.calculator, @operator, operand);
			cmd.Execute();

			cmdList.Add(cmd);
			current++;
		}

		public void Undo(int levels) {
			Console.WriteLine("---- Undo {0} levels ", levels);
			// Perform undo operations 
			for (int i = 0; i < levels; i++)
				if (current > 0)
					cmdList[--current].UnExecute();
		}

		public void Redo(int levels) {
			Console.WriteLine("---- Redo {0} levels ", levels);
			// Perform redo operations 
			for (int i = 0; i < levels; i++)
				if (current < cmdList.Count )
					cmdList[current++].Execute();
		} 

	}

	class CommandTest2 : IMain {
		public void AppMain() {
			User user = new User();

			user.Compute('+', 100.5f);
			user.Compute('-', 50);
			user.Compute('*', 10);
			user.Compute('/', 2);

			user.Undo(4);
			user.Redo(13); 
		}
	}
}
