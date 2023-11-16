using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace NormalCAConsProj
{
    public partial class NCACForm : Form
    {
        public NCACForm()
        {
            InitializeComponent();
        }
        private void txtRecidentification_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into NormalCAHeaderRecord " +
                "(Record_IDentification,File_IDentification,RTA_Internal_Reference_No,Debit_Credit_Indicator," +
                "ISIN,CA_Type,Allotment_Date,Allocation_Allotment_Description,Execution_Date," +
                "Total_Allotted_Quantity_Free_Lockin,Total_Allotted_Quantity_Lockin," +
                "Total_No_detail_records,Total_Issued_Amount,Total_Paidup_Amount,Stamp_Duty_Payable," +
                "Basis_calculation_Stamp_Duty,EBP_Name,Funds_collected_through,Filler,MasterUniqNo) " +
                "values(@rec_id,@file_idn,@Rta_irno,@Drcr_ind," +
                "@Isin,@Ca_type,@Allot_Date,@Alloc_allot_desc,@Exec_Date," +
                "@Totallqtyfli,@Totallqtyli," +
                "@Tot_detrec,@Totiss_amt,@Totpaid_amt,@Stmp_dutypay," +
                "@Bc_stmpduty,@Ebp_name,@Funds_colthr,@Filler,@MasterUniqNo)", con);

            cmd.Parameters.AddWithValue("@rec_id", txtRecidentification.Text);
            cmd.Parameters.AddWithValue("@file_idn", txtFileidentification.Text);
            cmd.Parameters.AddWithValue("@Rta_irno", textBox1.Text);
            var dr_cr = comboBox1.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@Drcr_ind", dr_cr);
            cmd.Parameters.AddWithValue("@Isin", textBox3.Text);
            var caty = comboBox6.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@Ca_type", caty);
            cmd.Parameters.AddWithValue("@Allot_Date", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            var aad = comboBox7.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@Alloc_allot_desc", aad);
            cmd.Parameters.AddWithValue("@Exec_Date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Totallqtyfli", textBox8.Text);
            cmd.Parameters.AddWithValue("@Totallqtyli", textBox9.Text);
            cmd.Parameters.AddWithValue("@Tot_detrec", textBox10.Text);
            //cmd.Parameters.AddWithValue("@opfv", txtOpfv.Text)
            cmd.Parameters.AddWithValue("@Totiss_amt", textBox11.Text);
            cmd.Parameters.AddWithValue("@Totpaid_amt", textBox12.Text);
            var stmp = comboBox2.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@Stmp_dutypay", stmp);
            var bcstamp = comboBox3.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Bc_stmpduty", bcstamp);
            var ebpnm = comboBox4.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Ebp_name", ebpnm);
            var fcthr = comboBox5.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Funds_colthr", fcthr);
            cmd.Parameters.AddWithValue("@Filler", txtFiller01.Text);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMastuniqno01.Text);
            // cmd.Parameters.AddWithValue("@normalcauploaduniqueno", txtNormalcauploaduniqueno.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in NormalCAHeaderRecord Database");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into NormalCADetailRecord (Record_IDentification,Detail_Record_Line_No," +
                "DP_ID,Client_ID,Client_Account_Category,Allotment_Quantity,Lockin_Reason_Code,Lockin_Release_Date," +
                "Issue_Price,Issued_Amount,Paidup_Price,Paidup_Amount,Filler,MasterUniqNo) " +
                 "values(@Record_IDentification,@Detail_Record_Line_No,@DP_ID,@Client_ID,@Client_Account_Category," +
                 "@Allotment_Quantity,@Lockin_Reason_Code,@Lockin_Release_Date,@Issue_Price,@Issued_Amount,@Paidup_Price," +
                 "@Paidup_Amount,@Filler,@MasterUniqNo)", con);
            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecordIdent02.Text);
            cmd.Parameters.AddWithValue("@Detail_Record_Line_No", txtDetailrecordno.Text);
            //cmd.Parameters.AddWithValue("@DP_ID", txtDpid.Text);
            //var dpid = txtDpid02.Text + textBox3.Text;
            cmd.Parameters.AddWithValue("@DP_ID", txtDpid02.Text);
            cmd.Parameters.AddWithValue("@Client_ID", txtClid02.Text);
            var claccat = comboBox8.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Client_Account_Category", claccat);
            cmd.Parameters.AddWithValue("@Allotment_Quantity", txtAllotmentquantity.Text);
            var linrc = comboBox9.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Lockin_Reason_Code", linrc);
            cmd.Parameters.AddWithValue("@Lockin_Release_Date", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Issue_Price", txtIssueprice02.Text);

            //convert(bigint, allotment_quantity) * convert(bigint, Issue_Price)
            //var totissuedAmt = Convert(double(txtAllotmentquantity)) * Convert(txtIssueprice02.Text.));
            //var totpaidupAmt = (txtAllotmentquantity * txtPaidupprice02.Text);
            //cmd.Parameters.AddWithValue("@Issued_Amount", totissuedAmt);
            cmd.Parameters.AddWithValue("@Issued_Amount", txtIssuedamt02.Text);
            
            cmd.Parameters.AddWithValue("@Paidup_Price", txtPaidupprice02.Text);
            cmd.Parameters.AddWithValue("@Paidup_Amount", txtPaidupamt02.Text);
            cmd.Parameters.AddWithValue("@Filler", txtFiller02.Text);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMastuniqno02.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in NormalCADetailRecord database");

        }


        private void btnSave03_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=VCCIPL-TECH\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into NormalCADetailDistRecord (Record_IDentification," +
                "Detail_Record_Line_No,  Debit_Credit_Isin, Debit_Credit_Indicator,  From_Distinctive_No_NSDL,    " +
                "To_Distinctive_No_NSDL,  Quantity, " +
                "Flag_status_DN_Range,   CA_Type, MasterUniqNo) " +
                "values(@Record_IDentification," +
                "@Detail_Record_Line_No, @Debit_Credit_Isin, @Debit_Credit_Indicator, @From_Distinctive_No_NSDL,  " +
                "@To_Distinctive_No_NSDL, @Quantity," +
                "@Flag_status_DN_Range,  @CA_Type, @MasterUniqNo)", con);

            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecordIdent03.Text);
            cmd.Parameters.AddWithValue("@Detail_Record_Line_No", txtDetailrecno03.Text);
            cmd.Parameters.AddWithValue("@Debit_Credit_Isin", txtDrcrisin.Text);
            var dr_cr03 = comboBox12.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@Debit_Credit_Indicator", dr_cr03);
            cmd.Parameters.AddWithValue("@From_Distinctive_No_NSDL", txtFromdistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@To_Distinctive_No_NSDL", txtTodistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            var fsdnr = comboBox11.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Flag_status_DN_Range", fsdnr);
            var caty03 = comboBox10.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@CA_Type", caty03);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMastuniqno03.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in NormalCADetailDistRecord database");
            //txtDetailrecordno.Clear();
            //txtFromdistinctivenonsdl.Clear();
            //txtTodistinctivenonsdl.Clear();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Focus();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void btnView01_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NormalCAHeaderRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnView02_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NormalCADetailRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnView03_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NormalCADetailDistRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void txtTodistinctivenonsdl_TextChanged(object sender, EventArgs e)
        {
            if (txtFromdistinctivenonsdl.Text.Length > 0 && txtTodistinctivenonsdl.Text.Length > 0)
            {
                txtQuantity.Text = Convert.ToString(Convert.ToInt32(txtTodistinctivenonsdl.Text) - Convert.ToInt32(txtFromdistinctivenonsdl.Text) + 1);
            }

        }

    }
}
