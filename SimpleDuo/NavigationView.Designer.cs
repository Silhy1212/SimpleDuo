using System.ComponentModel;

namespace DatabaseViewForm;

partial class NavigationView
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
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(176, 151);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(124, 42);
        button1.TabIndex = 0;
        button1.Text = "User";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click_1;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(334, 151);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(124, 42);
        button2.TabIndex = 1;
        button2.Text = "Language";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new System.Drawing.Point(487, 151);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(124, 42);
        button3.TabIndex = 2;
        button3.Text = "Registrations";
        button3.UseVisualStyleBackColor = true;
        // 
        // NavigationView
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Size = new System.Drawing.Size(800, 450);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button1;

    #endregion
}