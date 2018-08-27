namespace StorageMaster.App.Core.Interfaces
{
    public interface ICommand
    {
        string Execute(string[] input);
    }
}
