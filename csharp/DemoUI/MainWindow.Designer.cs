/* SPDX-License-Identifier: MIT
 *
 * Copyright (C) 2019-2022 WireGuard LLC. All Rights Reserved.
 */

namespace DemoUI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connectButton = new System.Windows.Forms.Button();
            logBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            connectButton.Location = new System.Drawing.Point(7, 8);
            connectButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            connectButton.Name = "connectButton";
            connectButton.Size = new System.Drawing.Size(700, 29);
            connectButton.TabIndex = 5;
            connectButton.Text = "&Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // logBox
            // 
            logBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            logBox.Location = new System.Drawing.Point(7, 40);
            logBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            logBox.Size = new System.Drawing.Size(701, 352);
            logBox.TabIndex = 4;
            logBox.TabStop = false;
            logBox.TextChanged += logBox_TextChanged;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(714, 398);
            Controls.Add(logBox);
            Controls.Add(connectButton);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "MainWindow";
            Text = "WireGuard Demo Client";
            FormClosing += MainWindow_FormClosing;
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox logBox;
    }
}

