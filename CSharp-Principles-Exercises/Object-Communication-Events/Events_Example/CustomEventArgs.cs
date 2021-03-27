using System;

namespace Events_Example
{
    public class CustomEventArgs : EventArgs
    {
        private string someParameter;

        public string SomeParameter => this.someParameter;

        public CustomEventArgs(string parameter)
        {
            this.someParameter = parameter;
        }
    }
}
