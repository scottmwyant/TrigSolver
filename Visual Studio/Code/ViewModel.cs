using System;

namespace TrigSolver
{


    class ViewModel : IViewModel
    {
        //
        // Nested class
        //

        private class TextBoxProxy
        {
            public bool Enabled { get; set; }
            public string Text { get; set; }
            public double Value { get; set; }
            public TextBoxProxy()
            {
                Enabled = true;
                Text = "";
                Value = new double();
            }
        }

        //
        // Properties
        //

        public bool Enabled0 { get { return tbx[0].Enabled; } }
        public bool Enabled1 { get { return tbx[1].Enabled; } }
        public bool Enabled2 { get { return tbx[2].Enabled; } }
        public bool Enabled3 { get { return tbx[3].Enabled; } }
        public bool Enabled4 { get { return tbx[4].Enabled; } }
        public bool Enabled5 { get { return tbx[5].Enabled; } }

        public string Text0 { get { return tbx[0].Text; } }
        public string Text1 { get { return tbx[1].Text; } }
        public string Text2 { get { return tbx[2].Text; } }
        public string Text3 { get { return tbx[3].Text; } }
        public string Text4 { get { return tbx[4].Text; } }
        public string Text5 { get { return tbx[5].Text; } }

        public string StatusText1 { get { return statusText1; } }
        public string StatusText2 { get { return statusText2; } }
        public bool UseDegrees
        {
            set
            {
                if (useDegrees != value)
                {
                    switchUnits = true;
                    useDegrees = !useDegrees;
                }
                
                UpdateUnitConversions();
            }
        }


        //
        // Fields
        //

        private TextBoxProxy[] tbx = new TextBoxProxy[6];
        private IController controller;
        private bool useDegrees = true;
        private bool switchUnits = new bool();
        private double unitsForView = new double();
        private double unitsForModel = new double();
        private string statusText1 = "";
        private string statusText2 = "";
        private int precision = new int();
        
        //
        // Methods
        //

        public ViewModel(IController con)
        {
            controller = con;

            for (int i = 0; i <=5; i++) { tbx[i] = new TextBoxProxy(); }
        }

        public void Sync(string[] str)
        {

            if (switchUnits) { useDegrees = !useDegrees; UpdateUnitConversions(); }

            for (int j = 0; j <= 5; j++)
            {
                tbx[j].Text = str[j];
                tbx[j].Value = GetValue(j);
            }

            if (switchUnits) { useDegrees = !useDegrees; UpdateUnitConversions(); }

            controller.Test(GetArrayOfValues());

            if (controller.Error)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (!tbx[j].Enabled)
                    {
                        tbx[j].Enabled = true;
                        tbx[j].Text = "";
                    }
                }
                statusText1 = controller.ErrorText1 + ":";
                statusText2 = controller.ErrorText2;
                precision = 4;
            }
            else
            {
                string[] inputText = new string[3];
                int j = new int();

                // Detect which inputs are non-zero, update the value of the enabled property
                // in the proxy objects and capture the text property from the inputs.
                for (int i = 0; i <= 5; i++)
                {
                    tbx[i].Enabled = (tbx[i].Value > 0);
                    if (tbx[i].Enabled) { inputText[j] = tbx[i].Text; j++; }
                }

                // Update the precision based on the format of the input texts
                //precision = Math.Min(GetPrecision(inputText[0]), Math.Min(GetPrecision(inputText[1]), GetPrecision(inputText[2])));

                // Iterate to copy values out of the controller into the proxy objects
                for (int i = 0; i <= 5; i++) { tbx[i].Value = (controller.Data[i]); }

                // Update texts in the proxy objects where the enabled property is set to false
                for (int i = 0; i <= 2; i++){ if (!tbx[i].Enabled) { tbx[i].Text = GetText(i); } }
                for (int i = 3; i <= 5; i++) { if (tbx[i].Enabled == false || switchUnits == true) { tbx[i].Text = GetText(i); } }

                statusText1 = "Solved";
                statusText2 = "";
            }

            switchUnits = false;
        }


        private double[] GetArrayOfValues()
        {
            double[] arr = new double[6];
            for (int i = 0; i<=5; i++){arr[i] = tbx[i].Value; }
            return arr;
        }

        private double GetValue(int i)
        {
            if (tbx[i].Enabled)
            {
                double.TryParse(tbx[i].Text, out var ans);
                if (ans > 0)
                {
                    if (i <= 2)
                    {
                        return ans;
                    }
                    else
                    {
                        return ans * unitsForModel;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private string GetText(int j)
        {
            if (tbx[j].Value == 0)
            {
                return "";
            }
            else
            {
                double k = new double();
                if (j <= 2) { k = 1; } else { k = unitsForView; }
                return Math.Round((tbx[j].Value * k), precision).ToString("");
            }
        }

        private int GetPrecision(string str)
        {
            int ans = new int();
            if (str.Contains("."))
            {
                ans = str.Substring(str.LastIndexOf(".")).Length;
            }
            if (ans > 1) { ans = ans - 1; }
            return ans;
        }

        private string[] GetInputText()
        {
            int j = new int();
            string[] arr = new string[] { "" };

            for (int i = 0; i <= 5; i++)
            {
                if (tbx[i].Enabled)
                {
                    arr[j] = tbx[i].Text;
                    j++;
                }
            }

            return arr;
        }

        private void UpdateUnitConversions()
        {
            if (useDegrees)
            {
                unitsForView = 180 / Math.PI;
                unitsForModel = Math.PI / 180;
            }
            else
            {
                unitsForView = 1;
                unitsForModel = 1;
            }
        }


    }
}