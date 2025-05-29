namespace BSKEYMbeadandoAI
{
    partial class Form1
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
            this.mazefield = new System.Windows.Forms.Panel();
            this.trialanderrorwithrestart = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.trialanderror = new System.Windows.Forms.Button();
            this.backtrack = new System.Windows.Forms.Button();
            this.depth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.depthfirst = new System.Windows.Forms.Button();
            this.breadthfirst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mazefield
            // 
            this.mazefield.Location = new System.Drawing.Point(12, 12);
            this.mazefield.Name = "mazefield";
            this.mazefield.Size = new System.Drawing.Size(422, 406);
            this.mazefield.TabIndex = 0;
            this.mazefield.Paint += new System.Windows.Forms.PaintEventHandler(this.mazefield_Paint);
            // 
            // trialanderrorwithrestart
            // 
            this.trialanderrorwithrestart.Location = new System.Drawing.Point(12, 477);
            this.trialanderrorwithrestart.Name = "trialanderrorwithrestart";
            this.trialanderrorwithrestart.Size = new System.Drawing.Size(144, 23);
            this.trialanderrorwithrestart.TabIndex = 1;
            this.trialanderrorwithrestart.Text = "TrialAndErrorWithRestart";
            this.trialanderrorwithrestart.UseVisualStyleBackColor = true;
            this.trialanderrorwithrestart.Click += new System.EventHandler(this.trialanderrorwithrestart_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(12, 551);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // trialanderror
            // 
            this.trialanderror.Location = new System.Drawing.Point(12, 448);
            this.trialanderror.Name = "trialanderror";
            this.trialanderror.Size = new System.Drawing.Size(113, 23);
            this.trialanderror.TabIndex = 3;
            this.trialanderror.Text = "TrialAndError";
            this.trialanderror.UseVisualStyleBackColor = true;
            this.trialanderror.Click += new System.EventHandler(this.trialanderror_Click);
            // 
            // backtrack
            // 
            this.backtrack.Location = new System.Drawing.Point(180, 477);
            this.backtrack.Name = "backtrack";
            this.backtrack.Size = new System.Drawing.Size(75, 23);
            this.backtrack.TabIndex = 4;
            this.backtrack.Text = "BackTrack";
            this.backtrack.UseVisualStyleBackColor = true;
            this.backtrack.Click += new System.EventHandler(this.backtrack_Click);
            // 
            // depth
            // 
            this.depth.Location = new System.Drawing.Point(167, 506);
            this.depth.Name = "depth";
            this.depth.Size = new System.Drawing.Size(100, 20);
            this.depth.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "BackTrack Depth limit:";
            // 
            // depthfirst
            // 
            this.depthfirst.Location = new System.Drawing.Point(180, 448);
            this.depthfirst.Name = "depthfirst";
            this.depthfirst.Size = new System.Drawing.Size(75, 23);
            this.depthfirst.TabIndex = 7;
            this.depthfirst.Text = "DepthFirst";
            this.depthfirst.UseVisualStyleBackColor = true;
            this.depthfirst.Click += new System.EventHandler(this.depthfirst_Click);
            // 
            // breadthfirst
            // 
            this.breadthfirst.Location = new System.Drawing.Point(278, 477);
            this.breadthfirst.Name = "breadthfirst";
            this.breadthfirst.Size = new System.Drawing.Size(75, 23);
            this.breadthfirst.TabIndex = 8;
            this.breadthfirst.Text = "BreadthFirst";
            this.breadthfirst.UseVisualStyleBackColor = true;
            this.breadthfirst.Click += new System.EventHandler(this.breadthfirst_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 586);
            this.Controls.Add(this.breadthfirst);
            this.Controls.Add(this.depthfirst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.depth);
            this.Controls.Add(this.backtrack);
            this.Controls.Add(this.trialanderror);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.trialanderrorwithrestart);
            this.Controls.Add(this.mazefield);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mazefield;
        private System.Windows.Forms.Button trialanderrorwithrestart;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button trialanderror;
        private System.Windows.Forms.Button backtrack;
        private System.Windows.Forms.TextBox depth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button depthfirst;
        private System.Windows.Forms.Button breadthfirst;
    }
}

