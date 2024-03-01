namespace WS.Core.Exceptions;

public class WarningSentenceInUseException : Exception
{
    public WarningSentenceInUseException(List<int> productIds) : base($"Warning sentence is in use on one or more products and cannot be deleted: {productIds}")
    {
    }
}