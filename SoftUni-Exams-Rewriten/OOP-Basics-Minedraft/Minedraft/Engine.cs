using System;
using System.Linq;

public class Engine : IEngine
{
    private DraftManager draftManager;
    private IWriter writer;
    private IReader reader;

    public Engine(IWriter writer, IReader reader)
    {
        this.draftManager = new DraftManager();
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string result = ReadInput();
                this.writer.WriteLine(result);
            }
            catch (HarvesterNotRegisteredException hnre)
            {
                this.writer.WriteLine(hnre.Message);
            }
            catch (ProviderNotRegisteredException pnre)
            {
                this.writer.WriteLine(pnre.Message);
            }
            catch (InvalidSystemModeException isme)
            {
                this.writer.WriteLine(isme.Message);
            }
            catch (InvalidHarvesterTypeException ihte)
            {
                this.writer.WriteLine(ihte.Message);
            }
            catch (InvalidProviderTypeException ipte)
            {
                this.writer.WriteLine(ipte.Message);
            }
        }
    }

    private string ReadInput()
    {
        string[] userInput = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string command = userInput[0];
        string output = string.Empty;

        switch (command)
        {
            case "RegisterHarvester":
                output = draftManager.RegisterHarvester(userInput.Skip(1).ToList());
                break;
            case "RegisterProvider":
                output = draftManager.RegisterProvider(userInput.Skip(1).ToList());
                break;
            case "Day":
                output = draftManager.Day();
                break;
            case "Mode":
                output = draftManager.Mode(userInput.Skip(1).ToList());
                break;
            case "Check":
                output = draftManager.Check(userInput.Skip(1).ToList());
                break;
            case "Shutdown":
                output = draftManager.ShutDown();
                this.writer.WriteLine(output);
                Environment.Exit(0);
                break;
        }

        return output;
    }
}

