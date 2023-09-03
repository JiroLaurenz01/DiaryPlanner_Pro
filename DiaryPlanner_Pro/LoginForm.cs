﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DiaryPlanner_Pro
{
    public partial class LoginForm : Form
    {      
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // When the login form loads, center the 'userLabel' horizontally within the 'userPanel'.
            userLabel.Location = new Point((userPanel.Width - userLabel.Width) / 2, userLabel.Location.Y);
        }

        #region FUNCTIONS TO HANDLE THE UI DESIGN OF USERNAME AND PASSWORD BOX

        private void usernameBox_Enter(object sender, EventArgs e) => userNameBorderPanel.BringToFront();
        private void usernameBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernameBox.Text))
                usernameBox.BringToFront();
        }
        private void passwordBox_Enter(object sender, EventArgs e) => passwordBorderPanel.BringToFront();
        private void passwordBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Text))
                passwordBox.BringToFront();
        }

        #endregion

        #region FUNCTIONS FOR DRAGGING FUNCTIONALITY OF FORM

        private void loginFormPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is held down (mouse is being dragged).
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the new position of the form based on the mouse movement.
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        Point lastPoint;

        private void loginFormPanel_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        #endregion
    }
}
