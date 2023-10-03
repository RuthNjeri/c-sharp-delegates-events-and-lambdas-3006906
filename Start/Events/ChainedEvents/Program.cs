using System;

namespace ChainedEvents
{
    // define the delegate for the event handler
    public delegate void myEventHandler(string value);

    class EventPublisher
    {
        private string theVal;
        // declare the event handler
        public event myEventHandler valueChanged;
        // TODO4: Use the EventArgs class
        public event EventHandler<objChangeEventArgs> objChanged;

        public string Val
        {
            set {
                this.theVal = value;
                // when the value changes, fire the event
                this.valueChanged(theVal);
                // TODO5: Use the custom event handler
                this.objChanged(this, new objChangeEventArgs()
                {
                    propChanged = "Val"
                });
            }
        }
    }

    // TODO3: Create a subclass of EventArgs for our use
    class objChangeEventArgs : EventArgs
    {
        public string propChanged;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // create the test class
            EventPublisher obj = new EventPublisher();
            // TODO1: Connect multiple event handlers
            obj.valueChanged += new myEventHandler(changeListener2);
            obj.valueChanged += new myEventHandler(changeListener1);

            // TODO2: Use an anonymous delegate as the event handler
            obj.valueChanged += delegate (string val)
            {
                Console.WriteLine("Anonymous Handler: The value changed to {0}", val);
            };

            // TODO6: Listen for the custom event we defined with EventArgs
            obj.objChanged += delegate(object sender, objChangeEventArgs e)
            {
                Console.WriteLine("{0} had the {1} property changed", sender.GetType(), e.propChanged);
            };

            string str;
            do {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit")) {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }

        static void changeListener1(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }
        static void changeListener2(string value)
        {
            Console.WriteLine("I also listen to the event, and got {0}", value);
        }
    }
}