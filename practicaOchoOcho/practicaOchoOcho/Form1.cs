using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace practicaOchoOcho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        protected MySqlConnection miconexion;


        public int x = 130;
        public int encontro = 0;

        protected void AbrirConexion()
        {
            string conexionString =
                "Server=127.0.0.1;" +
                "Database=VideoJuegos;" +
                "User ID = joel;" +
                "Password =;" +
                "Pooling = false;";
            this.miconexion = new MySqlConnection(conexionString);
            this.miconexion.Open();


        }


        protected void CerrarConexion()
        {
            this.miconexion.Close();
            this.miconexion = null;
        }


       

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //CONECTA MYSQL
            this.AbrirConexion();
            MySqlCommand micomando = new MySqlCommand("Select * FROM videojuegos", this.miconexion);
            MySqlDataReader milector = micomando.ExecuteReader();

            ArrayList videos = new ArrayList();
            videojuegos videojuego = new videojuegos();





            while (milector.Read())
            {


                videojuego.id = milector["id"].ToString();
                videojuego.nombre = milector["Nombre"].ToString();
                videojuego.año = milector["Año"].ToString();
                videos.Add(videojuego);

                //Crea Label
                Button boton = new Button();
                Label label = new Label();
                Label label2 = new Label();
                Label label3 = new Label();

                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.ForeColor = System.Drawing.Color.Honeydew;
                label.Location = new System.Drawing.Point(60, x);
                label.Name = videojuego.id;
                label.Size = new System.Drawing.Size(78, 18);
                label.TabIndex = 12;
                label.Text = videojuego.id;
                // panel1.Controls.Add(label);
                this.Controls.Add(label);


                label2.AutoSize = true;
                label2.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label2.ForeColor = System.Drawing.Color.Honeydew;
                label2.Location = new System.Drawing.Point(200, x);
                label2.Name = videojuego.nombre;
                label2.Size = new System.Drawing.Size(78, 18);
                label2.TabIndex = 12;
                label2.Text = videojuego.nombre;
                //panel1.Controls.Add(label2);
                this.Controls.Add(label2);

                label3.AutoSize = true;
                label3.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label3.ForeColor = System.Drawing.Color.Honeydew;
                label3.Location = new System.Drawing.Point(410, x);
                label3.Name = videojuego.año;
                label3.Size = new System.Drawing.Size(78, 18);
                label3.TabIndex = 12;
                label3.Text = videojuego.año;
                // panel1.Controls.Add(label3);
                this.Controls.Add(label3);



                boton.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                boton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                boton.Location = new System.Drawing.Point(550, x);
                boton.Name = " " + videojuego.id;
                boton.Size = new System.Drawing.Size(93, 29);
                boton.TabIndex = 12;
                boton.Text = "Detalles";
                boton.UseVisualStyleBackColor = true;
                // panel1.Controls.Add(boton);
                this.Controls.Add(boton);

                x = x + 30;


                 encontro += 1;
            }
             MessageBox.Show("SE OBTUVIERON " + encontro + " REGISTROS");


            milector.Close();
            milector = null;
            micomando.Dispose();
            micomando = null;
            this.CerrarConexion();
        }

       

        
    }
}
