using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_15Juego_3enLineaGrob
{
    public partial class frmJuego : Form
    {
        PictureBox[,] imagenes;
        bool turno;
        int[,] matriz = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public frmJuego()
        {
            InitializeComponent();
        }
        private void Jugar_Click(object sender, EventArgs e)
        {
            string nombre = (sender as PictureBox).Name;
            string[] aux = nombre.Split('_');
            int fila = Convert.ToInt32(aux[1]);
            int col= Convert.ToInt32(aux[2]);

            if (turno)
            {

                imagenes[fila, col].Image = Tarea_15Juego_3enLineaGrob.Properties.Resources.Estrella;
            }
            else
            {
                imagenes[fila, col].Image = Tarea_15Juego_3enLineaGrob.Properties.Resources.Circulo;
            }
               
           
            imagenes[fila, col].Enabled = false;//no cambia 

            turno = !turno;
            QuienJuega();
            
        }
        private void QuienJuega()
        {  
          if (turno)
            this.txtJugador.Text = "tu turno jugador #1";
          else 
            this.txtJugador.Text = "tu turno jugador #2";

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            turno = true;
            EnceraMatriz();
            QuienJuega();
            
                
            imagenes = new PictureBox[3, 3];
            int x;
            int y= 25;

            for (int i = 0; i<imagenes.GetLength(0); i++)
            {
               x= 19;
                
                for(int j = 0; j<imagenes.GetLength(1); j++)
                {
                    imagenes[i, j] = new PictureBox();
                    imagenes[i, j].Size = new Size(147, 105);
                    imagenes[i, j].Location = new Point(x, y);
                    imagenes[i, j].Image = Tarea_15Juego_3enLineaGrob.Properties.Resources.vacio;
                    imagenes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    imagenes[i, j].Name = $"MisImagenes_{i}_{j}";
                    imagenes[i, j].Click += new System.EventHandler(this.Jugar_Click);


                    this.groupBox1.Controls.Add(imagenes[i,j]);
                    x += 147;
                }
                y += 107;
            }

            this.btnIniciar.Enabled = false;

        }
        private void EnceraMatriz()
        {
            for(int i = 0;i<imagenes.GetLength(0);i++)
            {
                for( int j = 0; j<matriz.GetLength(1); j++)
                {
                    matriz[i, j] = 0;
                    //matriz = new int[3][] = { { 0, 0, 0 },{ 0, 0, 0},{ 0, 0, 0} };
                }
            }
        }
        private void ImprimirMatriz()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1);)
                    Console.Write($"matriz[i,j]");
        }

        /*
         if (turno)
        imagenes[filas, col].Image = Tarea_15Juego_3enLineaGrob.Properties.Recurces.circulo;
        matriz

    }
}
