namespace SubmarineWars
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.YouWin = new System.Windows.Forms.Label();
            this.FinalScore = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.Continue = new System.Windows.Forms.Button();
            this.UsernameLabel2 = new System.Windows.Forms.Label();
            this.YouLose = new System.Windows.Forms.Label();
            this.LevelCount = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Interval = 15;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(624, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Avslutt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(0, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 1;
            // 
            // YouWin
            // 
            this.YouWin.AutoSize = true;
            this.YouWin.BackColor = System.Drawing.Color.Transparent;
            this.YouWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.YouWin.ForeColor = System.Drawing.Color.White;
            this.YouWin.Location = new System.Drawing.Point(144, 42);
            this.YouWin.Name = "YouWin";
            this.YouWin.Size = new System.Drawing.Size(288, 76);
            this.YouWin.TabIndex = 2;
            this.YouWin.Text = "You win!";
            this.YouWin.Visible = false;
            // 
            // FinalScore
            // 
            this.FinalScore.AutoSize = true;
            this.FinalScore.BackColor = System.Drawing.Color.Transparent;
            this.FinalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.FinalScore.ForeColor = System.Drawing.Color.White;
            this.FinalScore.Location = new System.Drawing.Point(144, 137);
            this.FinalScore.Name = "FinalScore";
            this.FinalScore.Size = new System.Drawing.Size(245, 76);
            this.FinalScore.TabIndex = 3;
            this.FinalScore.Text = "Score: ";
            this.FinalScore.Visible = false;
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.Black;
            this.Username.Enabled = false;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.Username.ForeColor = System.Drawing.Color.White;
            this.Username.Location = new System.Drawing.Point(509, 304);
            this.Username.MaxLength = 3;
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(166, 83);
            this.Username.TabIndex = 4;
            this.Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Username.Visible = false;
            this.Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Username_KeyDown);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(509, 285);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(104, 13);
            this.UsernameLabel.TabIndex = 5;
            this.UsernameLabel.Text = "Your name (3 letters)";
            this.UsernameLabel.Visible = false;
            // 
            // Continue
            // 
            this.Continue.BackColor = System.Drawing.Color.DarkGreen;
            this.Continue.Enabled = false;
            this.Continue.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.Continue.FlatAppearance.BorderSize = 0;
            this.Continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Continue.ForeColor = System.Drawing.Color.White;
            this.Continue.Location = new System.Drawing.Point(157, 304);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(166, 83);
            this.Continue.TabIndex = 6;
            this.Continue.Text = "Fortsett";
            this.Continue.UseVisualStyleBackColor = false;
            this.Continue.Visible = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // UsernameLabel2
            // 
            this.UsernameLabel2.AutoSize = true;
            this.UsernameLabel2.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel2.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel2.Location = new System.Drawing.Point(509, 390);
            this.UsernameLabel2.Name = "UsernameLabel2";
            this.UsernameLabel2.Size = new System.Drawing.Size(87, 13);
            this.UsernameLabel2.TabIndex = 7;
            this.UsernameLabel2.Text = "\"Enter\" to submit";
            this.UsernameLabel2.Visible = false;
            // 
            // YouLose
            // 
            this.YouLose.AutoSize = true;
            this.YouLose.BackColor = System.Drawing.Color.Transparent;
            this.YouLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.YouLose.ForeColor = System.Drawing.Color.White;
            this.YouLose.Location = new System.Drawing.Point(144, 42);
            this.YouLose.Name = "YouLose";
            this.YouLose.Size = new System.Drawing.Size(349, 76);
            this.YouLose.TabIndex = 8;
            this.YouLose.Text = "You lose...";
            this.YouLose.Visible = false;
            // 
            // LevelCount
            // 
            this.LevelCount.AutoSize = true;
            this.LevelCount.Location = new System.Drawing.Point(700, 13);
            this.LevelCount.Name = "LevelCount";
            this.LevelCount.Size = new System.Drawing.Size(39, 13);
            this.LevelCount.TabIndex = 9;
            this.LevelCount.Text = "Level: ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(624, 474);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Mute";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SubmarineWars.Properties.Resources.screen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(747, 541);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LevelCount);
            this.Controls.Add(this.YouLose);
            this.Controls.Add(this.UsernameLabel2);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.FinalScore);
            this.Controls.Add(this.YouWin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameForm";
            this.Text = "Submarine Wars";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label YouWin;
        private System.Windows.Forms.Label FinalScore;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Label UsernameLabel2;
        private System.Windows.Forms.Label YouLose;
        private System.Windows.Forms.Label LevelCount;
        private System.Windows.Forms.Button button2;
    }
}