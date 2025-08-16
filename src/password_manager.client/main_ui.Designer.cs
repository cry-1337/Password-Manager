namespace password_manager
{
    partial class main_ui
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_ui));
            button1 = new Button();
            button2 = new Button();
            username = new TextBox();
            password = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Bottom;
            button1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(0, 356);
            button1.Name = "button1";
            button1.Size = new Size(596, 36);
            button1.TabIndex = 0;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += register_button_clicked;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Dock = DockStyle.Bottom;
            button2.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(0, 320);
            button2.Name = "button2";
            button2.Size = new Size(596, 36);
            button2.TabIndex = 1;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += login_button_clicked;
            // 
            // textBox1
            // 
            username.Dock = DockStyle.Top;
            username.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            username.Location = new Point(0, 0);
            username.Name = "textBox1";
            username.PlaceholderText = "Enter your Username";
            username.Size = new Size(596, 21);
            username.TabIndex = 2;
            username.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            password.Dock = DockStyle.Top;
            password.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            password.Location = new Point(0, 21);
            password.Name = "textBox2";
            password.PlaceholderText = "Enter your Password";
            password.Size = new Size(596, 21);
            password.TabIndex = 3;
            password.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 42);
            label1.Name = "label1";
            label1.Size = new Size(596, 278);
            label1.TabIndex = 4;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Visible = false;
            // 
            // main_ui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 392);
            Controls.Add(label1);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "main_ui";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox username;
        private TextBox password;
        private Label label1;
    }
}
