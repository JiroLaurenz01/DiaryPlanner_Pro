﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryPlanner_Pro
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        #region FUNCTIONS FOR PASSWORD AND CONFIRM PASSWORD BOX VISIBILITY TOGGLE

        private void passwordBox_IconRightClick(object sender, EventArgs e)
        {
            // This event handler is called when the right icon of the 'passwordBox' control is clicked.

            // If the 'UseSystemPasswordChar' property is true, it means that the password is currently hidden.
            if (passwordBox.UseSystemPasswordChar)
            {
                // Change the right icon to an "open eye" icon.
                passwordBox.IconRight = Properties.Resources.eye__1_;

                // Set the 'PasswordChar' property to '\0' to reveal the actual characters in the password.
                // Set 'UseSystemPasswordChar' to false to indicate that the password is no longer hidden.
                passwordBox.PasswordChar = '\0';
                passwordBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Change the right icon to a "closed eye" icon.
                passwordBox.IconRight = Properties.Resources.eye;

                // Set the 'PasswordChar' property to '●' to hide the actual characters in the password.
                // Set 'UseSystemPasswordChar' to true to indicate that the password should be hidden.
                passwordBox.PasswordChar = '●';
                passwordBox.UseSystemPasswordChar = true;
            }
        }

        private void conPasswordBox_IconRightClick(object sender, EventArgs e)
        {
            // This event handler is called when the right icon of the 'conPasswordBox' control is clicked.

            // If the 'UseSystemPasswordChar' property is true, it means that the password is currently hidden.
            if (conPasswordBox.UseSystemPasswordChar)
            {
                // Change the right icon to an "open eye" icon.
                conPasswordBox.IconRight = Properties.Resources.eye__1_;

                // Set the 'PasswordChar' property to '\0' to reveal the actual characters in the password.
                // Set 'UseSystemPasswordChar' to false to indicate that the password is no longer hidden.
                conPasswordBox.PasswordChar = '\0';
                conPasswordBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Change the right icon to a "closed eye" icon.
                conPasswordBox.IconRight = Properties.Resources.eye;

                // Set the 'PasswordChar' property to '●' to hide the actual characters in the password.
                // Set 'UseSystemPasswordChar' to true to indicate that the password should be hidden.
                conPasswordBox.PasswordChar = '●';
                conPasswordBox.UseSystemPasswordChar = true;
            }
        }

        #endregion

        #region FUNCTIONS FOR STRONG PASSWORD INDICATOR

        private async void passwordBox_TextChanged(object sender, EventArgs e)
        {
            // Retrieve the entered password.
            string password = passwordBox.Text;

            // Check if the password length is less than or equal to 6 characters.
            if (password.Length <= 6)
            {
                // If it is, display a message indicating that a minimum of 6 characters is required.
                strengthLabel.Text = "Minimum 6 characters";
                strengthLabel.ForeColor = Color.Gray;
                return;
            }

            // Use Task.Run to perform the strength evaluation asynchronously.
            int strength = await Task.Run(() => CalculatePasswordStrength(password));

            // Update the UI to reflect the password strength.
            UpdateStrengthLabel(strength);
        }

        private int CalculatePasswordStrength(string password)
        {
            int length = password.Length;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;
                else if (char.IsLower(c))
                    hasLowerCase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                    hasSpecialChar = true;
            }

            int strength = 0;

            // Calculate the password strength based on criteria.
            // Criteria: Length, Uppercase, Lowercase, Digit, Special Character
            if (length >= 8)
                strength++;
            if (hasUpperCase)
                strength++;
            if (hasLowerCase)
                strength++;
            if (hasDigit)
                strength++;
            if (hasSpecialChar)
                strength++;

            return strength;
        }

        private void UpdateStrengthLabel(int strength)
        {
            // Update the UI to reflect the password strength.
            if (strength <= 2)
            {
                // If the strength is low, display a weak password message in red.
                strengthLabel.Text = "Password is weak";
                strengthLabel.ForeColor = Color.DarkRed;
            }
            else if (strength <= 4)
            {
                // If the strength is moderate, display a moderate password message in blue.
                strengthLabel.Text = "Password is moderate";
                strengthLabel.ForeColor = Color.RoyalBlue;
            }
            else
            {
                // If the strength is strong, display a strong password message in green.
                strengthLabel.Text = "Password is strong";
                strengthLabel.ForeColor = Color.Green;
            }
        }

        #endregion
    }
}
