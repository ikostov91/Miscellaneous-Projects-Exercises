namespace StorageMaster.Core.Interfaces
{
    public interface ICommand
    {
        string Execute(string[] input);
    }
}
