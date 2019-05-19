using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;

namespace ChatCliente
{
    public partial class frmCliente : Form
    {

        // Trata o nome do usuário
        private string NomeUsuario = "Desconhecido";
        private StreamWriter stwEnviador;
        private StreamReader strReceptor;
        private TcpClient tcpServidor;
        // Necessário para atualizar o formulário com mensagens da outra thread
        private delegate void AtualizaLogCallBack(string strMensagem);
        // Necessário para definir o formulário para o estado "disconnected" de outra thread
        private delegate void FechaConexaoCallBack(string strMotivo);
        private Thread mensagemThread;
        private IPAddress enderecoIP;
        private bool Conectado;

        public frmCliente(string nome)
        {
            // Recebe nome do usuário logado
            NomeUsuario = nome;
            // Na saída da aplicação : desconectar
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // se não esta conectando aguarda a conexão
            if (Conectado == false)
            {
                // Inicializa conexão
                InicializaConexao();
            }
            else // Se está conectado então desconecta
            {
                FechaConexao("Desconectado a pedido do usuário.");
            }
        }

        private void InicializaConexao()
        {
            // Trata o endereço IP informado em um objeto IPAdress
            enderecoIP = IPAddress.Parse(txtServidorIP.Text);
            // Inicia uma nova conexão TCP com o servidor chat
            tcpServidor = new TcpClient();
            tcpServidor.Connect(enderecoIP, 2502);

            // Verifica se estamos conectados ou não
            Conectado = true;

            //Desabilita e habilita os campos apropriados
            txtServidorIP.Enabled = false;
            txtUsuario.Enabled = false;
            txtLog.Enabled = false;
            txtMensagem.Enabled = true;
            btnEnviar.Enabled = true;
            //btnConectar.Text = "Desconectar";
            // Pega uma imagem no resource e depois alinha a imagem
            btnConectar.Image = ChatCliente.Properties.Resources.cross16001;
            btnConectar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;

            // Envia o nome do usuário ao servidor
            stwEnviador = new StreamWriter(tcpServidor.GetStream());
            stwEnviador.WriteLine(txtUsuario.Text);
            stwEnviador.Flush();

            // Inicia a thread para receber mensagens e nova comunicação
            mensagemThread = new Thread(new ThreadStart(RecebeMensagens));
            mensagemThread.Start();
        }

        private void RecebeMensagens()
        {
            // Recebe a resposta do servidor
            strReceptor = new StreamReader(tcpServidor.GetStream());
            string ConResposta = strReceptor.ReadLine();
            // Se o primeiro caracater da resposta é 1 a conexão foi feita com sucesso
            if (ConResposta[0] == '1')
            {
                // Atualiza o formulário para informar que esta conectado
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { "Conectado com sucesso!" });
            }
            else // Se o primeiro caractere não for 1 a conexão falhou
            {
                string Motivo = "Não Conectado: ";
                // Extrai o motivo da mensagem resposta. O motivo começa no 3° caractere
                Motivo += ConResposta.Substring(2, ConResposta.Length - 2);
                // Atualiza o formulário como o motivo da falha na conexão
                this.Invoke(new FechaConexaoCallBack(this.FechaConexao), new object[] { Motivo });
                // Sai do método
                return;
            }

            // Enquanto estiver conectado le as linhas que estão chegando do servidor
            while (Conectado)
            {
                // Exibe mensagens no Textbox
                this.Invoke(new AtualizaLogCallBack(this.AtualizaLog), new object[] { strReceptor.ReadLine() });
            }
        }

        private void AtualizaLog(string strMensagem)
        {
            // Anexa texto ao final de cada linha
            txtLog.AppendText(strMensagem + "\r\n");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviaMensagem();
        }

        private void txtMensagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se pressionou a tecla Enter
            if (e.KeyChar == (char)13)
            {
                EnviaMensagem();
            }
        }

        private void EnviaMensagem()
        {
            if (txtMensagem.Lines.Length >= 1)
            { // Escreve a mensagem da caixa de texto
                stwEnviador.WriteLine(txtMensagem.Text);
                stwEnviador.Flush();
                txtMensagem.Lines = null;
            }
            txtMensagem.Text = "";
        }

        private void FechaConexao(string Motivo)
        {
            // Mostra o motivo porque a conexão encerrou
            txtLog.AppendText(Motivo + "\r\n");
            // Habilita e desabilita os controles apropriados no formulario
            txtServidorIP.Enabled = true;
            txtUsuario.Enabled = true;
            txtMensagem.Enabled = false;
            btnEnviar.Enabled = false;
            //btnConectar.Text = "Conectar";
            btnConectar.Image = null;

            // Fecha os objetos
            Conectado = false;
            stwEnviador.Close();
            strReceptor.Close();
            tcpServidor.Close();
        }

        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Conectado == true)
            {
                // Fecha as conexões, streams, etc...
                Conectado = false;
                stwEnviador.Close();
                strReceptor.Close();
                tcpServidor.Close();
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = NomeUsuario;
        }

        private void btnIncidentes_Click(object sender, EventArgs e)
        {
            Incidentes formIncidentes = new Incidentes();
            formIncidentes.ShowDialog();
        }
    }
}
