using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace ChinookMediaManager.ViewModels.BaseClasses
{
	public class AsyncCommandWithResult<TParameter, TResult> : IAsyncCommandWithResult<TParameter, TResult>
	{
		private readonly Func<TParameter, bool> _canAction;
		private readonly Func<TParameter, TResult> _action;

		public AsyncCommandWithResult(Func<TParameter, TResult> action)
		{
			_action = action;
		}

		public AsyncCommandWithResult(Func<TParameter, TResult> action, Func<TParameter, bool> canAction)
		{
			_action = action;
			_canAction = canAction;
		}


		public Action<TParameter, TResult> Completed { get; set; }
		public Action<TParameter> Preview { get; set; }
		public bool BlockInteraction { get; set; }

		public void Execute(object parameter)
		{
			//Execute Preview
			Preview((TParameter)parameter);

			//This is the async actions to take... 
			worker.DoWork += (sender, args) =>
				{
					args.Result = _action((TParameter)parameter);
					
				};

			//When the work is complete, execute the postaction.
			worker.RunWorkerCompleted += (sender, args) =>{
			                                              	Completed((TParameter) parameter, (TResult) args.Result);
			                                              	CommandManager.InvalidateRequerySuggested();
			};

			//Run the async work.
			worker.RunWorkerAsync();
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			if(BlockInteraction  && worker.IsBusy )
				return false;

			return _canAction == null ? true : _canAction((TParameter)parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public TResult ExecuteSync(TParameter obj)
		{
			return _action(obj);
		}

		private readonly BackgroundWorker worker = new BackgroundWorker();
	}
}