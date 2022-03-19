namespace Mongo;

public interface IDocument<out TId>
{
    TId Id { get; }
}