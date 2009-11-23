using System;
using System.Windows.Input;

namespace ChinookMediaManager.ViewModels.BaseClasses
{
	public interface IAsyncCommandWithResult<TParameter, TResult> : ICommand
	{
		Action<TParameter, TResult> Completed { get; set; }
		Action<TParameter> Preview { get; set; }
		bool BlockInteraction { get; set; }
		TResult ExecuteSync(TParameter obj);
	}
}