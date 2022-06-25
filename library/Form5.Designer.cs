
namespace library
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vidachaliteraturiBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bibliotekaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bibliotekaDataSet = new library.bibliotekaDataSet();
            this.vidachaliteraturiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vidacha_literaturiTableAdapter = new library.bibliotekaDataSetTableAdapters.vidacha_literaturiTableAdapter();
            this.chitateliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chitateliTableAdapter = new library.bibliotekaDataSetTableAdapters.chitateliTableAdapter();
            this.chitateliBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidachaliteraturiBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibliotekaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibliotekaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidachaliteraturiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitateliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitateliBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(686, 268);
            this.dataGridView1.TabIndex = 22;
            // 
            // vidachaliteraturiBindingSource1
            // 
            this.vidachaliteraturiBindingSource1.DataMember = "vidacha_literaturi";
            this.vidachaliteraturiBindingSource1.DataSource = this.bibliotekaDataSetBindingSource;
            // 
            // bibliotekaDataSetBindingSource
            // 
            this.bibliotekaDataSetBindingSource.DataSource = this.bibliotekaDataSet;
            this.bibliotekaDataSetBindingSource.Position = 0;
            // 
            // bibliotekaDataSet
            // 
            this.bibliotekaDataSet.DataSetName = "bibliotekaDataSet";
            this.bibliotekaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vidachaliteraturiBindingSource
            // 
            this.vidachaliteraturiBindingSource.DataMember = "vidacha_literaturi";
            this.vidachaliteraturiBindingSource.DataSource = this.bibliotekaDataSetBindingSource;
            // 
            // vidacha_literaturiTableAdapter
            // 
            this.vidacha_literaturiTableAdapter.ClearBeforeFill = true;
            // 
            // chitateliBindingSource
            // 
            this.chitateliBindingSource.DataMember = "chitateli";
            this.chitateliBindingSource.DataSource = this.bibliotekaDataSetBindingSource;
            // 
            // chitateliTableAdapter
            // 
            this.chitateliTableAdapter.ClearBeforeFill = true;
            // 
            // chitateliBindingSource1
            // 
            this.chitateliBindingSource1.DataMember = "chitateli";
            this.chitateliBindingSource1.DataSource = this.bibliotekaDataSetBindingSource;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 292);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "Должники";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidachaliteraturiBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibliotekaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibliotekaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vidachaliteraturiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitateliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitateliBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bibliotekaDataSetBindingSource;
        private bibliotekaDataSet bibliotekaDataSet;
        private System.Windows.Forms.BindingSource vidachaliteraturiBindingSource;
        private bibliotekaDataSetTableAdapters.vidacha_literaturiTableAdapter vidacha_literaturiTableAdapter;
        private System.Windows.Forms.BindingSource chitateliBindingSource;
        private bibliotekaDataSetTableAdapters.chitateliTableAdapter chitateliTableAdapter;
        private System.Windows.Forms.BindingSource vidachaliteraturiBindingSource1;
        private System.Windows.Forms.BindingSource chitateliBindingSource1;
    }
}