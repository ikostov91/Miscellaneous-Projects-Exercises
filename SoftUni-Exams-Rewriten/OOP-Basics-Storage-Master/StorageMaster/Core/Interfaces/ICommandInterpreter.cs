namespace StorageMaster.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(string input);
    }
}
