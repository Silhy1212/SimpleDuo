using System.ComponentModel;

namespace DatabaseViewForm;

partial class LoginView
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        LoginTextBox = new System.Windows.Forms.TextBox();
        LoginButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // LoginTextBox
        // 
        LoginTextBox.Location = new System.Drawing.Point(267, 56);
        LoginTextBox.Name = "LoginTextBox";
        LoginTextBox.Size = new System.Drawing.Size(170, 23);
        LoginTextBox.TabIndex = 2;
        LoginTextBox.Enter += LoginTextBox_Enter;
        LoginTextBox.Leave += LoginTextBox_Leave;
        // 
        // LoginButton
        // 
        LoginButton.Location = new System.Drawing.Point(345, 85);
        LoginButton.Name = "LoginButton";
        LoginButton.Size = new System.Drawing.Size(92, 26);
        LoginButton.TabIndex = 3;
        LoginButton.Text = "Login";
        LoginButton.UseVisualStyleBackColor = true;
        LoginButton.Click += LoginButton_Click;
        // 
        // LoginView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(LoginButton);
        Controls.Add(LoginTextBox);
        Size = new System.Drawing.Size(800, 450);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox LoginTextBox;
    private System.Windows.Forms.Button LoginButton;

    #endregion
}