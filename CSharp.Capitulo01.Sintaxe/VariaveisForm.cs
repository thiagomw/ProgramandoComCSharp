using System;
using System.Windows.Forms;

namespace CSharp.Capitulo01.Sintaxe
{
    public partial class VariaveisForm : Form
    {
        int y = 16;
        int x = 32;
        int w = 45;
        int z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void VariaveisForm_Load(object sender, EventArgs e)
        {

        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            int x = 42, y = 26, w = 89;

            decimal valor = 21.47m; // valor inteiro não é obrigado a colocar a letra no final EX: decimal valor 21;
            double media = 8.5d;
            float bimestre2 = 8.4f;

            string nomeCliente = "Vítor";
            char letra = 'a';

            bool aprovado = true;

            var dataNascimento = new DateTime(2000, 1, 1);

            var a = 2;
            var b = 6;
            var c = 10;
            var d = 13.0;

            // usar quando não sabe qual o tipo que irá entrar no contexto
            object camaleao = "Teste";
            camaleao = 42;
            camaleao = new DateTime();

            var @class = "3D"; //@ _ transforma o termo em um significado comum (verbatim)

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");
            
            resultadoListBox.Items.Add($"c * d = {c * d}");
            resultadoListBox.Items.Add($"d / a = {d / a}");
            resultadoListBox.Items.Add($"d % a = {d % a}");  
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            var x = 5;
            
            resultadoListBox.Items.Add($"x = {x}");

            //x = x - 3;
            x -= 3;

            resultadoListBox.Items.Add($"x = {x}");

        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pré-incremento");
            resultadoListBox.Items.Add($"a = {a}");
            resultadoListBox.Items.Add($"2 + ++a = {2 + ++a}");
            resultadoListBox.Items.Add($"a = {a}");

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós-incremento");
            resultadoListBox.Items.Add($"a = {a}");
            resultadoListBox.Items.Add($"2 + a++ = {2 + a++}");
            resultadoListBox.Items.Add($"a = {a}");
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadoListBox.Items.Add($"w <= x = {w <= x}");
            resultadoListBox.Items.Add($"x == z = {x == z}");
            resultadoListBox.Items.Add($"x != z = {x != z}");
        }

        private void ExibirValoresVariaveis()
        {
            resultadoListBox.Items.Clear();

            resultadoListBox.Items.Add($"x = {x}");
            resultadoListBox.Items.Add($"y = {y}");
            resultadoListBox.Items.Add($"w = {w}");
            resultadoListBox.Items.Add($"z = {z}");

            //resultadoListBox.Items.Add("------------------------");
            resultadoListBox.Items.Add(new string('-',50));
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadoListBox.Items.Add($"w <= x || y == 16 = {w <= x || y == 16}");
            resultadoListBox.Items.Add($"x == z && x != z = {x == z && x != z}");
            resultadoListBox.Items.Add($"!(y > w) = {!(y > w)}"); // ! = negação. negação do falso irá transformar em true, quando seria falso
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();
            
            int ano;

            ano = 2014;

            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(ano % 4 == 0 ? "Sim" : "Não")}");

            ano = 2016;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não")}");

            /*
            if (DateTime.IsLeapYear(ano))
            {
                resultadoListBox.Items.Add($"Sim, o ano de {ano} é bissexto");
            }
            else
            {
                resultadoListBox.Items.Add($"Não, o ano de {ano} não é bissexto");
            }
            */
        }
    }
}
