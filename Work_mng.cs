using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MySql.Data.MySqlClient;

namespace MES_PROJECT
{
    public partial class Work_mng : Form
    {

        public Work_mng()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;Database=mes;Uid=root;Pwd=1234";
            MySqlConnection Conn = new MySqlConnection(str);
            Conn.Open(); // 데이터 베이스 오픈
            
            // 데이터 베이스 접속 상태 체크 
            if(Conn.State == ConnectionState.Open)
                MessageBox.Show("DB 접속 성공");
            else
                MessageBox.Show("DB 접속 실패");

            // 데이터 베이스에 명령어 내리기 
            string SQL = "SELECT * FROM WORK_ORDER_HEAD";
            DataTable dt = new DataTable();
            MySqlDataAdapter dat = new MySqlDataAdapter(SQL, Conn);
            dat.Fill(dt); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView1.DataSource = dt;

            #region 해더명 변경
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].HeaderText = "작업지시번호";
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[1].HeaderText = "작업지시구분";
            dataGridView1.Columns[1].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[2].HeaderText = "작업지시일자";
            dataGridView1.Columns[2].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[3].HeaderText = "작업지시담당자";
            dataGridView1.Columns[3].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[4].HeaderText = "제품코드";
            dataGridView1.Columns[4].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[5].HeaderText = "제품명";
            dataGridView1.Columns[5].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[6].HeaderText = "용량";
            dataGridView1.Columns[6].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[7].HeaderText = "수량";
            dataGridView1.Columns[7].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[8].HeaderText = "완료예정일자";
            dataGridView1.Columns[8].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[9].HeaderText = "비고";
            dataGridView1.Columns[9].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[10].HeaderText = "상태";
            dataGridView1.Columns[10].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[11].HeaderText = "작성자";
            dataGridView1.Columns[11].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[12].HeaderText = "작성일자";
            dataGridView1.Columns[12].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[13].HeaderText = "수정자";
            dataGridView1.Columns[13].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView1.Columns[14].HeaderText = "수정일자";
            dataGridView1.Columns[14].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            #endregion

            Conn.Close(); 

        }

        // 셀 클릭시 
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택한 행의 첫번째 값을 가져온다. 여기선 ORDER_NO의 값
            string wkOrderNum = dataGridView1.CurrentRow.Cells[0].Value.ToString(); //발주번호

            string str = "Server=localhost;Database=mes;Uid=root;Pwd=1234";
            MySqlConnection Conn = new MySqlConnection(str);
            Conn.Open(); // 데이터 베이스 오픈


            string SQL = "SELECT * FROM work_order_body where work_order_no ='" + wkOrderNum +"'";
            DataTable dt = new DataTable();
            MySqlDataAdapter dat = new MySqlDataAdapter(SQL, Conn);
            dat.Fill(dt); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView2.DataSource = dt;

            #region 해더명 변경2
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[0].HeaderText = "데이터아이디";
            dataGridView2.Columns[0].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[1].HeaderText = "작업지시번호";
            dataGridView2.Columns[1].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[2].HeaderText = "자재코드";
            dataGridView2.Columns[2].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[3].HeaderText = "자재명";
            dataGridView2.Columns[3].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[4].HeaderText = "단위";
            dataGridView2.Columns[4].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[5].HeaderText = "기준수량";
            dataGridView2.Columns[5].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[6].HeaderText = "소요수량";
            dataGridView2.Columns[6].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[7].HeaderText = "상태";
            dataGridView2.Columns[7].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[8].HeaderText = "작성자";
            dataGridView2.Columns[8].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[9].HeaderText = "작성일자";
            dataGridView2.Columns[9].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[10].HeaderText = "수정자";
            dataGridView2.Columns[10].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            dataGridView2.Columns[11].HeaderText = "수정일자";
            dataGridView2.Columns[11].HeaderCell.Style.Font = new Font("tohoma", 13, FontStyle.Bold);
            #endregion


            Conn.Close();

        }


        // 그리드뷰 갱신
        public void GridView_Reset()
        {
            //dataGridView1.Rows.Clear(); // 일단 지금 표에 있는건 다지워

            string str = "Server=localhost;Database=mes;Uid=root;Pwd=1234";
            MySqlConnection Conn = new MySqlConnection(str);
            Conn.Open(); // 데이터 베이스 오픈

            string SQL = "SELECT * FROM work_order_head";
            DataTable dt = new DataTable();
            MySqlDataAdapter dat = new MySqlDataAdapter(SQL, Conn);
            dat.Fill(dt); // dat가 sql 명령문을 실행해서 그 결과를 dt에 가득 채운다.

            dataGridView1.DataSource = dt;

            Conn.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        //상단 새로고침 버튼
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GridView_Reset();
        }


        // 그리드뷰 행번호 출력
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), 
                                       e.InheritedRowStyle.Font, 
                                       brush, 
                                       e.RowBounds.Location.X + 30, 
                                       e.RowBounds.Location.Y + 4, sf);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                                       e.InheritedRowStyle.Font,
                                       brush,
                                       e.RowBounds.Location.X + 30,
                                       e.RowBounds.Location.Y + 4, sf);
            }
        }

        
        // 신규버튼 클릭
        private void button2_Click(object sender, EventArgs e)
        {
            Work_CMD wc = new Work_CMD(this);
            wc.Show();
        }
    }
}
