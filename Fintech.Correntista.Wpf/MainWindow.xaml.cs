using System;
using System.Collections.Generic;
using System.Windows;
using Fintech.Dominio.Entidades;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cliente> clientes = new();

        public MainWindow()
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outros);

            clienteDataGrid.ItemsSource = clientes;
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //Cliente cliente = new();
            var cliente = new Cliente();

            cliente.Cpf = cpfTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);

            var endereco = new Endereco();
            endereco.Cep = cepTextBox.Text;
            endereco.Cidade = cidadeTextBox.Text;
            endereco.Logradouro = logradouroTextBox.Text;
            endereco.Numero = numeroLogradouroTextBox.Text;

            cliente.EnderecoResidencial = endereco;

            cliente.Nome = nomeTextBox.Text;
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            clientes.Add(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso!");
            LimparControles();
            pesquisaClienteTabItem.Focus();
            clienteDataGrid.Items.Refresh();
        }
        private void LimparControles()
        {
            cpfTextBox.Clear();
            nomeTextBox.Text = "";
            dataNascimentoTextBox.Text = null;
            sexoComboBox.SelectedIndex = -1;
            logradouroTextBox.Text = string.Empty;
            cepTextBox.Clear();
            cidadeTextBox.Clear();
            numeroLogradouroTextBox.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
