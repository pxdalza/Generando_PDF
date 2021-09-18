using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Proyecto_Generar_PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Creamos el documento por defecto
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"..\..\pdfs\prueba_pdf.pdf", FileMode.Create));

            // agregamos titulo y autor
            doc.AddTitle("Generando nuestro primer PDF");
            doc.AddCreator("Diego Alza");

            //Abrimos el archivo
            doc.Open();

            //Creamos el font a utilizar
            iTextSharp.text.Font standarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font colorFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN,
                12, iTextSharp.text.Font.BOLDITALIC, BaseColor.BLUE);
            
            //Agregar encabezado
            doc.Add(new Paragraph("Mi primer PDF"));
            doc.Add(Chunk.NEWLINE);

            // Agregamos el texto del textbox
            doc.Add(new Paragraph(txtMessage.Text));
            doc.Add(Chunk.NEWLINE);

            //Creamos una tabla de 3 columnas
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;

            //Configuramos el titulo de cada columna.
            PdfPCell clCurso = new PdfPCell(new Phrase("Nombre", colorFont));
            clCurso.BorderWidth = 1;
            clCurso.BorderWidthBottom = 0.75f;
            clCurso.HorizontalAlignment = 1;
            clCurso.VerticalAlignment = 1;
            

            PdfPCell clSeccion = new PdfPCell(new Phrase("Seccion", colorFont));
            clSeccion.BorderWidth = 1;
            clSeccion.BorderWidthBottom = 0.75f;
            clSeccion.HorizontalAlignment = 1;
            clSeccion.VerticalAlignment = 1;

            PdfPCell clHorario = new PdfPCell(new Phrase("Horario", colorFont));
            clHorario.BorderWidth = 1;
            clHorario.BorderWidthBottom = 0.75f;
            clHorario.HorizontalAlignment = 1;
            clHorario.VerticalAlignment = 1;

            //Agregamos a la tabla
            table.AddCell(clCurso);
            table.AddCell(clSeccion);
            table.AddCell(clHorario);

            //Creamos las filas 
            clCurso = new PdfPCell(new Phrase("Programacion 1", standarFont));
            clCurso.BorderWidth = 1;

            clSeccion = new PdfPCell(new Phrase("SW11", standarFont));
            clSeccion.BorderWidth = 1;

            clHorario = new PdfPCell(new Phrase("9:00 am - 12:00 pm", standarFont));
            clHorario.BorderWidth = 1;

            //añadir celdas 
            table.AddCell(clCurso);
            table.AddCell(clSeccion);
            table.AddCell(clHorario);

            //Agregando 2 fila 
            //Creamos las filas 
            clCurso = new PdfPCell(new Phrase("Estructura de datos y algoritmos", standarFont));
            clCurso.BorderWidth = 1;

            clSeccion = new PdfPCell(new Phrase("XW11", standarFont));
            clSeccion.BorderWidth = 1;

            clHorario = new PdfPCell(new Phrase("13:00 pm - 16:00 pm", standarFont));
            clHorario.BorderWidth = 1;

            //añadir celdas 
            table.AddCell(clCurso);
            table.AddCell(clSeccion);
            table.AddCell(clHorario);

            //Agregar la tabla al pdf
            doc.Add(table);

            //Cerramos el documento y la edicion.

            doc.Close();
            writer.Close();
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if(user.Rol == A)
            txtMessage.Visible = true;
            //else if(user.Rol == S)
            txtMessage.Visible = false;
        }
    }
}
