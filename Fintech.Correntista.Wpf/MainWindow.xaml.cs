using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Fintech.Dominio.Entidades;
using Fintech.Repositorios.SistemaArquivos;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cliente> clientes = new();
        private Cliente clienteSelecionado;
        private readonly MovimentoRepositorio repositorio = new MovimentoRepositorio(Properties.Settings.Default.CaminhoArquivoMovimento);


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

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);

            var banco1 = new Banco();
            banco1.Nome = "Banco Um";
            banco1.Numero = 938;

            bancoComboBox.Items.Add(banco1);
            bancoComboBox.Items.Add(new Banco { Nome = "Banco Dois", Numero = 942 });

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);
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
            LimparControlesCliente();
            pesquisaClienteTabItem.Focus();
            clienteDataGrid.Items.Refresh();
        }
        private void LimparControlesCliente()
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
        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }
        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            clienteTextBox.Text = clienteSelecionado.ToString(); /*$"{clienteSelecionado.Nome} - {clienteSelecionado.Cpf}";*/

            contasTabItem.Focus();
        }

        private void SelecionarCliente(object sender)
        {
            var botaoClicado = (Button)sender;

            clienteSelecionado = (Cliente)botaoClicado.DataContext;
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedItem == null) return;
            
            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoConta.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = null;

            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;
            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            switch (tipoConta)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }

            clienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso!");
            LimparControlesConta();
            clienteDataGrid.Items.Refresh();
            clientesTabItem.Focus();
        }
        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            contaTextBox.Text = clienteSelecionado.ToString();

            contaComboBox.ItemsSource = clienteSelecionado.Contas;
            contaComboBox.Items.Refresh();

            movimentacoesTabItem.Focus();
        }

        private void incluirOperacaoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conta = (Conta)contaComboBox.SelectedItem;
                var operacao = (Operacao)operacaoComboBox.SelectedItem;
                var valor = Convert.ToDecimal(valorTextBox.Text);

                var movimento = conta.EfetuarOperacao(valor, operacao);

                if (movimento == null) return;

                repositorio.Inserir(movimento);

                movimentacaoDataGrid.ItemsSource = conta.Movimentos;
                movimentacaoDataGrid.Items.Refresh();

                saldoTextBox.Text = conta.Saldo.ToString("C", new CultureInfo("pt-BR"));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"O arquivo {ex.FileName} não foi encontrado.");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"O diretório {Properties.Settings.Default.CaminhoArquivoMovimento} nao foi encontrado.");
            }
            catch (SaldoInsuficienteExecption ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Opa! Algo deu errado e em breve teremos uma solução.");
                //Logarerro(ex);
                //log4net
            }
            finally
            {
                // Executado sempre. Mesmo que haja um return no código.
            }
        }

        private void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainSpinner.Visibility = Visibility.Visible;
            
            if (contaComboBox.SelectedIndex == -1) return;

            var conta = (Conta)contaComboBox.SelectedItem;

            conta.Movimentos = repositorio.Selecionar(conta.Agencia.Numero, conta.Numero);

            mainSpinner.Visibility = Visibility.Hidden;

            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            saldoTextBox.Text = conta.Saldo.ToString("C", new CultureInfo("pt-BR"));
        }
    }
}
