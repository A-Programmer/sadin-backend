namespace Website.Application.Common.Commands;
public interface ICommand<out TResult> : IRequest<TResult>
{
}
