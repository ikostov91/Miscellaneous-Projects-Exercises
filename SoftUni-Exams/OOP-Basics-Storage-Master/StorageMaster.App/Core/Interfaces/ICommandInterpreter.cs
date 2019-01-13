namespace StorageMaster.App.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(string input);
    }
}
