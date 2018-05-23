﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace AmericanOptions.Validations
{
    public class InputsValidator : IInputsValidator
    {
        public void ValidateInput(Control control)
        {
            ValidateText(control);
            ValidateNumber(control);
        }

        private void ValidateText(Control control)
        {
            string inputText = control.Text;

            if (string.IsNullOrEmpty(inputText) || string.IsNullOrWhiteSpace(inputText))
            {
                string message = string.Format("Input \"{0}\" cannot be empty!", control.Tag);
                SetControlInExceptionMode(control);
                throw new Exception(message);
            }
            else
            {
                SetControlIndistMode(control);
            }
        }

        private void ValidateNumber(Control control)
        {
            string inputText = control.Text;

            if (!double.TryParse(inputText, out double result))
            {
                string message = string.Format("Input \"{0}\" must be a number!", control.Tag);
                SetControlInExceptionMode(control);
                throw new Exception(message);
            }
            else
            {
                SetControlIndistMode(control);
            }
        }

        private void SetControlInExceptionMode(Control control)
        {
            control.BackColor = Color.IndianRed;
            control.Select();
        }

        private void SetControlIndistMode(Control control)
        {
            control.BackColor = Color.White;
        }
    }
}
