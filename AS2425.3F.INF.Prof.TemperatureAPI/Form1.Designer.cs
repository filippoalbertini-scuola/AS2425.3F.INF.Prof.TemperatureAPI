namespace AS2425._3F.INF.Prof.TemperatureAPI
{
    partial class Form1
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
            label1 = new Label();
            txtCity = new TextBox();
            txtResponse = new TextBox();
            btnGetWeather = new Button();
            lblTemperatura = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 38);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 0;
            label1.Text = "City";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(85, 37);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(344, 27);
            txtCity.TabIndex = 1;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(85, 118);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.ReadOnly = true;
            txtResponse.ScrollBars = ScrollBars.Both;
            txtResponse.Size = new Size(637, 305);
            txtResponse.TabIndex = 2;
            // 
            // btnGetWeather
            // 
            btnGetWeather.Location = new Point(444, 37);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(94, 29);
            btnGetWeather.TabIndex = 3;
            btnGetWeather.Text = "Weather";
            btnGetWeather.UseVisualStyleBackColor = true;
            btnGetWeather.Click += btnGetWeather_Click;
            // 
            // lblTemperatura
            // 
            lblTemperatura.AutoSize = true;
            lblTemperatura.ForeColor = Color.FromArgb(255, 128, 255);
            lblTemperatura.Location = new Point(85, 71);
            lblTemperatura.Name = "lblTemperatura";
            lblTemperatura.Size = new Size(12, 20);
            lblTemperatura.TabIndex = 4;
            lblTemperatura.Text = ".";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 118);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 5;
            label2.Text = "JSon";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lblTemperatura);
            Controls.Add(btnGetWeather);
            Controls.Add(txtResponse);
            Controls.Add(txtCity);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Prof;Lab. 2.11DV;07/04/25; Temperature from OpenWeather";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCity;
        private TextBox txtResponse;
        private Button btnGetWeather;
        private Label lblTemperatura;
        private Label label2;
    }
}
